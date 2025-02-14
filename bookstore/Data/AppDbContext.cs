using Microsoft.EntityFrameworkCore;
using bookstore.Models;
using System.Collections.Generic;

namespace bookstore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books{  get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
