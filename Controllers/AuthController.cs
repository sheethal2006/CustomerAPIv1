using Microsoft.AspNetCore.Mvc;
using CustomerAPIv1.Model;
using CustomerAPIv1.Services;


namespace CustomerAPIv1.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public AuthController(TokenService tokenService) { _tokenService = tokenService; }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password")
                return Ok(new { Token = _tokenService.GenerateToken(model.Username) });
            return Unauthorized();
        }
    }
}
