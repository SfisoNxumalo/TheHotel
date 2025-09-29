using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<MessageEntity>
    {
        Task<IEnumerable<MessageEntity>> GetMessagesByBookingIdAsync(Guid bookingId);
    }
}
