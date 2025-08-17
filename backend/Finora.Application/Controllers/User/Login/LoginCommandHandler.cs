using Finora.Application.Common.Interfaces;
using Finora.Application.Controllers.User.Models;
using Finora.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Finora.Application.Controllers.User.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;


    public LoginCommandHandler(
        UserManager<AppUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user is null || user.DeletedAt != null)
            throw new UnauthorizedAccessException("Invalid email");

        if (!await _userManager.CheckPasswordAsync(user, command.Password))
            throw new UnauthorizedAccessException("Invalid password");

        var (access, expiresAt, refresh) = _tokenService.IssueTokens(user);

        return new LoginResponseDto
        {
            AccessToken = access,
            AccessTokenExpiresAtUtc = expiresAt,
            RefreshToken = refresh,
            User = new UserDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                DisplayName = user.UserName ?? user.Email ?? string.Empty
            }
        };
    }

}
