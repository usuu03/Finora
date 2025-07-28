using Finora.Domain;
using Finora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Transaction> Transactions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
