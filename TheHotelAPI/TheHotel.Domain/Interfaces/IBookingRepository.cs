using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<BookingEntity>
    {
        Task<BookingEntity?> GetActiveBookingForUserAsync(Guid userId);
    }
}
