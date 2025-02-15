using bookstore.Data;
using bookstore.Models;

namespace bookstore.Repositories
{
    public class BookCategoriesRepository
    {

        private readonly AppDbContext _context;

        public BookCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public BookCategory CreateBookCategory(BookCategory bookCategory)
        {
            _context.BookCategories.Add(bookCategory);
            _context.SaveChanges();
            return bookCategory;
        }
    }
}
