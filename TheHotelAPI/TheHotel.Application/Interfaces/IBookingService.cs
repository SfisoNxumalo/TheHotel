using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingEntity>> GetAllBookingsAsync();
        Task<BookingEntity?> GetBookingByIdAsync(Guid id);
        Task<BookingEntity> AddBookingAsync(BookingEntity booking);
        Task UpdateBookingAsync(BookingEntity booking);
        Task DeleteBookingAsync(Guid id);
    }
}
