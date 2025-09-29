using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomServiceMenuService
    {
        Task<RoomServiceMenuEntity> AddMenuItemAsync(RoomServiceMenuEntity item);
        Task<RoomServiceMenuEntity?> UpdateMenuItemAsync(RoomServiceMenuEntity item);
        Task<IEnumerable<RoomServiceMenuEntity>> GetMenuAsync();
        Task<RoomServiceMenuEntity?> GetMenuItemByIdAsync(Guid id);
    }
}
