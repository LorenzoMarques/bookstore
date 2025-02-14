using bookstore.Data;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Repositories
{
    public class RolesRepository
    {

        private readonly AppDbContext _context;

        public RolesRepository(AppDbContext context)
        {
            _context = context;
        }
        public Role? GetRoleByName(string name)
        {
            Role? role = _context.Roles.FirstOrDefault(role => role.Name == name);
            return role;

        }
    }
}
