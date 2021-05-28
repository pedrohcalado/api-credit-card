using System.ComponentModel.DataAnnotations;

namespace CreditCardGenerator.Models
{
  public class User
  {
    public User(string email)
    {
      Email = email;
    }
    [Key]
    public int Id { get; private set; }
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; private set; }
  }
}