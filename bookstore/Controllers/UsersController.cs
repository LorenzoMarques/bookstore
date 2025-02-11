using Microsoft.AspNetCore.Mvc;
using bookstore.Services;
using bookstore.Models;
using bookstore.Dtos.User;

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
            List<UserDto> users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            UserDto user = _usersService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {

            UserDto user = _usersService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.id }, user);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto userDto, int id) 
        {
            UserDto user = _usersService.UpdateUser(userDto, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id) 
        {
            await _usersService.DeleteUser(id);
            return NoContent();
        }
    }
}
