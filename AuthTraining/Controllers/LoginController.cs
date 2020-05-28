using AuthTraining.Models;
using AuthTraining.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly IIdentityProvider _identityProvider;

        public LoginController(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserLoginRequest userLogin)
        {
            var token = _identityProvider.AuthenticateUser(userLogin.UserName, userLogin.Password);
            if (string.IsNullOrWhiteSpace(token))
                return Unauthorized();

            return Ok(new {token});
        }
    }
}