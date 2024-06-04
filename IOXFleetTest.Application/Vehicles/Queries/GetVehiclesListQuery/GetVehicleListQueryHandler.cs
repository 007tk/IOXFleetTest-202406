using IOXFleetTest.Domain.Filters;
using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Vehicles.Queries.GetVehiclesListQuery;

public class GetVehicleListQueryHandler : IRequestHandler<GetVehicleListQuery, List<Vehicle>>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    public GetVehicleListQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<List<Vehicle>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
    {
        var filter = new VehicleFilter()
        {
            AccountId = request.AccountId,
            Color = request.Color,
            Model = request.Model,
            Vin = request.VIN
        };

        var vehicles = await _vehicleRepository.GetVehicleList(filter, cancellationToken);

        return vehicles;
    }
}