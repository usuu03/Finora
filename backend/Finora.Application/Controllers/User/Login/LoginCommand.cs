using Finora.Application.Controllers.User.Models;
using MediatR;

namespace Finora.Application.Controllers.User.Login;

public class LoginCommand : IRequest<LoginResponseDto>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
