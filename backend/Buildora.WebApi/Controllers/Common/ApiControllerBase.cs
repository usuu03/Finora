using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buildora.WebApi.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
	private ISender? _mediator;
	protected ISender Mediator
	{
		get
		{
			if (_mediator == null)
			{
				_mediator = HttpContext.RequestServices.GetRequiredService<ISender>();
			}
			return _mediator;
		}
	}
}