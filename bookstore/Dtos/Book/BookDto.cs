using bookstore.Dtos.Category;

namespace bookstore.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }
        public long Isbn { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public string UrlPdf { get; set; } = string.Empty;
        public bool Vip { get; set; } = false;
        public List<CategoryDto> BookCategories { get; set; } = [new CategoryDto()];
    }
}
