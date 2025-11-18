using Microsoft.AspNetCore.SignalR;

namespace TheHotel.Infrastructure.SignalR
{
    public class RealtimeHub : Hub
    {
        public async Task JoinSpecificRoom(string customerId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, customerId.ToLower());
            Console.WriteLine($"connected with {customerId}");
        }
    }
}
