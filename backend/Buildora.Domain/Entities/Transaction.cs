using Buildora.Domain.Enums;

namespace Buildora.Domain.Entities;

public class Transaction
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

}
