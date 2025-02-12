using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "The field must be between 6 and 30 characters long.")]
        public string Password { get; set; } = string.Empty;
    }
}
