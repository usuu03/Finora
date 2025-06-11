using Buildora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buildora.Infrastructure.Persistence.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{

    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");
        builder.Property(t => t.AddedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

    }

}
