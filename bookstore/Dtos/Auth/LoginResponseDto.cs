using bookstore.Dtos.User;

namespace bookstore.Dtos.Auth
{
    public class LoginResponseDto
    {
        public string token { get; set; }
        public UserDto user { get; set; }
    }
}
