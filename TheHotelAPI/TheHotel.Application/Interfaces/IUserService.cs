using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity?> GetUserByIdAsync(Guid id);
        Task<UserEntity> AddUserAsync(AddUserDTO user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(Guid id);
    }
}
