using bookstore.Dtos.User;
using bookstore.Exceptions;
using bookstore.Models;
using bookstore.Repositories;


namespace bookstore.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;



        public UsersService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<User> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            User? user = _usersRepository.GetUserById(id);
            if (user is null)
            {
                throw HttpException.NotFound("User not found");
            }

            return user;
        }

        public User CreateUser(CreateUserDto userDto) 
        {
            User? findUser = _usersRepository.GetUserByEmail(userDto.email);

            if(findUser is not null)
            {
                throw HttpException.BadRequest("User already exists");
            }

            User user = new User{
                name = userDto.name,
                email = userDto.email,
                password = HashPassword(userDto.password),
                active = true,
                vip = false,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow,
            }; 
            User newUser = _usersRepository.CreateUser(user);

            return newUser;

        }

        public User UpdateUser(UpdateUserDto userDto, int userId)
        {

            User? findUser = _usersRepository.GetUserById(userId);

            if (findUser is null) {
                throw HttpException.NotFound("User not found");
            }

            findUser = UpdateUserFields(findUser, userDto);

            Console.WriteLine(findUser.name);
            findUser.updated_at = DateTime.UtcNow;
            return _usersRepository.UpdateUser(findUser);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            bool userDeleted = await _usersRepository.DeleteUserById(userId);

            if(userDeleted == false)
            {
                throw HttpException.NotFound("User not found");
            }

            return true;

        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private User UpdateUserFields(User user, UpdateUserDto updateUserDto)
        {
            if (!string.IsNullOrEmpty(updateUserDto.name)) user.name = updateUserDto.name;
            if (!string.IsNullOrEmpty(updateUserDto.email)) user.email = updateUserDto.email;
            if (!string.IsNullOrEmpty(updateUserDto.password)) user.password = updateUserDto.password; 

            return user;
        }

    }
}
