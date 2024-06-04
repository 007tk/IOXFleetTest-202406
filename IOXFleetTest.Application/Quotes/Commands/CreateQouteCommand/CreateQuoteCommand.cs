using MediatR;

namespace IOXFleetTest.Application.Qoutes.Commands.CreateQouteCommand;

public record CreateQuoteCommand(
    string Description,
    string Amount,
    int AccountId
    ) : IRequest;