using Microsoft.AspNetCore.SignalR;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;
using TheHotel.Infrastructure.SignalR;

namespace TheHotelAPI.SignalR
{
    public class RealtimeNotifier : IRealTimeNotifier
    {

        private readonly IHubContext<RealtimeHub> _hubContext;

        public RealtimeNotifier(IHubContext<RealtimeHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task BroadcastMessage(Guid userId, FetchMessageDTO message)
        {
            await _hubContext.Clients.Group(userId.ToString().ToLower()).SendAsync("ReceiveMessage", message);
        }

        public async Task BroadcastOrderStatusUpdate(Guid userId, UpdateOrderStatus order)
        {
            await _hubContext.Clients.Group(userId.ToString().ToLower()).SendAsync("OrderStatusUpdated", order);
        }
    }
}
