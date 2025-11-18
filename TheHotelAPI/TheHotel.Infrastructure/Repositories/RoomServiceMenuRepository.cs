using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;
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

        public async Task<IEnumerable<MenuItemDTO>> GetAvailableItemsAsync()
        {
            return await _context.RoomServiceMenu
                .Where(m => m.Available)
                .Select(item => new MenuItemDTO
                {
                    Id = item.Id,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    Available = item.Available,

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItemDTO>> GetMenuItemsByIdsAsync(IEnumerable<Guid> MenuItemIds)
        {
            return await _context.RoomServiceMenu
                .Where(p => MenuItemIds.Contains(p.Id))
                .Select(p => new MenuItemDTO {
                    Id = p.Id,
                    Price = p.Price,
                    Available = p.Available,
                })
                .ToListAsync();
        }

        public async Task<MenuItemDTO> GetProductById(Guid id)
    {
            return await _context.RoomServiceMenu
                .Where(m => m.Available && m.Id == id)
                .Select(item => new MenuItemDTO
                {
                    Id = item.Id,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    Available = item.Available,

                })
                .FirstOrDefaultAsync();
        }
    }
}
