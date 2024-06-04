using IOXFleetTest.Application.Users.Commands;

namespace IOXFleetTestApi.Controllers.RequestObjects;

public class CreateUserRequest
{
    public string FirstName { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// ID number
    /// </summary>
    public string IDNumber { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    
    public CreateUserCommand MapToCommand(CreateUserRequest request)
    {
        var command = new CreateUserCommand(
            request.FirstName,
            request.LastName,
            request.IDNumber,
            request.Password,
            request.Email
        );

        return command;
    }
}