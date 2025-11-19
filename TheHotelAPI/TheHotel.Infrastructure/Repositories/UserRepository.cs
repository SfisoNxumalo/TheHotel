using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class UserRepository :  GenericRepository<UserEntity>, IUserRepository
    {

        private readonly HotelContext _context;

        public UserRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<StaffEntity?> GetStaffByIdAsync(Guid id)
        {
            return await _context.Staff.FindAsync(id);
        }
    }
}
