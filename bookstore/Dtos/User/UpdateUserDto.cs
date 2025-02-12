using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Dtos.User
{
    public class UpdateUserDto
    {
        [NotEmpty]
        public string? Name { get; set; }

        [NotEmpty]
        [EmailAddress]
        public string? Email { get; set; }

        [NotEmpty]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "The field must be between 6 and 30 characters long.")]
        public string? Password { get; set; }
    }
}
