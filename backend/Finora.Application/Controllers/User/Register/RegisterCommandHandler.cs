using Finora.Application.Common.Interfaces;
using Finora.Application.Controllers.User.Models;
using Finora.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finora.Application.Controllers.User.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(
        UserManager<AppUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(command.Email);
        if (existingUser is not null && existingUser.DeletedAt == null)
            throw new InvalidOperationException("Email is already registered");

        var newUser = new AppUser
        {
            UserName = command.DisplayName,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await _userManager.CreateAsync(newUser, command.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        var (access, expiresAt, refresh) = _tokenService.IssueTokens(newUser);
        
        return new RegisterResponse
        {
            Email = newUser.Email,
            DisplayName = newUser.UserName,
            AccessToken = access,
            RefreshToken = refresh,
        };
    }

}
