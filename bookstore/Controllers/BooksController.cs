using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Services;
using bookstore.Dtos.User;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
           _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] CreateBookDto book)
        {
            var createdBook = _booksService.CreateBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
        {
            var updatedBook = _booksService.UpdateBook(id, updateBookDto);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {

            await _booksService.DeleteBook(id);
            return NoContent();

        }
    }
}
