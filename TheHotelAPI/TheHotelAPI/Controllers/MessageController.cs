using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs.NewFolder;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMessageService messageService, ILogger<MessageController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }



        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO message)
        {
            try
            {
                var created = await _messageService.SendMessageAsync(message);

                return CreatedAtAction(
                    nameof(SendMessage),
                    new { bookingId = created.Id },
                    created
                );
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RealTimeNotificationException ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while sending a message.",
                    nameof(SendMessage)
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }

        [HttpGet("{userId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserMessages(Guid userId)
        {
            try
            {
                var messages = await _messageService.GetMessagesByUserIdAsync(userId);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while getting messages for user."
                        + Environment.NewLine
                        + "||{userIdName}: {userId}",
                    nameof(GetUserMessages),
                    nameof(userId),
                    userId
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }
    }
}
