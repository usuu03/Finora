using Buildora.Application.Common.Interfaces;
using Buildora.Domain.Entities;
using Buildora.Domain.Enums;
using MediatR;

namespace Buildora.Application.Controllers.Transactions.Upsert;

public class UpsertTransactionCommand : IRequest, IUpsertCommand<Transaction>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public void CopyProperties(Transaction model)
    {
        model.Id = Id;
        MergeProperties(model);
    }
    public void MergeProperties(Transaction model)
    {
        model.Name = Name;
        model.Description = Description;
        model.Date = Date;
        model.Amount = Amount;
        model.Category = Category;
        model.UpdatedAt = DateTime.UtcNow;
    }

}
