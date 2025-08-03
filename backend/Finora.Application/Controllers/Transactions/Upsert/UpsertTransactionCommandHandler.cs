using Finora.Application.Common.Enums;
using Finora.Application.Common.Handlers;
using Finora.Application.Common.Interfaces;
using Finora.Domain.Entities;
using MediatR;

namespace Finora.Application.Controllers.Transactions.Upsert;

public class UpsertTransactionCommandHandler(IAppDbContext db) : IRequestHandler<UpsertTransactionCommand, UpsertTransactionResponse>
{
    public async Task<UpsertTransactionResponse> Handle(UpsertTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await db.Transactions.FindAsync(request.Id, cancellationToken);
        UpsertAction action;

        if (transaction != null)
        {
            request.MergeProperties(transaction);
            action = UpsertAction.Updated;
        }
        else
        {
            var model = new Transaction();
            request.CopyProperties(model);
            model.Id = Guid.NewGuid();
            db.Transactions.Add(model);
            action = UpsertAction.Created;
        }

        await db.SaveChangesAsync(cancellationToken);
        return new UpsertTransactionResponse(action);
    }
}
