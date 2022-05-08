using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Main.Controllers
{
    public class OperationController : ApiControllerBase
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("InfestFreeTransfer")]
        public async Task<IActionResult> InfestFreeTransfer(OperationModel model)
        {
            var result = await _operationService.InfestFreeTransfer(model);
            if(result.Error == null)
            {
                result.Successful = true;
            }
            else
            {
                BadRequest(result.Error);
            }
            return Ok(result);
        }
        [HttpPost("TransferWithPercent")]
        public async Task<IActionResult> TransferWithPercent(OperationModel model)
        {
            var result = await _operationService.TransferWithPercent(model);
            if (result.Error == null)
            {
                result.Successful = true;
            }
            else
            {
                BadRequest(result.Error);
            }
            return Ok(result);
        }
        [HttpGet("AllOperationHistory")]
        public async Task<IActionResult> AllOperationHistory()
        {
            return Ok(await _operationService.AllOperationHistory());
        }
        [HttpPost("OperationHistoryByUser")]
        public async Task<IActionResult> OperationHistoryByUser(UserOperationModel model)
        {
            return Ok(await _operationService.OperationHistoryByUser(model));
        }
    }
}
