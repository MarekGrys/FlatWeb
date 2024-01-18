using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FlatWeb.Entities
{
    public class User
    {
        public int Id { get; set; }
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
        public string? Email { get; set; }

        public string? Favourites { get; set; }

        public virtual ICollection<Flat> Flats { get; set; }

    }
}
