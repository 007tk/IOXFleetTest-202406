using System.ComponentModel.DataAnnotations.Schema;

namespace IOXFleetTest.Persistence.Models;

public class Account
{
   /// <summary>
   /// Account id.
   /// </summary>
   public int Id { get; set; }
   
   /// <summary>
   /// Account balance
   /// </summary>
  public double AccountBalance { get; set; }

   /// <summary>
   /// user id
   /// </summary>
   public int UserId { get; set; }

   /// <summary>
   /// user.
   /// </summary>
    public User User { get; set; }
}