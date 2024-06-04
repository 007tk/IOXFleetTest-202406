using IOXFleetTest.Persistence;
using IOXFleetTest.Persistence.Models;

namespace IOXFleetTest.Domain.Repositories;


public interface IQuoteRepository
{
    Task<Quote> CreateQuote(Quote quote, CancellationToken cancellationToken);

    Quote? GetByNumber(string number, CancellationToken cancellationToken);

    Task UpdateQuoteStatus(Quote quote, CancellationToken cancellationToken);
}

public class QuoteRepository : IQuoteRepository
{
    private readonly FleetTestDbContext _dbContext;
    
    public QuoteRepository(FleetTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Quote> CreateQuote(Quote quote, CancellationToken cancellationToken)
    {
        var inserted = await _dbContext.Quotes
            .AddAsync(quote, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return inserted.Entity;
    }

    public Quote? GetByNumber(string number, CancellationToken cancellationToken)
    {
        return _dbContext
            .Quotes
            .FirstOrDefault(q => q.QuoteNumber == number);
    }

    public Task UpdateQuoteStatus(Quote quote, CancellationToken cancellationToken)
    {
        _dbContext.Quotes.Update(quote);

        _dbContext.SaveChangesAsync(cancellationToken);
        
        return Task.CompletedTask;
    }
}