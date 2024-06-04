using MediatR;

namespace IOXFleetTest.Application.Qoutes.Commands.PayQuoteCommand;

public record PayQuoteCommand(
    int AccountId,
    double Amount,
    string VIN,
    string QuoteNumber
    ) : IRequest;