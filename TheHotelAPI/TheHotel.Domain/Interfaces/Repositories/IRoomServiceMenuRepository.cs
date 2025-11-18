using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces.Repositories
{
    public interface IRoomServiceMenuRepository : IGenericRepository<RoomServiceMenuEntity>
    {
        Task<IEnumerable<MenuItemDTO>> GetAvailableItemsAsync();
        Task<MenuItemDTO> GetProductById(Guid id);

        Task<IEnumerable<MenuItemDTO>> GetMenuItemsByIdsAsync(IEnumerable<Guid> MenuItemIds);
    }
}
