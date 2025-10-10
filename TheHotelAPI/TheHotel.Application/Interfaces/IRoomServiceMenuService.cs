using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceMenuService
    {
        Task<RoomServiceMenuEntity> AddMenuItemAsync(RoomServiceMenuEntity item);
        Task<RoomServiceMenuEntity?> UpdateMenuItemAsync(RoomServiceMenuEntity item);
        Task<IEnumerable<MenuItemDTO>> GetMenuAsync();
        Task<RoomServiceMenuEntity?> GetMenuItemByIdAsync(Guid id);
    }
}
