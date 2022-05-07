using ArionBank.Identity.Models;
using ArionBank.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArionBank.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpGet("GetAllUser/{filter}")]
        public async Task<IActionResult> GetAllUser(string? filter)
        {
            return Ok(await _managerService.GetAllUser(filter));
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _managerService.GetAllUser());
        }
        [HttpGet("GetAvatar/{name}")]
        public async Task<IActionResult> GetAvatar(string name)
        {
            return Ok(await _managerService.GetAvatar(name));
        }
        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            return Ok(await _managerService.GetUserByName(name));
        }
        [HttpDelete("DeleteUserByName/{name}")]
        public async Task<IActionResult> DeleteUserByName(string name)
        {
            return Ok(await _managerService.DeleteUserByName(name));
        }
    }
}
