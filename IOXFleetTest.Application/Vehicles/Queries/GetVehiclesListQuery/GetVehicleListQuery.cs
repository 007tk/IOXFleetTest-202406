using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Vehicles.Queries.GetVehiclesListQuery;

public record GetVehicleListQuery(
    string VIN,
    string Model,
    string Color,
    int AccountId
    ) : IRequest<List<Vehicle>>;