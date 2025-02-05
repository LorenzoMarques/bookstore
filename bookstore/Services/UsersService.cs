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
    }
}
