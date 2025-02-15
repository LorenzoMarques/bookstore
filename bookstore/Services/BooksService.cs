using bookstore.Repositories;
using bookstore.Models;
using bookstore.Exceptions;
using bookstore.Dtos.User;
using AutoMapper;
using bookstore.Dtos.Book;

namespace bookstore.Services
{
    public class BooksService
    {
        BooksRepository _booksRepository;
        CategoryRepository _categoriesRepository;
        private readonly IMapper _mapper;
        BookCategoriesRepository _bookCategoriesRepository;

        public BooksService(BooksRepository booksRepository, IMapper mapper, CategoryRepository categoriesRepository, BookCategoriesRepository bookCategoriesRepository)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
            _bookCategoriesRepository = bookCategoriesRepository;
        }

        public List<BookDto> GetBooks()
        {
            List<Book> books = _booksRepository.GetBooks();
            List<BookDto> bookdtoResponse = _mapper.Map<List<BookDto>>(books);

            return bookdtoResponse;
        }

        public BookDto GetBookById(int id)
        {
            Book? book = _booksRepository.GetBookById(id);

            if (book is null)
            {
                throw HttpException.NotFound("Book not found");
            }

            BookDto bookdtoResponse = _mapper.Map<BookDto>(book);


            return bookdtoResponse;
        }

        public BookDto UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            Book? book = _booksRepository.GetBookById(id);
            if(book is null)
            {
                throw HttpException.NotFound("Book not found");
            }

            _mapper.Map(updateBookDto, book);

            book.UpdatedAt = DateTime.UtcNow;

            Book updatedBook = _booksRepository.UpdateBook(book);

            BookDto bookdtoResponse = _mapper.Map<BookDto>(updatedBook);

            return bookdtoResponse;
        }

        public async Task<bool> DeleteBook(int id)
        {
            bool userDeleted = await _booksRepository.DeleteBook(id);

            if (userDeleted == false)
            {
                throw HttpException.NotFound("Book not found");
            }

            return true;

        }

        public BookDto CreateBook(CreateBookDto createBookDto)
        {
            Book book = _mapper.Map<Book>(createBookDto);

            List<Category> categories = new List<Category>();

            foreach (string categoryName in createBookDto.ListCategories)
            {
                Category category = _categoriesRepository.FindOrCreateCategory(categoryName);
                categories.Add(category);
            }


            _booksRepository.CreateBook(book);

            foreach (Category category in categories)
            {
                BookCategory bookCategory = _bookCategoriesRepository.CreateBookCategory(new BookCategory { Book = book, Category = category });
            }

            BookDto bookdtoResponse = _mapper.Map<BookDto>(book);


            return bookdtoResponse;
        }
    }
}
