using Finora.Domain;
using Microsoft.EntityFrameworkCore;

namespace Finora.Application.Common.Interfaes;

public interface IAppDbContext
{
    DbSet<Transaction> Transactions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
