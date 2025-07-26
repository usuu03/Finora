using Buildora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buildora.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Transaction> Transactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
