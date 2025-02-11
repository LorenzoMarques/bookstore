using bookstore.Dtos.Auth;
using bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly JwtService _jwtService;
        private readonly AuthService _authService;


        public AuthController(JwtService jwtService, AuthService authService)
        {
            _jwtService = jwtService;
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
