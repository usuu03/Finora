using Finora.Domain.Common;

namespace Finora.Domain;

public class Transaction : BaseEntity<Transaction>
{
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
