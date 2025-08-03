using Finora.Domain.Common;
using Finora.Domain.Common.Enums;
using Finora.Domain.Common.Interfaces;

namespace Finora.Domain.Entities;

public class Transaction : BaseEntity<Transaction>, IHaveSoftDelete
{
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }

    public override bool Equals(Transaction? other)
    {
        return other is not null &&
               Id == other.Id &&
               Amount == other.Amount &&
               Category == other.Category &&
               Description == other.Description &&
               Type == other.Type &&
               Date == other.Date;
    }
}
