using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models
{
    [Table("book_categories")]
    public class BookCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("book_id")]
        public int BookId { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; } = new Book();

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = new Category();
    }
}