using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models
{
    [Table("users")] 
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        public bool active { get; set; } = true;
        public bool vip { get; set; } = false;
        public DateTime? subscription_date { get; set; }
        public DateTime? subscription_expires_at { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public DateTime updated_at { get; set; } = DateTime.UtcNow;
    }
}
