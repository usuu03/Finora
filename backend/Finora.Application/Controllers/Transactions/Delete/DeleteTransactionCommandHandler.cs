using System;
using Finora.Application.Common.Interfaces;
using Finora.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Controllers.Transactions.Delete;

public record DeleteTransactionCommand(List<Guid> Ids) : IRequest<DeleteResponse>;

public class DeleteTransactionCommandHandler(IAppDbContext db) : IRequestHandler<DeleteTransactionCommand, DeleteResponse>
{
    public async Task<DeleteResponse> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactions = await db.Transactions
            .Where(t => request.Ids.Contains(t.Id))
            .ToListAsync(cancellationToken);

        Dictionary<Guid, string> errors = new Dictionary<Guid, string>();
        var success = new List<Guid>();

        foreach (var id in request.Ids)
        {
            if (transactions.All(t => t.Id != id))
            {
                errors[id] = "Transaction not found.";
            }
        }

        foreach (var transaction in transactions)
        {
            transaction.DeletedAt = DateTime.UtcNow;
            success.Add(transaction.Id);
        }

        await db.SaveChangesAsync(cancellationToken);

        return new DeleteResponse
        {
            Success = success,
            Failed = errors.Keys.ToList(),
            Message = errors.Count == 0
                ? "Transactions deleted successfully."
                : "Transactions deleted with some errors.",
            Errors = errors
        };
    }
}
