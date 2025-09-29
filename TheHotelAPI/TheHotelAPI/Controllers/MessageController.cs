using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("booking/{bookingId:guid}")]
        public async Task<IActionResult> GetMessagesForBooking(Guid bookingId)
        {
            var messages = await _messageService.GetMessagesForBookingAsync(bookingId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageEntity message)
        {
            var created = await _messageService.SendMessageAsync(message);
            return CreatedAtAction(nameof(GetMessagesForBooking), new { bookingId = message.BookingId }, created);
        }
    }
}
