using MediatR;

namespace IOXFleetTest.Application.Transactions.Commands.DepositCommand;

public record DepositCommand(
    string Type,
    int AccountId,
    Double Amount,
    DateTime DateTime
    ) : IRequest;