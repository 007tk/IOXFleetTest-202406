using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Domain.Shared;
using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Qoutes.Commands.CreateQouteCommand;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand>
{
    private readonly IQuoteRepository _quoteRepository;
    
    public CreateQuoteCommandHandler(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    public async Task Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        var newQuote = new Quote()
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            Date = DateTime.UtcNow,
            ValidTo = DateTime.UtcNow.AddDays(7),
            QuoteNumber = Guid.NewGuid().ToString(),
            Description = request.Description,
            Status = nameof(QuoteStatus.NEW)
        };

        await _quoteRepository.CreateQuote(newQuote, cancellationToken);
    }
}