using bookstore.Data;
using bookstore.Models;


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
    }
}
