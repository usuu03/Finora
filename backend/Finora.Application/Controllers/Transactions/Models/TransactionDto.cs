using Finora.Domain.Common.Enums;

namespace Finora.Application.Controllers.Transactions.Models;

public record class TransactionDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }

}