using Microsoft.AspNetCore.Mvc;
using bookstore.Services;
using bookstore.Models;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet] 
        public IActionResult GetUser()
        {
            List<User> users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _usersService.GetUserById(id);
            return Ok(user);
        }
    }
}
