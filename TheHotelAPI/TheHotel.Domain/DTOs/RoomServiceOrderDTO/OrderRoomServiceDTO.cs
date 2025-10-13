using TheHotel.Domain.DTOs.RoomServiceItem;

namespace TheHotel.Domain.DTOs.RoomServiceOrder
{
    public class OrderRoomServiceDTO
    {
        public required Guid UserId { get; set; }

        public ICollection<OrderItemDTO> items { get; set; }
    }
}
