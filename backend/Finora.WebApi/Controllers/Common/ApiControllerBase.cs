using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finora.WebApi.Common;

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

	protected async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request)
	{
		var result = await Mediator.Send(request);
		return Ok(result);
	}
}