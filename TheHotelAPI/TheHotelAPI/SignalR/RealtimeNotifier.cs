using Microsoft.AspNetCore.SignalR;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.RoomServiceOrderDTO;
using TheHotel.Infrastructure.SignalR;

namespace TheHotelAPI.SignalR
{

    public class RealtimeNotifier : IRealTimeNotifier
    {

        private readonly IHubContext<RealtimeHub> _hubContext;
        private readonly ILogger<RealtimeNotifier> _logger;

        public RealtimeNotifier(IHubContext<RealtimeHub> hubContext, ILogger<RealtimeNotifier> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }
        public async Task BroadcastMessage(Guid userId, FetchMessageDTO message)
        {
            try
            {
                await _hubContext.Clients
                    .Group(userId.ToString().ToLower())
                    .SendAsync("ReceiveMessage", message);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error broadcasting message: {ex.Message}");
            }
        }

        public async Task BroadcastOrderStatusUpdate(Guid userId, UpdateOrderStatusDTO order)
        {
            try
            {
                await _hubContext.Clients
                    .Group(userId.ToString().ToLower())
                    .SendAsync("OrderStatusUpdated", order);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error broadcasting order: {ex.Message}");
            }
            
        }
    }
}
