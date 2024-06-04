using IOXFleetTest.Application.Qoutes.Commands.PayQuoteCommand;

namespace IOXFleetTestApi.Controllers.Qoute.RequestObjects;

public class PayQuoteRequest
{
    /// <summary>
    /// Email
    /// </summary>
    public string QuoteNumber { get; set; }
    
    /// <summary>
    /// Amount
    /// </summary>
    public double Amount { get; set; }
    
    /// <summary>
    /// Status
    /// </summary>
    public string VIN { get; set; }
    
    /// <summary>
    /// Account id.
    /// </summary>
    public int AccountId { get; set; }
    
    public PayQuoteCommand MapToCommand(PayQuoteRequest request)
    {
        var command = new PayQuoteCommand(
            request.AccountId,
            request.Amount,
            request.VIN,
            request.QuoteNumber
        );

        return command;
    }
}