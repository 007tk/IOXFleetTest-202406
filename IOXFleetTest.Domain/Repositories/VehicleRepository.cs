using IOXFleetTest.Domain.Filters;
using IOXFleetTest.Persistence;
using IOXFleetTest.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace IOXFleetTest.Domain.Repositories;


public interface IVehicleRepository
{
    Task<Vehicle> AddVehicle(Vehicle vehicle, CancellationToken cancellationToken);

    Task<List<Vehicle>> GetVehicleList(VehicleFilter filter,CancellationToken cancellationToken);
}

public class VehicleRepository : IVehicleRepository
{
    private readonly FleetTestDbContext _dbContext;
    
    public VehicleRepository(FleetTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Vehicle> AddVehicle(Vehicle vehicle, CancellationToken cancellationToken)
    {
        var inserted = await _dbContext.Vehicles
            .AddAsync(vehicle, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return inserted.Entity;
    }

    public async Task<List<Vehicle>> GetVehicleList(VehicleFilter filter,CancellationToken cancellationToken)
    {
        var vehicles = _dbContext.Vehicles.ToList();
        
        if (!string.IsNullOrWhiteSpace(filter.Vin))
        {
            vehicles = await _dbContext.Vehicles
                .Where(v => v.VIN.Contains(filter.Vin))
                .ToListAsync(cancellationToken);
        }

        if (!string.IsNullOrWhiteSpace(filter.Color))
        {
            vehicles = await _dbContext.Vehicles
                .Where(v => v.Color.Contains(filter.Color))
                .ToListAsync(cancellationToken);
        }
        
        if (!string.IsNullOrWhiteSpace(filter.Model))
        {
            vehicles = await _dbContext.Vehicles
                .Where(v => v.Model.Contains(filter.Model))
                .ToListAsync(cancellationToken);
        }

        if (filter.AccountId > 0)
        {
            vehicles = await _dbContext
                .Vehicles
                .Where(v => v.AccountId == filter.AccountId)
                .ToListAsync(cancellationToken);
        }

        return vehicles;
    }
}