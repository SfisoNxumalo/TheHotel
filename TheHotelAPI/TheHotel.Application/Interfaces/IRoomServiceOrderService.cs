using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceOrderService
    {
        Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersForBookingAsync(Guid bookingId);
        Task<RoomServiceOrderEntity> PlaceOrderAsync(OrderRoomServiceDTO order);
        Task UpdateOrderStatusAsync(Guid orderId, string status);
    }
}
