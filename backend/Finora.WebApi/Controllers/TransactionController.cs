using System;
using Finora.Application.Controllers.Transaction.GetAll;
using Finora.Application.Controllers.Transaction.Models;
using Finora.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finora.WebApi.Controllers;

public class TransactionController : ApiControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get([FromQuery] GetAllTransactionsQuery query) => Send(query);
   
   
}
