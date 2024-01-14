using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Models
{
    public class CreateUserDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Email { get; set; } = null;
    }
}
