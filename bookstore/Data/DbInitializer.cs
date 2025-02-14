using bookstore.Models;

namespace bookstore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role { Name = "Admin" },
                new Role { Name = "User" },
                new Role { Name = "VIP" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            if (!context.Users.Any(u => u.Email == "admin@email.com"))
            {
                var adminRole = context.Roles.First(r => r.Name == "Admin");
                var adminUser = new User
                {
                    Name = "Admin",
                    Email = "admin@email.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("senha_segura"),
                    Role = adminRole,
                    Active = true
                };

                context.Users.Add(adminUser);

                context.SaveChanges();
            }
        }
    }
}