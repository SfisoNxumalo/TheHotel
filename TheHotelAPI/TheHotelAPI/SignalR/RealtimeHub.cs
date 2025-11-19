using Microsoft.AspNetCore.SignalR;
using TheHotel.Application.ServiceCustomExceptions;

namespace TheHotel.Infrastructure.SignalR
{
    public class RealtimeHub : Hub
    {

        private readonly ILogger<RealtimeHub> _logger;

        public RealtimeHub(ILogger<RealtimeHub> logger) { 
            _logger = logger;
        }

        public async Task JoinSpecificRoom(string customerId)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, customerId.ToLower());
                Console.WriteLine($"connected with {customerId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error broadcasting joining user to group with exception: {ex.Message}");
                throw new RealTimeNotificationException("Failed to send a realtime order update.");
            }
            
        }
    }
}
