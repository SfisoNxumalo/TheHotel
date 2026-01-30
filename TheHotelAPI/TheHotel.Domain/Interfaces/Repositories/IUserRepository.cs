using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<StaffEntity?> GetStaffByIdAsync(Guid id);

        Task<UserDetailsDTO?> GetUserAsync();
        Task<UserDetailsDTO?> GetStaffAsync();
    }
}
