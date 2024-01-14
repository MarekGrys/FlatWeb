using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Models
{
    public class UpdateAddress
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        public int? FlatNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
