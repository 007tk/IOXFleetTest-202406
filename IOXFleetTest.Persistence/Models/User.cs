using System.ComponentModel.DataAnnotations;

namespace IOXFleetTest.Persistence.Models;

public class User
{
    public int Id { get; set; }
    /// <summary>
    /// Firstname
    /// </summary>
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

    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }
}