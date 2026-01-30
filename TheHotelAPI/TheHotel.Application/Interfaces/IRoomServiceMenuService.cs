using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceMenuService
    {
        Task<RoomServiceMenuEntity> AddMenuItemAsync(RoomServiceMenuEntity item);
        Task<RoomServiceMenuEntity?> UpdateMenuItemAsync(RoomServiceMenuEntity item);
        Task<IEnumerable<MenuItemDTO>> GetMenuAsync();
        Task<IEnumerable<MenuItemDTO>> GetMenuItemsByIdsAsync(IEnumerable<Guid> MenuItemIds);
        Task<MenuItemDTO?> GetMenuItemByIdAsync(Guid id);

        //Task<Guid> Checkout();
    }
}
