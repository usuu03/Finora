using Finora.Application.Controllers.User.Login;
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

}
