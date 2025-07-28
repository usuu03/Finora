namespace Finora.Application.Controllers.Transactions.Models;

public record  TransactionVm
{
    public List<TransactionDto> Transactions { get; set; } = [];

}