using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;

namespace TheHotel.Application.Interfaces
{
    public interface IRealTimeNotifier
    {
        Task BroadcastMessage(Guid userId, FetchMessageDTO message);

        Task BroadcastOrderStatusUpdate(Guid userId, UpdateOrderStatusDTO order);
    }
}
