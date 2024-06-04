using MediatR;

namespace IOXFleetTest.Application.Vehicles.Commands.AddVehicleCommand;

public record AddVehicleCommand(
    string VIN,
    string LicenseNumber,
    DateOnly LicenseExpiry,
    string Model,
    string Color,
    string PlateNumber,
    int accountId) : IRequest;