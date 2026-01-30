using TheHotel.Domain.DTOs.RoomServiceOrder;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceOrderService
    {
        Task<IEnumerable<OrderRoomServiceDTO>> GetOrdersByUserIdAsync(Guid orderId);
        Task<Guid> PlaceOrderAsync(OrderRoomServiceDTO order);
        Task UpdateOrderStatusAsync(Guid orderId, string status);
        Task<OrderRoomServiceDTO> GetOrderById(Guid orderId);

        Task<IEnumerable<OrderRoomServiceDTO>> GetAllOrdersAsync();

    }
}
