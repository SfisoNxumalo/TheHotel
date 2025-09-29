using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<BookingEntity>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }
        public async Task<BookingEntity?> GetBookingByIdAsync(Guid id) 
        { 
            return await _bookingRepository.GetByIdAsync(id);
        }
        public async Task<BookingEntity> AddBookingAsync(BookingEntity booking)
        {
             await _bookingRepository.AddAsync(booking);
            return booking;
        }
        public async Task UpdateBookingAsync(BookingEntity booking)
        {
            await _bookingRepository.UpdateAsync(booking);
        }
        public async Task DeleteBookingAsync(Guid id)
        {
            await _bookingRepository.DeleteAsync(id);
        }
    }
}
