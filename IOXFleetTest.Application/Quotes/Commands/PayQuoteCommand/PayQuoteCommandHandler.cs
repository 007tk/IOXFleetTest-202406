using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Domain.Shared;
using MediatR;

namespace IOXFleetTest.Application.Qoutes.Commands.PayQuoteCommand;

public class PayQuoteCommandHandler : IRequestHandler<PayQuoteCommand>
{
    private readonly IQuoteRepository _quoteRepository;
    private readonly IAccountRepository _accountRepository;
    
    public PayQuoteCommandHandler(IQuoteRepository quoteRepository, IAccountRepository accountRepository)
    {
        _quoteRepository = quoteRepository;
        _accountRepository = accountRepository;
    }
    
    public async Task Handle(PayQuoteCommand request, CancellationToken cancellationToken)
    {
        var quote = _quoteRepository.GetByNumber(request.QuoteNumber, cancellationToken);
        
        if (quote is null)
        {
            throw new Exception("Quote not found!");
        }

        var balance = quote.Account.AccountBalance - request.Amount;

        if (balance < 0)
        {
            throw new Exception("You have insufficient funds.");
        }

        quote.Status = nameof(QuoteStatus.PAID);

        await _quoteRepository.UpdateQuoteStatus(quote, cancellationToken);
        
        await _accountRepository.UpdateAccountBalance(balance, request.AccountId, cancellationToken);
    }
}