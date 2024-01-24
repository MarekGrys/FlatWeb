using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Models
{
    public class UpdateFlat
    {
        [Required]
        public int SquareMetrage { get; set; }
        [Required]
        public int RoomQuantity { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public DateTime WhenUpdated { get; set; } = DateTime.Now;
    }
}
