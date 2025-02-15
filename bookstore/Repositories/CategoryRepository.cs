using bookstore.Data;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category FindOrCreateCategory(string name)
        {
            Category? findCategory =  _context.Categories.FirstOrDefault(category => category.Name == name);

            if (findCategory is not null)
            {
                return findCategory;
            }

            Category category = new Category { Name = name };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

    }
}
