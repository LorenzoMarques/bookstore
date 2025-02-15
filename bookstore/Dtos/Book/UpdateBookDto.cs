using bookstore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Dtos.User
{
    public class UpdateBookDto
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
        public string? Publisher { get; set; } = string.Empty;
        public DateOnly? PublishedDate { get; set; }
        public long? Isbn { get; set; }
        public string? CoverImageUrl { get; set; } = string.Empty;
        public string? UrlPdf { get; set; } = string.Empty;
        public bool? Vip { get; set; } = false;
    }
}
