using System;
using System.Collections.Generic;

namespace CreditCardGenerator.Models
{
  public class User
  {
    public int Id { get; private set; }
    public IEnumerable<CreditCard> CreditCards { get; private set; }
  }
}