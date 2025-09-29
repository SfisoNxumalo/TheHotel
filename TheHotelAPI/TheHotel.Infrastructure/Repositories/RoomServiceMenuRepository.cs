using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class RoomServiceMenuRepository : GenericRepository<RoomServiceMenuEntity>, IRoomServiceMenuRepository
    {
        private readonly HotelContext _context;

        public RoomServiceMenuRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomServiceMenuEntity>> GetAvailableItemsAsync()
        {
            return await _context.RoomServiceMenu
                .Where(m => m.Available)
                .ToListAsync();
        }
    }
}
