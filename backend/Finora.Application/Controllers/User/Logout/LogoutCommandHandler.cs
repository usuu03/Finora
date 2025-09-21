using Finora.Application.Common.Interfaces;
using Finora.Application.Controllers.User.Models;
using Finora.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finora.Application.Controllers.User.Logout;

public record LogoutCommand(string? RefreshToken = null) : IRequest<LogoutResponse>;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public LogoutCommandHandler(
        ITokenService tokenService,
        UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        // For JWT-based authentication, logout is mainly handled client-side
        // The client should remove the tokens from storage

        // If you want to invalidate refresh tokens, you can implement that here
        if (!string.IsNullOrEmpty(request.RefreshToken))
        {
            // TODO: Implement refresh token invalidation if needed
            // This could involve adding the token to a blacklist or removing it from storage
            // For now, we'll just acknowledge the refresh token was provided
        }

        // You can add any additional logout logic here such as:
        // - Logging the logout event
        // - Clearing user sessions
        // - Audit trail tracking

        return await Task.FromResult(new LogoutResponse
        {
            Success = true,
            Message = "Logged out successfully"
        });
    }

}
