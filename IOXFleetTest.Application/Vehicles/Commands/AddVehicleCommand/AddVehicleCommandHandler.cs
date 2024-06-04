using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Vehicles.Commands.AddVehicleCommand;

public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    public AddVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        var newVehicle = new Vehicle()
        {
            VIN = request.VIN,
            LicenseNumber = request.LicenseNumber,
            Color = request.Color,
            PlateNumber = request.PlateNumber,
            AccountId = request.accountId
        };

        await _vehicleRepository.AddVehicle(newVehicle, cancellationToken);
    }
}