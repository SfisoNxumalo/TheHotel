using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.DomainExceptions;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly HotelContext _dbContext;
        public AuthRepository(HotelContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<UserEntity> GetUserDetailsByEmailAsync(string email)
        {
            var user = await _dbContext.Users.Where(user => user.Email == email)
               .FirstOrDefaultAsync();

                return user;
        }

        public async Task<StaffEntity> GetStaffDetailsByEmailAsync(string email)
        {
            var staff = await _dbContext.Staff.Where(staff => staff.Email == email)
               .FirstOrDefaultAsync();

            return staff;
        }

        public async Task<bool> Register(UserEntity user)
        {
            
                var UserFound = await _dbContext.Users.FirstOrDefaultAsync(
                    users => user.Email == users.Email
                );

                if (UserFound != null)
                {
                    throw new DatabaseException("A user with this email address already exists");
                }

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return true;
            
        }

        public async Task<bool> RegisterStaff(StaffEntity user)
        {

            var UserFound = await _dbContext.Staff.FirstOrDefaultAsync(
                users => user.Email == users.Email
            );

            if (UserFound != null)
            {
                throw new DatabaseException("A user with this email address already exists");
            }

            await _dbContext.Staff.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
