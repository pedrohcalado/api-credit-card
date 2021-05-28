using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardGenerator.Data;
using CreditCardGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCardGenerator.Repositories
{
  public class CreditCardRepository
  {
    private readonly DataContext _context;
    public CreditCardRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CreditCard>> GetCreditCardsByUser(string email)
    {
      var cards = await _context.CreditCards.Where(x => x.Email == email).ToListAsync();
      return cards.OrderByDescending(c => c.CreatedAt);
    }

    public async Task<CreditCard> SaveCreditCard(CreditCard creditCard)
    {
      _context.CreditCards.Add(creditCard);
      await _context.SaveChangesAsync();
      return creditCard;
    }
  }
}