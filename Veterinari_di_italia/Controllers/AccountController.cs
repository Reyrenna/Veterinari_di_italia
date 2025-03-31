using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Settings;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Jwt _jwtSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            IOptions<Jwt> jwtOptions,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager
        )
        {
            _jwtSettings = jwtOptions.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUser)
        {
            try
            {
                var newUser = new ApplicationUser()
                {
                    Email = createUser.Email,
                    UserName = createUser.Email,
                    Nome = createUser.Nome,
                    Cognome = createUser.Cognome,
                    PhoneNumber = createUser.Telefono,
                    CodiceFiscale = createUser.CodiceFiscale,
                };

                var result = await _userManager.CreateAsync(newUser, createUser.Password);

                if (!result.Succeeded)
                {
                    return BadRequest();
                }

                // Ensure the user is fully saved and tracked
                await _userManager.UpdateAsync(newUser);

                var user = await _userManager.FindByEmailAsync(newUser.Email);

                //await _userManager.AddToRoleAsync(newUser, "Admin");
                await _userManager.AddToRoleAsync(newUser, "User");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
