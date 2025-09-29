using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceOrderService
    {
        Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersForBookingAsync(Guid bookingId);
        Task<RoomServiceOrderEntity> PlaceOrderAsync(RoomServiceOrderEntity order);
        Task UpdateOrderStatusAsync(Guid orderId, string status);
    }
}
