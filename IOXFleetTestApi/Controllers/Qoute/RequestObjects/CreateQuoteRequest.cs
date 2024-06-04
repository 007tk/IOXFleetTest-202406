using IOXFleetTest.Application.Qoutes.Commands.CreateQouteCommand;

namespace IOXFleetTestApi.Controllers.Qoute.RequestObjects;

public class CreateQuoteRequest
{
    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Desctioption
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Amount
    /// </summary>
    public string Amount { get; set; }
    
    /// <summary>
    /// Account id.
    /// </summary>
    public int AccountId { get; set; }
    
    public CreateQuoteCommand MapToCommand(CreateQuoteRequest request)
    {
        var command = new CreateQuoteCommand(
            request.Description,
            request.Amount,
            request.AccountId
        );

        return command;
    }
}