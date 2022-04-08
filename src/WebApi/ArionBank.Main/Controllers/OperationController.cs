﻿using ArionBank.Application.Common.Interfaces;
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
            if(result.Errors == null)
            {
                result.Successful = true;
            }
            else
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }
        [HttpGet("AllOperationHistory")]
        public async Task<IActionResult> AllOperationHistory(OperationModel model)
        {
            return Ok(_operationService.AllOperationHistory());
        }
    }
}
