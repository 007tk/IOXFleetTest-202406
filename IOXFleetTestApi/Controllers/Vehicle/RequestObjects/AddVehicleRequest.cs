using IOXFleetTest.Application.Vehicles.Commands.AddVehicleCommand;

namespace IOXFleetTestApi.Controllers.Vehicle.RequestObjects;

public class AddVehicleRequest
{
    /// <summary>
    /// VIN
    /// </summary>
    public string VIN { get; set; }
    
    /// <summary>
    /// license number
    /// </summary>
    public string LicenseNumber { get; set; }
    
    /// <summary>
    /// Plate number
    /// </summary>
    public string PlateNumber { get; set; }
    
    /// <summary>
    /// License expiry date
    /// </summary>
    public DateOnly LicenseExpiry { get; set; }
    
    /// <summary>
    /// Model
    /// </summary>
    public string Model { get; set; }
    
    /// <summary>
    /// Color
    /// </summary>
    public string Color { get; set; }
    
    /// <summary>
    /// Account id.
    /// </summary>
    public int AccountId { get; set; }
    
    public AddVehicleCommand MapToCommand(AddVehicleRequest request)
    {
        var command = new AddVehicleCommand(
            request.VIN,
            request.LicenseNumber,
            request.LicenseExpiry,
            request.Model,
            request.Color,
            request.PlateNumber,
            request.AccountId
        );

        return command;
    }
}