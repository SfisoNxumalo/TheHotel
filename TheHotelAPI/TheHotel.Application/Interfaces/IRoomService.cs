using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomEntity>> GetAllRoomsAsync();
        Task<RoomEntity?> GetRoomByIdAsync(Guid id);
        Task<RoomEntity> AddRoomAsync(RoomEntity room);
        Task UpdateRoomAsync(RoomEntity room);
        Task DeleteRoomAsync(Guid id);
    }
}
