using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Main.Controllers
{
    public class CreditController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly ICreditService _creditService;
        public CreditController(IApplicationDbContext context,
            ICreditService creditService)
        {
            _context = context;
            _creditService = creditService;
        }
        [HttpGet("CreateCredit")]
        public async Task<IActionResult> CreateCredit(CreateCreditModel model)
        {
            var result = await _creditService.CreateCredit(model);

            if (result.Errors == null)
            {
                result.Successful = true;
            }

            return Ok(result);
        }
        [HttpGet("GetAllCredit")]
        public async Task<IActionResult> GetAllCredit()
        {
            return Ok(await _creditService.GetAllCredit());
        }
        [HttpGet("ApprovedCredit")]
        public async Task<IActionResult> ApprovedCredit(ApprovedCreditModel model)
        {
            return Ok(await _creditService.ApprovedCredit(model));
        }
    }
}
