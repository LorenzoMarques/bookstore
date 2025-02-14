using Microsoft.AspNetCore.Mvc;
using bookstore.Services;
using bookstore.Models;
using bookstore.Dtos.User;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles="Admin")]
        public IActionResult GetUser()
        {
            List<UserDto> users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            UserDto user = _usersService.GetUseById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {

            UserDto user = _usersService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult UpdateUser([FromBody] UpdateUserDto userDto, int id) 
        {
            UserDto user = _usersService.UpdateUser(userDto, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserById(int id) 
        {
            await _usersService.DeleteUser(id);
            return NoContent();
        }
    }
}
