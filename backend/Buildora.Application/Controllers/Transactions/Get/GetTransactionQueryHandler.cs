using System;
using Buildora.Application.Controllers.Transactions.Models;
using MediatR;

namespace Buildora.Application.Controllers.Transactions.Get;

public record GetTransactionQuery : IRequest<TransactionDto>
{}

public class GetTransactionQueryHandler
{

}
