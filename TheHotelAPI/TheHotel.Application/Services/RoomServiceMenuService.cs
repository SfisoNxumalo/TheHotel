using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class RoomServiceMenuService : IRoomServiceMenuService
    {
        private readonly IRoomServiceMenuRepository _menuRepo;

        public RoomServiceMenuService(IRoomServiceMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public async Task<RoomServiceMenuEntity> AddMenuItemAsync(RoomServiceMenuEntity item)
        {
            await _menuRepo.AddAsync(item);
            return item;
        }

        public async Task<RoomServiceMenuEntity?> UpdateMenuItemAsync(RoomServiceMenuEntity item)
        {
            var existing = await _menuRepo.GetByIdAsync(item.Id);
            if (existing == null) return null;

            existing.ItemName = item.ItemName;
            existing.Description = item.Description;
            existing.Price = item.Price;
            existing.Available = item.Available;

            await _menuRepo.UpdateAsync(existing);
            return existing;
        }

        public async Task<IEnumerable<RoomServiceMenuEntity>> GetMenuAsync()
        {
            return await _menuRepo.GetAvailableItemsAsync();
        }

        public async Task<RoomServiceMenuEntity?> GetMenuItemByIdAsync(Guid id)
        {
            return await _menuRepo.GetByIdAsync(id);
        }
    }
}
