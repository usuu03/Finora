using System;
using Finora.Application.Common.Exceptions;
using Finora.Application.Controllers.User.Models;
using Finora.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finora.Application.Controllers.User.Get;

public record GetUserQuery(Guid UserId) : IRequest<UserDto>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserQueryHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null || user.DeletedAt != null)
            throw new NotFoundException("User not found");

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            DisplayName = user.UserName ?? user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            AvatarUrl = user.AvatarUrl,
            CreatedAt = user.CreatedAt,
            EmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed
        };
    }

}
