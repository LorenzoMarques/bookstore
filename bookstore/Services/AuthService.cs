using AutoMapper;
using bookstore.Dtos.Auth;
using bookstore.Dtos.User;
using bookstore.Exceptions;
using bookstore.Models;
using bookstore.Repositories;
using System.Text.Json;

namespace bookstore.Services
{
    public class AuthService
    {
        private readonly UsersRepository _usersRepository;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(UsersRepository usersRepository, JwtService jwtService, IMapper mapper) {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public LoginResponseDto Login(LoginDto loginDto)
        {
            User? user = _usersRepository.GetUserByEmail(loginDto.Email);
            if (user is null) {
                throw HttpException.NotFound("User not found");
            }

            Console.WriteLine(JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
            
            if (VerifyPassword(loginDto.Password, user.Password) is false)
            {
                throw HttpException.BadRequest("Invalid credentials");
            }

            string token = _jwtService.GenerateJwt(user);
            var userDto = _mapper.Map<UserDto>(user);


            return new LoginResponseDto
            {
                Token = token,
                User = userDto
            };
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
