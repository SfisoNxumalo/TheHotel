using TheHotel.Domain.DTOs.RoomServiceItem;

namespace TheHotel.Domain.DTOs.RoomServiceOrder
{
    public class OrderRoomServiceDTO
    {
        public Guid orderId { get; set; }
        public required Guid UserId { get; set; }

        public ICollection<OrderItemDTO> items { get; set; }

        public string? Note { get; set; }
        public string? UserName { get; set; }
        public string? UserContact { get; set; }

        public DateTime? createdAt { get; set; }

        public string? status { get; set;}
    }
}
