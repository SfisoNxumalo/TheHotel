using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces
{
    public interface IRoomServiceOrderRepository : IGenericRepository<RoomServiceOrderEntity>
    {
        Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersByBookingIdAsync(Guid bookingId);

        Task<RoomServiceOrderEntity?> GetOrderWithItemsAsync(Guid orderId);
    }
}
