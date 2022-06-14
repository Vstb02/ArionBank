using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Main.Controllers
{
    public class CreditController : ApiControllerBase
    {
        private readonly ICreditService _creditService;
        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet("GetAllCreditByUserId/{UserId}")]
        public async Task<IActionResult> GetAllCreditByUserId(Guid UserId)
        {
            return Ok(await _creditService.GetAllCreditByUserId(UserId));
        }
        [HttpPost("CreateCredit")]
        public async Task<IActionResult> CreateCredit(CreateCreditModel model)
        {
            var result = await _creditService.CreateCredit(model);

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
        [HttpGet("GetAllCredit")]
        public async Task<IActionResult> GetAllCredit()
        {
            return Ok(await _creditService.GetAllCredit());
        }
        [HttpPost("ApprovedCredit")]
        public async Task<IActionResult> ApprovedCredit(ApprovedCreditModel model)
        {
            return Ok(await _creditService.ApprovedCredit(model));
        }
    }
}
