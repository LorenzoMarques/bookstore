using bookstore.Data;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Repositories
{
    public class BooksRepository
    {

        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = _context.Books
                .Include(book => book.BookCategories)
                .ThenInclude(bookCategory => bookCategory.Category) 
                .ToList();

            return books;
        }

        public Book? GetBookById(int id) 
        {
            Book? book = _context.Books
                .Include(book => book.BookCategories)
                .ThenInclude(bookCategory => bookCategory.Category)
                .FirstOrDefault(book => book.Id == id);

            return book;
        }

        public Book CreateBook(Book book) 
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book UpdateBook(Book book) 
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }

        public async Task<bool> DeleteBook(int id) 
        {
            Book? book = GetBookById(id);
            if (book is null) {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
