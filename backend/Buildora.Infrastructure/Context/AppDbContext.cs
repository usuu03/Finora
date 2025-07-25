using Buildora.Application.Common.Interfaces;
using Buildora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buildora.Infrastructure.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    IQueryable<Transaction> IAppDbContext.Transactions => Transactions;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}