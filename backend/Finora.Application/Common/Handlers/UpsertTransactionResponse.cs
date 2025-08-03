using Finora.Application.Common.Enums;

namespace Finora.Application.Common.Handlers;

public class UpsertTransactionResponse
{
    public UpsertAction Action { get; set; }

    public UpsertTransactionResponse(UpsertAction action)
    {
        Action = action;
    }

}
