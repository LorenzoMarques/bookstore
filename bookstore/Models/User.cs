using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models
{
    [Table("users")] 
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("active")]
        public bool Active { get; set; } = true;
        [Column("vip")]
        public bool Vip { get; set; } = false;
        [Column("subscription_date")]
        public DateTime? SubscriptionDate { get; set; }

        [Column("subscription_expires_at")]
        public DateTime? SubscriptionExpiresAt { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
