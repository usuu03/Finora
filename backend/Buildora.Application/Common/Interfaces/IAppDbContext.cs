using Buildora.Domain.Entities;

namespace Buildora.Application.Common.Interfaces;

public interface IAppDbContext
{
    IQueryable<Transaction> Transactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
