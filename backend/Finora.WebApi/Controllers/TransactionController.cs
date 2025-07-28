using Finora.Application.Controllers.Transactions.GetAll;
using Finora.Application.Controllers.Transactions.Upsert;
using Finora.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finora.WebApi.Controllers;

public class TransactionController : ApiControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get([FromQuery] GetAllTransactionsQuery query) => Send(query);

    [HttpPost]
    public Task Upsert([FromBody] UpsertTransactionCommand command)
	{
		return Mediator.Send(command);
	}
   
   
}
