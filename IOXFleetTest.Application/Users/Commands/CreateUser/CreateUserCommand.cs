using MediatR;

namespace IOXFleetTest.Application.Users.Commands;

public record CreateUserCommand(
    string Firstname,
    string LastName,
    string IdNumber,
    string Password,
    string Email) : IRequest;