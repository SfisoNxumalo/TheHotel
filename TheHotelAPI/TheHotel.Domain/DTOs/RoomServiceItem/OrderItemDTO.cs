using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs.RoomServiceItem
{
    public class OrderItemDTO
    {
        [Required]
        public required Guid Id { get; set; }
        [Required]
        public required string ItemName { get; set; } = null!;
        [Required]
        public required decimal Price { get; set; }
        [Required]
        public required int Quantity { get; set; }
        [Required]
        public required string note { get; set; }
    }
}
