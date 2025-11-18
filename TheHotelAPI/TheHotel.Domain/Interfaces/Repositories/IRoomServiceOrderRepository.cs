using TheHotel.Domain.DTOs.RoomServiceOrder;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces.Repositories
{
    public interface IRoomServiceOrderRepository : IGenericRepository<RoomServiceOrderEntity>
    {
        Task<IEnumerable<OrderRoomServiceDTO>> GetOrdersByUserIdAsync(Guid userId);

        Task<OrderRoomServiceDTO> GetOrderByIdAsync(Guid orderId);

        Task<RoomServiceOrderEntity?> GetOrderWithItemsAsync(Guid orderId);
    }
}
