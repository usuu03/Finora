using System;
using Finora.Application.Common.Interfaces;
using Finora.Application.Controllers.Transactions.Upsert;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Controllers.Transactions.Get;

public record GetTransactionQuery(Guid Id) : IRequest<UpsertTransactionCommand>
{

}

public class GetTransactionQueryHandler(IAppDbContext db)
    : IRequestHandler<GetTransactionQuery, UpsertTransactionCommand>
{
    public async Task<UpsertTransactionCommand> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var transaction = await db.Transactions
            .AsNoTracking()
            .Where(t => t.Id == request.Id)
            .Select(t => new UpsertTransactionCommand
            {
                Id = t.Id,
                Amount = t.Amount,
                Category = t.Category,
                Description = t.Description,
                Type = t.Type,
                Date = t.Date
            })
            .FirstOrDefaultAsync(cancellationToken);

        return transaction!;
    }
}
