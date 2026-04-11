using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.DTO;
using WebApp1.Repositories;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public UserManager<IdentityUser> userManager { get; set; }
        public ITokenRepository tokenRepository { get; set; }

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        
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

            var identityResult = await userManager.CreateAsync(identyUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Adding roles to the user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identyUser, registerRequestDTO.Roles);

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
            var user = await userManager.FindByEmailAsync(loginRequestDTO.username);

            if (user != null)
            {
                var isPasswordValid = await userManager.CheckPasswordAsync(user, loginRequestDTO.password);
                if (isPasswordValid)
                {
                    //Get user roles
                    var userRoles = await userManager.GetRolesAsync(user);

                    //Create Token
                    if (userRoles != null) { 
                        var jwtToken = tokenRepository.CreateJWTToken(user, userRoles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Invalid username or password");
        }
    }
}
