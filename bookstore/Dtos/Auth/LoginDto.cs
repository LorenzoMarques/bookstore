using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.Auth
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "The field must be between 6 and 30 characters long.")]
        public string password { get; set; }
    }
}
