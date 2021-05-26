using System;
using System.Collections.Generic;

namespace CreditCardGenerator.Models
{
  public class CreditCard
  {
    public int Id { get; private set; }
    public int Number { get; private set; }
    public User User { get; private set; }
  }
}