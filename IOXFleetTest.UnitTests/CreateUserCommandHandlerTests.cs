using IOXFleetTest.Application.Users.Commands;
using IOXFleetTest.Domain.Repositories;
using IOXFleetTest.Persistence.Models;
using Moq;
using NUnit.Framework;

namespace IOXFleetTest.UnitTests;

public class CreateUserCommandHandlerTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private CreateUserCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new CreateUserCommandHandler(_userRepositoryMock.Object);
    }

    [Test]
    public async Task Handle_ShouldCallCreateUserOnRepository()
    {
        // Arrange
        var command = new CreateUserCommand
        (
           "John",
           "Doe",
           "123456789",
           "Password123",
           "john.doe@example.com" 
        );
        
        var cancellationToken = CancellationToken.None;

        // Act
        await _handler.Handle(command, cancellationToken);

        // Assert
        _userRepositoryMock.Verify(repo => repo.CreateUser(It.Is<User>(user =>
            user.FirstName == command.Firstname &&
            user.LastName == command.LastName &&
            user.IDNumber == command.IdNumber &&
            user.Email == command.Email &&
            user.Password == command.Password &&
            user.Account != null
        ), cancellationToken), Times.Once);
    }
}