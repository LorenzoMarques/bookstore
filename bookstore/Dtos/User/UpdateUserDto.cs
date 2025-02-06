using System.ComponentModel.DataAnnotations;

namespace bookstore.Dtos.User
{
    public class UpdateUserDto
    {
        [NotEmpty]
        [MinLength(1)]
        public string? name { get; set; }   

        [NotEmpty]
        [EmailAddress]
        public string? email { get; set; }

        [NotEmpty]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "The field must be between 6 and 30 characters long.")]
        public string? password { get; set; }
    }
}
