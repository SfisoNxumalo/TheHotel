using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        private readonly HotelContext _context;

        public MessageRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FetchMessageDTO> GetMessageByBookingIdAsync(Guid Id)
        {
            return await _context.Messages.Select(mes => new FetchMessageDTO
            {
                Id = mes.Id,
                MessageText = mes.MessageText,
                UserId = mes.UserId,
                StaffId = mes.StaffId,
                CreatedDate = mes.CreatedDate

            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MessageEntity>> GetMessagesByBookingIdAsync(Guid bookingId)
        {
            return await _context.Messages
                        .Include(m => m.User)
                        .Include(m => m.Staff)
                        //.Where(m => m.BookingId == bookingId)
                        .OrderBy(m => m.CreatedDate)
                        .ToListAsync();
        }

        public async Task<IEnumerable<FetchMessageDTO>> GetMessagesByUserIdAsync(Guid userId)
        {
            return await _context.Messages.Select(mes => new FetchMessageDTO
            {
                Id = mes.Id,
                MessageText = mes.MessageText,
                UserId = mes.UserId,
                StaffId = mes.StaffId,
                CreatedDate = mes.CreatedDate
            }).Where(mes => mes.UserId == userId || mes.StaffId == userId)
            .OrderBy(m => m.CreatedDate)
            .ToListAsync();
        }
    }
}
