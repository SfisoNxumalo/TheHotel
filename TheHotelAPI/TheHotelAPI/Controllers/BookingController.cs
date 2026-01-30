using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingEntity booking)
        {
            var newBooking = await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = newBooking.Id }, newBooking);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBooking(Guid id, [FromBody] BookingEntity booking)
        {
            if (id != booking.Id) return BadRequest("ID mismatch");
            await _bookingService.UpdateBookingAsync(booking);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
