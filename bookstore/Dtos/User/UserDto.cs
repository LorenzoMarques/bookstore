using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.User
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public bool active { get; set; } = true;
        public bool vip { get; set; } = false;
        public DateTime? subscription_date { get; set; }
        public DateTime? subscription_expires_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
