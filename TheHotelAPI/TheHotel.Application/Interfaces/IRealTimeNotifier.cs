using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;

namespace TheHotel.Application.Interfaces
{
    public interface IRealTimeNotifier
    {
        Task BroadcastMessage(Guid userId, string message);

        Task BroadcastOrderStatusUpdate(Guid userId, UpdateOrderStatus order);
    }
}
