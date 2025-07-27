using Finora.Domain.Common;
using Finora.Domain.Common.Enums;

namespace Finora.Domain;

public class Transaction : BaseEntity<Transaction>
{
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
}
