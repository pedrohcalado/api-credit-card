using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardGenerator.Data;
using CreditCardGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCardGenerator.Repositories
{
  public class UserRepository
  {
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<User> Save(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<User> Get(string email)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
      return user;
    }
  }
}