using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Main.Controllers
{
    public class CardController : ApiControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet("GetCardById/{id}")]
        public async Task<IActionResult> GetCardById(Guid id)
        {
            return Ok(await _cardService.GetCardById(id));
        }
        [HttpGet("GetAllByUserId/{id}")]
        public async Task<IActionResult> GetAllByUserId(Guid id)
        {
            return Ok(await _cardService.GetAllByUserId(id));
        }
        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard(CardCreateModel cardModel)
        {
            var result = await _cardService.CreateCard(cardModel);

            if (result.Errors == null)
            {
                result.Successful = true;
            }
            else
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
