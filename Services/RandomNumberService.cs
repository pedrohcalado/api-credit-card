using System;

namespace CreditCardGenerator.Services
{
  public static class RandomNumberService
  {
    public static string GenerateRandomCreditCardNumber()
    {
      var rdn = new Random();
      var creditCardNumberSize = 16;
      string creditCardNumber = "";

      for (int i = 0; i < creditCardNumberSize; i++)
      {
        creditCardNumber += rdn.Next(9);
      }

      return creditCardNumber;
    }
  }
}