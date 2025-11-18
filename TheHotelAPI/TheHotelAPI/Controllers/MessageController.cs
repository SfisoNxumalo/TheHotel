using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.NewFolder;

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
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO message)
        {
            var created = await _messageService.SendMessageAsync(message);
            return CreatedAtAction(nameof(SendMessage), new { bookingId = created.Id }, created);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserMessages(Guid userId)
        {
            var messages = await _messageService.GetMessagesByUserIdAsync(userId);
            return Ok(messages);
        }
    }
}
