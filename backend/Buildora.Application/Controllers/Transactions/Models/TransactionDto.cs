using System;
using Buildora.Domain.Enums;

namespace Buildora.Application.Controllers.Transactions.Models;

public class TransactionDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public decimal Amount { get; set; }
    public Category Category { get; set; }
    

}
