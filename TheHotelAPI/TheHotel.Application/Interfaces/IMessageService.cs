using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.NewFolder;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageEntity>> GetMessagesForBookingAsync(Guid bookingId);
        Task<FetchMessageDTO> SendMessageAsync(SendMessageDTO message);
        Task<IEnumerable<FetchMessageDTO>> GetMessagesByUserIdAsync(Guid userId);


    }
}
