using IOXFleetTest.Persistence;
using IOXFleetTest.Persistence.Models;

namespace IOXFleetTest.Domain.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> CreateUser(User user, CancellationToken cancellationToken);
}

public class UserRepository : IUserRepository
{
    private readonly FleetTestDbContext _dbContext;
    
    public UserRepository(FleetTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
    {
        var inserted = await _dbContext.Users
            .AddAsync(user, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return inserted.Entity;
    }
}