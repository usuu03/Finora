using System;
using Buildora.Application.Common.Interfaces;
using Buildora.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Buildora.Application.Controllers.Transactions.Upsert;

public class UpsertTransactionCommandHandler : IRequestHandler<UpsertTransactionCommand>
{
    private readonly IAppDbContext _context;

    public UpsertTransactionCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpsertTransactionCommand request, CancellationToken cancellationToken)
    {
        Transaction? existing = await _context.Transactions.FirstOrDefaultAsync(cancellationToken);


        if (existing != null)
        {
            request.MergeProperties(existing);
        }
        else
        {
            Transaction transaction = new Transaction();
            request.CopyProperties(transaction);
            transaction.Id = Guid.Empty;
            _context.Transactions.Add(transaction);
           

        }

        await _context.SaveChangesAsync(cancellationToken);
    }

}
