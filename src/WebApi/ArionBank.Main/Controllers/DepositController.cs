using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Main.Controllers
{
    public class DepositController : ApiControllerBase
    {
        private readonly IDepositService _depositService;
        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }
        [HttpPost("CreateDeposit")]
        public async Task<IActionResult> CreateDeposit(CreateDepositModel model)
        {
            var result = await _depositService.CreateDeposit(model);

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
        [HttpGet("DepositByUserId/{UserId}")]
        public async Task<IActionResult> DepositByUserId(Guid UserID)
        {
            return Ok(await _depositService.DepositByUserId(UserID));
        }
        [HttpGet("DepositById")]
        public async Task<IActionResult> DepositById(Guid CardId)
        {
            return Ok(await _depositService.DepositById(CardId));
        }
        [HttpGet("ALlDeposit")]
        public async Task<IActionResult> ALlDeposit(Guid CardId)
        {
            return Ok(await _depositService.AllDeposit());
        }
    }
}
