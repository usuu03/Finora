using Buildora.Domain.Enums;
using Buildora.Shared.Domain;

namespace Buildora.Domain.Entities;

public class Transaction : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public DateTime AddedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
