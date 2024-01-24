using System.ComponentModel.DataAnnotations;

namespace FlatWeb.Entities
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SquareMetrage { get; set; }
        [Required]
        public int RoomQuantity { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime WhenAdded { get; set; }

        public DateTime? WhenUpdated { get; set; } = null;

        [Required]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
