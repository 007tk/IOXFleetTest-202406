using IOXFleetTest.Persistence;
using IOXFleetTest.Persistence.Models;

namespace IOXFleetTest.Domain.Repositories;


public interface IAccountRepository
{
    Task UpdateBalance(Transaction transaction, int accountId, CancellationToken cancellationToken);
    
    Task UpdateAccountBalance(double amount, int accountId, CancellationToken cancellationToken);
}

public class AccountRepository : IAccountRepository
{
    private readonly FleetTestDbContext _dbContext;
    
    public AccountRepository(FleetTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task UpdateBalance(Transaction transaction, int accountId, CancellationToken cancellationToken)
    {
        var account = _dbContext.Accounts
            .FirstOrDefault(a => a.Id == accountId);

        if (account == null)
        {
            throw new Exception("Account not found");
        }

        // Add amount to balance.
        account.AccountBalance += transaction.Amount;

        _dbContext
            .Accounts
            .Update(account);

        _dbContext.SaveChangesAsync(cancellationToken);
        
        return Task.CompletedTask;
    }

    public Task UpdateAccountBalance(double amount, int accountId, CancellationToken cancellationToken)
    {
        var account = _dbContext.Accounts
            .FirstOrDefault(a => a.Id == accountId);

        if (account == null)
        {
            throw new Exception("Account not found");
        }

        account.AccountBalance = amount;

        _dbContext
            .Accounts
            .Update(account);

        _dbContext.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
}