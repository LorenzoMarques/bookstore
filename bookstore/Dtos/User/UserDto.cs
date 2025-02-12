using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public bool Vip { get; set; } = false;
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? SubscriptionExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
