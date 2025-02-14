using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookstore.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}