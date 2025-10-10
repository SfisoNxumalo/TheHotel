using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces
{
    public interface IRoomServiceMenuRepository : IGenericRepository<RoomServiceMenuEntity>
    {
        Task<IEnumerable<MenuItemDTO>> GetAvailableItemsAsync();
    }
}
