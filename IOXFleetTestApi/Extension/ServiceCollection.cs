using IOXFleetTest.Domain.Repositories;

namespace IOXFleetTestApi.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        return services;
    }
}