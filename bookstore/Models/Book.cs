using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("author")]
        public string Author { get; set; } = string.Empty;

        [Column("publisher")]
        public string Publisher { get; set; } = string.Empty;

        [Column("published_date")]
        public DateTime? PublishedDate { get; set; }

        [Column("isbn")]
        public long Isbn { get; set; }

        [Column("cover_image_url")]
        public string CoverImageUrl { get; set; } = string.Empty;

        [Column("url_pdf")]
        public string UrlPdf { get; set; } = string.Empty;

        [Column("vip")]
        public bool Vip { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}