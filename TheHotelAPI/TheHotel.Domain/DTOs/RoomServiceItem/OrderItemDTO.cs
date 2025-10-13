using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs.RoomServiceItem
{
    public class OrderItemDTO
    {
        [Required]
        public required Guid ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }


    }
}
