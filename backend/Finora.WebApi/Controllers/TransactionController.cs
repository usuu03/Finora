using Finora.Application.Controllers.Transactions.Delete;
using Finora.Application.Controllers.Transactions.Get;
using Finora.Application.Controllers.Transactions.GetAll;
using Finora.Application.Controllers.Transactions.Upsert;
using Finora.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finora.WebApi.Controllers;

public class TransactionController : ApiControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public Task<IActionResult> Get([FromQuery] GetAllTransactionsQuery query) => Send(query);

    [HttpGet("{id}")]
    public Task<IActionResult> Get([FromRoute] GetTransactionQuery query) => Send(query);

    [HttpPost]
    public Task<IActionResult> Upsert([FromBody] UpsertTransactionCommand command)
        => Send(command);

   [HttpDelete("{id:guid}")]
   public Task<IActionResult> Delete([FromRoute] Guid id)
    => Send(new DeleteTransactionCommand(new List<Guid> { id }));


    [HttpDelete("delete")]
    public Task<IActionResult> DeleteMultiple([FromBody] DeleteTransactionCommand command)
        => Send(command);
}
