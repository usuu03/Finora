using System;
using Finora.Application.Common.Interfaces;
using Finora.Domain.Common.Enums;
using Finora.Domain.Entities;
using MediatR;

namespace Finora.Application.Controllers.Transactions.Upsert;

public class UpsertTransactionCommand : IRequest, IUpsertCommand<Transaction>
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }

    public void CopyProperties(Transaction model)
    {
        model.Id = Id;
        MergeProperties(model);
    }

    public void MergeProperties(Transaction model)
    {
        model.Amount = Amount;
        model.Category = Category;
        model.Description = Description;
        model.Type = Type;
        model.Date = Date;
    }
}
