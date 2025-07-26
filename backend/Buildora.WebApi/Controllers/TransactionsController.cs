using Buildora.Application.Controllers.Transactions.GetAll;
using Buildora.Application.Controllers.Transactions.Models;
using Buildora.Application.Controllers.Transactions.Upsert;
using Buildora.WebApi.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Buildora.WebApi.Controllers;

public class TransactionsController : ApiControllerBase
{
    [HttpGet]
    public Task<TransactionVm> Get()
    {
        return Mediator.Send(new GetAllTransactionsQuery());
    }

    [HttpPost]
    public Task Upsert([FromBody] UpsertTransactionCommand command)
	{
		return Mediator.Send(command);
	}
}
