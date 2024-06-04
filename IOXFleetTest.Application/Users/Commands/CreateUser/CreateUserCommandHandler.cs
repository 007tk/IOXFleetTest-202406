using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence.Models;
using MediatR;

namespace IOXFleetTest.Application.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            FirstName = request.Firstname,
            LastName = request.LastName,
            IDNumber = request.IdNumber,
            Email = request.Email,
            Password = request.Password,
            Account = new Account()
            {
             //   AccountBalance = 0
            }
        };

        await _userRepository.CreateUser(user, cancellationToken);
    }
}