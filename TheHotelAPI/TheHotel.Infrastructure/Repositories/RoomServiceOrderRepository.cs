using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class RoomServiceOrderRepository : GenericRepository<RoomServiceOrderEntity>, IRoomServiceOrderRepository
    {
        private readonly HotelContext _context;

        public RoomServiceOrderRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomServiceOrderEntity>> GetOrdersByBookingIdAsync(Guid bookingId)
        {
            return await _context.RoomServiceOrders
                .Include(o => o.Items)
                .ThenInclude(i => i.Item)
                .Where(o => o.BookingId == bookingId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();
        }


        public async Task<RoomServiceOrderEntity?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _context.RoomServiceOrders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
