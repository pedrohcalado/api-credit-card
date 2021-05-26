using CreditCardGenerator.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardGenerator.Controllers
{

  [Route("v1/creditCard")]
  public class CreditCardController : Controller
  {
    private readonly CreditCardRepository _creditCardRepository;
    public CreditCardController(CreditCardRepository creditCardRepository)
    {
      _creditCardRepository = creditCardRepository;
    }

    [HttpGet]
    public string GetCreditCards([FromQuery] string email)
    {
      return "Ok";
    }

    [HttpPost]
    public string CreateCreditCard([FromQuery] string email)
    {
      return email;
    }
  }
}