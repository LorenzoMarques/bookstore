using AutoMapper;
using bookstore.Dtos.User;
using bookstore.Exceptions;
using bookstore.Models;
using bookstore.Repositories;



namespace bookstore.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;
        private readonly RolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public UsersService(UsersRepository usersRepository, IMapper mapper, RolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _mapper = mapper;

        }

        public List<UserDto> GetUsers()
        {
            List<User> users = _usersRepository.GetUsers();
            List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }

        public UserDto GetUseById(int id)
        {
            User? user = _usersRepository.GetUserById(id);
            if (user is null)
            {
                throw HttpException.NotFound("User not found");
            }

            UserDto userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public UserDto CreateUser(CreateUserDto createUserDto) 
        {
            User? findUser = _usersRepository.GetUserByEmail(createUserDto.Email);

            if(findUser is not null)
            {
                throw HttpException.BadRequest("User already exists");
            }

            Role? findRole = _rolesRepository.GetRoleByName("User");

            if (findRole is null)
            {
                throw HttpException.NotFound("Role not found");
            }

            User user = new User{
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = HashPassword(createUserDto.Password),
                Active = true,
                Role = findRole,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }; 
            User newUser = _usersRepository.CreateUser(user);

            UserDto userDto = _mapper.Map<UserDto>(newUser);


            return userDto;

        }

        public UserDto UpdateUser(UpdateUserDto updateUserDto, int userId)
        {

            User? findUser = _usersRepository.GetUserById(userId);

            if (findUser is null) {
                throw HttpException.NotFound("User not found");
            }

            findUser = UpdateUserFields(findUser, updateUserDto);


            findUser.UpdatedAt = DateTime.UtcNow;

            User updatedUser = _usersRepository.UpdateUser(findUser);

            UserDto userDto = _mapper.Map<UserDto>(updatedUser);


            return userDto;
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


        private User UpdateUserFields(User user, UpdateUserDto updateUserDto)
        {
            if (!string.IsNullOrEmpty(updateUserDto.Name)) user.Name = updateUserDto.Name;
            if (!string.IsNullOrEmpty(updateUserDto.Email)) user.Email = updateUserDto.Email;
            if (!string.IsNullOrEmpty(updateUserDto.Password)) user.Password = updateUserDto.Password; 

            return user;
        }

    }
}
