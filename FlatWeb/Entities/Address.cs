using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        public int? FlatNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }

        //public int FlatID { get; set; }
        //public virtual Flat Flat { get; set; }
    }
}
