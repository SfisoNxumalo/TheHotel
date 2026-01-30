using TheHotel.Domain.Entities;

namespace TheHotel.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {

        Task<UserEntity> GetUserDetailsByEmailAsync(string email);

        Task<StaffEntity> GetStaffDetailsByEmailAsync(string email);
        Task<bool> Register(UserEntity user);
        Task<bool> RegisterStaff(StaffEntity user);
    }
}
