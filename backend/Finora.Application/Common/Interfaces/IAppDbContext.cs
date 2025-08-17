using Finora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Transaction> Transactions { get; set; }
    DbSet<AppUser> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
