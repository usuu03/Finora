using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Finora.Application.Common.Interfaces;
using Finora.Domain.Entities;
using Finora.Infrastructure.Context;
using Finora.Infrastructure.Seeding;
using Finora.Infrastructure.Services.Auth;
using Finora.Infrastructure.Services.Auth.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


// Sets up the App configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registers Controllers as services tells .NET to look for controllers and use them for HTTP requests
//builder.Services.AddControllers();

// Tells .NET to use AppDbContext to talk to the database
// and use SQLite as the database provider. The connection string is read from the appsettings.json file.
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("Finora.Application"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// 4.1 Bind Jwt options
var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()
                 ?? throw new InvalidOperationException("Jwt options missing");
builder.Services.AddSingleton(jwtOptions);

// 4.2 Authentication – JWT Bearer
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.SigningKey)
            ),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });


// 4.3 Authorization – secure by default
builder.Services.AddAuthorization(opt =>
{
    opt.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes("Bearer")
        .RequireAuthenticatedUser()
        .Build();
});

// 4.4 TokenService
builder.Services.AddSingleton<ITokenService, TokenService>();



// Adds the Identity service to the DI container
// Configures Identity to use the User class and the AppDbContext class
builder.Services.AddIdentityApiEndpoints<AppUser>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredLength = 12;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<AppDbContext>();


// Register IAppDbContext as AppDbContext.
builder.Services.AddScoped<IAppDbContext, AppDbContext>();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("Finora.Application"));


// Builds the app
var app = builder.Build();

// Maps routes like /api/activites to controller methods.
// similar to defining URLs in Django
app.MapControllers();

// Creates a scope so we can get services like the database context
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


try
{
    // Gets the AppDbContext 
    var context = services.GetRequiredService<AppDbContext>();
    // Applies any pending to the database 
    await context.Database.MigrateAsync();
    //Adds any initial data to the database
    await DbInitializer.SeedData(context);
}
// Log any errors that occur during migration or seeding
catch (System.Exception)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError("An error occurred during migration or seeding the database.");
    throw;
}

app.UseAuthentication();   
app.UseAuthorization();

// Start the app and listen for incoming HTTP requests
app.Run();