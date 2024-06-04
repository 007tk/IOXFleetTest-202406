using IOXFleetTest.Persistence;
using IOXFleetTest.Persistence.Models;

namespace IOXFleetTest.Domain.Repositories;


public interface ITransactionRepository
{
    Task<Transaction> Deposit(Transaction transaction, CancellationToken cancellationToken);
}

public class TransactionRepository : ITransactionRepository
{
    private readonly FleetTestDbContext _dbContext;
    
    public TransactionRepository(FleetTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Transaction> Deposit(Transaction transaction, CancellationToken cancellationToken)
    {
        var inserted = await _dbContext.Transactions
            .AddAsync(transaction, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return inserted.Entity;
    }
}