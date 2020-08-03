using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Requests;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        public AuthController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authenticator.Register(request);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                return new BadRequestObjectResult(new { Message = "Error while registering user", Errors = dictionary });
            }
            return Ok(new { Message = "User Registration Successful" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticator.Login(request);
            if (result == null)
            {
                return new UnauthorizedObjectResult(new { Message = "Authorization failed" });
            }
            return Ok(new { Token = result, Message = "Logged in successfully" });
        }
    }
}
