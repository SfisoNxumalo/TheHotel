using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        private readonly HotelContext _context;

        public MessageRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageEntity>> GetMessagesByBookingIdAsync(Guid bookingId)
        {
            return await _context.Messages
                        .Include(m => m.SenderUser)
                        .Include(m => m.SenderStaff)
                        //.Where(m => m.BookingId == bookingId)
                        .OrderBy(m => m.CreatedDate)
                        .ToListAsync();
        }
            
    }
}
