using IOXFleetTest.Application.Vehicles.Queries.GetVehiclesListQuery;

namespace IOXFleetTestApi.Controllers.Vehicle.RequestObjects;

public class VehicleListRequest
{
    /// <summary>
    /// VIN
    /// </summary>
    public string VIN { get; set; }
    
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
    
    public GetVehicleListQuery MapToQuery(VehicleListRequest request)
    {
        var query = new GetVehicleListQuery(
            request.VIN,
            request.Model,
            request.Color,
            request.AccountId
        );

        return query;
    }
}