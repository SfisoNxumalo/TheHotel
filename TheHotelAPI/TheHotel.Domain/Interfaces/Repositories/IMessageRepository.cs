using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces.Repositories
{
    public interface IMessageRepository : IGenericRepository<MessageEntity>
    {
        Task<IEnumerable<MessageEntity>> GetMessagesByBookingIdAsync(Guid bookingId);
        Task<FetchMessageDTO> GetMessageByIdAsync(Guid Id);

        Task<IEnumerable<FetchMessageDTO>> GetMessagesByUserIdAsync(Guid userId);
    }
}
