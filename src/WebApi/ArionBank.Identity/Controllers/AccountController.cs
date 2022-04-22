using ArionBank.Identity.Enums;
using ArionBank.Identity.Exceptions;
using ArionBank.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArionBank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel login)
        {
            var user = await _userManager.FindByNameAsync(login.Login);

            if (user == null)
            {
                return BadRequest(new LoginResult { Successful = false, Error = $"Пользователь с именем { login.Login } не найден" });
            }

            var result = await _signInManager.PasswordSignInAsync(login.Login, login.Password, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Неверное имя пользователя или пароль" });


            user.LastLogin = DateTime.Now;

            await _userManager.UpdateAsync(user);

            var role = await _userManager.GetRolesAsync(user);

            if(role == null)
            {
                return BadRequest(new LoginResult { Successful = false, Error = "Роль не найдена" });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Login),
                new Claim(ClaimTypes.Role, role.FirstOrDefault())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            var newUser = new ApplicationUser
            {
                UserName = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Created = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }

            var resultRole = await _userManager.AddToRoleAsync(newUser, Roles.Basic.ToString());

            if (!resultRole.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }

            return Ok(new RegisterResult { Successful = true });
        }
        [HttpPut("updateUser/{name}")]
        public async Task<IActionResult> UpdateUser(UpdateUser updateUser, string name)
        {
            var user = await _userManager.FindByNameAsync(name.Trim());

            if (user == null)
            {
                throw new NotFoundException(name);
            }

            user.Name = updateUser.Name;
            user.Surname = updateUser.Surname;
            user.Patronymic = updateUser.Patronymic;
            user.UserName = updateUser.Login;

            user.Updated = DateTime.Now;

            await _userManager.UpdateAsync(user);

            return Ok(new UpdateResult { Successful = true });
        }
    }
}
