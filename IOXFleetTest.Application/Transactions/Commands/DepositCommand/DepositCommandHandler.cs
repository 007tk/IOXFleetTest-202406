using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Transactions.Commands.DepositCommand;

public class DepositCommandHandler : IRequestHandler<DepositCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    
    public DepositCommandHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }
    
    public async Task Handle(DepositCommand request, CancellationToken cancellationToken)
    {
        var newTransaction = new Transaction()
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            Type = request.Type,
            Date = request.DateTime
        };

        var transaction = await _transactionRepository.Deposit(newTransaction, cancellationToken);

        if (transaction != null)
        {
            await _accountRepository.UpdateBalance(transaction, newTransaction.AccountId, cancellationToken);
        }
    }
}