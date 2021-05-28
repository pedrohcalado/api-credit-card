using CreditCardGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCardGenerator.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
            : base(options)
    {

    }

    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<User> Users { get; set; }

  }
}