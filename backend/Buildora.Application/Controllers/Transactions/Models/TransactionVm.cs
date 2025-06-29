namespace Buildora.Application.Controllers.Transactions.Models;

public record class TransactionVm
{
    public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

}
