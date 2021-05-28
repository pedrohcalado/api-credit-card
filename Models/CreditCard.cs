using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCardGenerator.Models
{
  public class CreditCard
  {
    public CreditCard(string number, string email)
    {
      Number = number;
      Email = email;
      CreatedAt = DateTime.Now;
    }
    [Key]
    public int Id { get; private set; }
    public string Number { get; private set; }
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
  }
}