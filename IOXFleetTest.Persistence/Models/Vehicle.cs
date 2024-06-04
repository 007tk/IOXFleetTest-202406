namespace IOXFleetTest.Persistence.Models;

public class Vehicle
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }
    
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

    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }
}