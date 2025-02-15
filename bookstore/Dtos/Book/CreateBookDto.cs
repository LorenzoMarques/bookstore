using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.User
{
    public class CreateBookDto
    {
        [Required]
        [NotEmpty]
        public string Title { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        public string Description { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        public string Author { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        public string Publisher { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        [DataType(DataType.Date)]
        public DateOnly PublishedDate { get; set; }
        [Required]
        [NotEmpty]
        public long Isbn { get; set; }
        [Required]
        [NotEmpty]
        public string CoverImageUrl { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        public string UrlPdf { get; set; } = string.Empty;
        [Required]
        [NotEmpty]
        public bool Vip { get; set; } = false;
        [Required]
        [NotEmpty]
        public List<string> ListCategories { get; set; } = [string.Empty];
    }
}
