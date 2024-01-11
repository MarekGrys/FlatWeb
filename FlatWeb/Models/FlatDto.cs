using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Models
{
    public class FlatDto
    {
        public int SquareMetrage { get; set; }
        [Required]
        public int RoomQuantity { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime WhenAdded { get; set; } = DateTime.Now;
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public int? FlatNumber { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
