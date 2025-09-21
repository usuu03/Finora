using Finora.Application.Controllers.User.Get;
using Finora.Application.Controllers.User.Login;
using Finora.Application.Controllers.User.Logout;
using Finora.Application.Controllers.User.Register;
using Finora.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finora.WebApi.Controllers;

public class AccountController : ApiControllerBase
{

    [HttpPost("register")]
    [AllowAnonymous]
    public Task<IActionResult> Register([FromBody] RegisterCommand command) => Send(command);

    [HttpPost("login")]
    [AllowAnonymous]
    public Task<IActionResult> Login([FromBody] LoginCommand command) => Send(command);

    [HttpGet("{userId:guid}/details")]
    public Task<IActionResult> GetUserDetails(Guid userId) => Send(new GetUserQuery(userId));

    [HttpPost("logout")]
    public Task<IActionResult> Logout([FromBody] LogoutCommand command) => Send(command);

}
