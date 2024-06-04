namespace IOXFleetTest.Persistence.Models;

public class Transaction
{
    public int Id { get; set; }
    
    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Type
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Amount
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Account id.
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }
}