using IOXFleetTest.Application.Transactions.Commands.DepositCommand;
using IOXFleetTest.Domain.Shared;

namespace IOXFleetTestApi.Controllers.Transaction.RequestObjects;

public class DepositRequest
{
    public int AccountId { get; set; }
    
    public double Amount { get; set; }
    
    
    public DepositCommand MapToCommand(DepositRequest request)
    {
        var command = new DepositCommand(
            nameof(TransactionType.Deposit),
            request.AccountId,
            request.Amount,
            DateTime.UtcNow
        );

        return command;
    }
}