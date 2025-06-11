using Buildora.Infrastructure.Context;
using Buildora.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;


// Sets up the App configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registers Controllers as services tells .NET to look for controllers and use them for HTTP requests
builder.Services.AddControllers();

// Tells .NET to use AppDbContext to talk to the database
// and use SQLite as the database provider. The connection string is read from the appsettings.json file.
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

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

// Start the app and listen for incoming HTTP requests
app.Run();
