using bookstore.Data;
using bookstore.Dtos.User;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;


namespace bookstore.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            User? user = _context.Users.Find(id);
            return user;
      
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.Include(user => user.Role).FirstOrDefault(user => user.Email == email);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

         public async Task<bool> DeleteUserById(int id)
        {
            User? user = _context.Users.Find(id);

            if(user is null) 
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();


            return true;
        }

    }
}
