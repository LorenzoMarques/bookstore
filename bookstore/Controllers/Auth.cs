using bookstore.Dtos.Auth;
using bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;


        public AuthController(AuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            LoginResponseDto loginResponse = _authService.Login(loginDto) ;

            return Ok(loginResponse);
        }
    }
}
