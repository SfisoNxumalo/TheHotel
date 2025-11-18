using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<MessageEntity>
    {
        Task<IEnumerable<MessageEntity>> GetMessagesByBookingIdAsync(Guid bookingId);
        Task<FetchMessageDTO> GetMessageByBookingIdAsync(Guid Id);

        Task<IEnumerable<FetchMessageDTO>> GetMessagesByUserIdAsync(Guid userId);
    }
}
