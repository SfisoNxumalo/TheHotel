using System.ComponentModel.DataAnnotations;
using TheHotel.Domain.DTOs.RoomServiceItem;

namespace TheHotel.Domain.DTOs.RoomServiceOrder
{
    public class OrderRoomServiceDTO
    {
        [Required]
        public Guid orderId { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [Required]
        public ICollection<OrderItemDTO> items { get; set; }

        [Required]
        public string? Note { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserContact { get; set; }
        [Required]
        public DateTime? createdAt { get; set; }
        [Required]
        public string? status { get; set;}
    }
}
