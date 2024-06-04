namespace IOXFleetTest.Persistence.Models;

public class Quote
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public DateTime ValidTo { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string QuoteNumber { get; set; }
    
    /// <summary>
    /// Desctioption
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Amount
    /// </summary>
    public string Amount { get; set; }
    
    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// Account id.
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }
}