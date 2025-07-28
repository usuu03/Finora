using System;
using Finora.Application.Common.Interfaces;
using Finora.Application.Controllers.Transactions.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Controllers.Transactions.GetAll;


public record GetAllTransactionsQuery : IRequest<TransactionVm>;
public class GetAllTransactionsQueryHandler(IAppDbContext db) : IRequestHandler<GetAllTransactionsQuery, TransactionVm>
{
    public async Task<TransactionVm> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await db.Transactions
            .Select(t => new TransactionDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Category = t.Category,
                Description = t.Description,
                Type = t.Type,
                Date = t.Date,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return new TransactionVm { Transactions = transactions };
    }

}
