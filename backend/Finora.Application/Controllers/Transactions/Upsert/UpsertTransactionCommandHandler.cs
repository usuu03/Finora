using Finora.Application.Common.Interfaces;
using Finora.Domain.Entities;
using MediatR;

namespace Finora.Application.Controllers.Transactions.Upsert;

public class UpsertTransactionCommandHandler(IAppDbContext db) : IRequestHandler<UpsertTransactionCommand>
{
    public async Task Handle(UpsertTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await db.Transactions.FindAsync(request.Id, cancellationToken);

        if (transaction != null)
        {
            request.MergeProperties(transaction);
        }
        else
        {
            var model = new Transaction();
            request.CopyProperties(model);
            model.Id = Guid.NewGuid();
            db.Transactions.Add(model);
        }

        await db.SaveChangesAsync(cancellationToken);
    }
}
