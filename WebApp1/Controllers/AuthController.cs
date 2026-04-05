using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.DTO;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identyUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var identityResult = await UserManager.CreateAsync(identyUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Adding roles to the user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await UserManager.AddToRolesAsync(identyUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered successfully");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }


        //POST: api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await UserManager.FindByEmailAsync(loginRequestDTO.usename);

            if (user != null)
            {
                var isPasswordValid = await UserManager.CheckPasswordAsync(user, loginRequestDTO.password);

                if (isPasswordValid)
                {
                    //Token generation logic will be here

                    return Ok();
                }
            }

            return BadRequest("Invalid username or password");
        }
    }
}
