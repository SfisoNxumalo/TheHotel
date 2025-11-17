using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs;
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

        public async Task<IEnumerable<MenuItemDTO>> GetMenuAsync()
        {
            return await _menuRepo.GetAvailableItemsAsync();
        }

        public async Task<MenuItemDTO?> GetMenuItemByIdAsync(Guid id)
        {
            return await _menuRepo.GetProductById(id);
        }

        public async Task<IEnumerable<MenuItemDTO>> GetMenuItemsByIdsAsync(IEnumerable<Guid> MenuItemIds)
        {
            return await _menuRepo.GetMenuItemsByIdsAsync(MenuItemIds);
        }
    }
}
