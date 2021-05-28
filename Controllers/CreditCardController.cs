using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardGenerator.Models;
using CreditCardGenerator.Repositories;
using CreditCardGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardGenerator.Controllers
{

  [Route("v1/creditCard")]
  public class CreditCardController : Controller
  {
    private readonly CreditCardRepository _creditCardRepository;
    private readonly UserRepository _userRepository;
    public CreditCardController(CreditCardRepository creditCardRepository, UserRepository userRepository)
    {
      _creditCardRepository = creditCardRepository;
      _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCardsByUser([FromQuery] string email)
    {
      var creditCards = await _creditCardRepository.GetCreditCardsByUser(email);
      return Ok(creditCards);
    }

    [HttpPost]
    public async Task<ActionResult<CreditCard>> CreateCreditCard([FromBody] User userData)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        var creditCardNumber = RandomNumberService.GenerateRandomCreditCardNumber();
        var newCreditCard = new CreditCard(creditCardNumber, userData.Email);
        await _creditCardRepository.SaveCreditCard(newCreditCard);

        var user = await _userRepository.Get(userData.Email);

        if (user == null)
        {
          var newUser = new User(userData.Email);
          await _userRepository.Save(newUser);
        }

        return Ok(new {
          message = "Credit card created successfully",
          creditCardNumber = newCreditCard.Number,
          }
        );
      }
      catch
      {
        return BadRequest(new {message = "There was a problem creating the card"});
      }
    }
  }
}