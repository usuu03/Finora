using Buildora.Application.Common.Interfaces;
using Buildora.Application.Controllers.Transactions.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Buildora.Application.Controllers.Transactions.GetAll;

public record GetAllTransactionsQuery : IRequest<TransactionVm>
{}

public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, TransactionVm>
{
    private readonly IAppDbContext _context;

    public GetAllTransactionsQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionVm> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _context.Transactions
             .Select(t => new TransactionDto
             {
                 Id = t.Id,
                 Name = t.Name,
                 Amount = t.Amount,
                 Date = t.Date,
                 Description = t.Description
             })
             .ToListAsync(cancellationToken);

        return new TransactionVm
        {
            Transactions = transactions
        };
    }
}
