using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BookingEntity?> GetActiveBookingForUserAsync(Guid userId)
        {   return await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.UserId.Equals(userId) && b.Status == "Active");
        }
    }
}
