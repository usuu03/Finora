namespace Finora.Application.Controllers.Transaction.Models;

public record  TransactionVm
{
    public List<TransactionDto> Transactions { get; set; } = [];

}