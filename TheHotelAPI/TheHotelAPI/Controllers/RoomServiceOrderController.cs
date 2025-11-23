using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs.RoomServiceOrder;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomServiceOrderController : ControllerBase
    {
        private readonly IRoomServiceOrderService _orderService;
        private readonly ILogger<RoomServiceOrderController> _logger;

        public RoomServiceOrderController(IRoomServiceOrderService orderService, ILogger<RoomServiceOrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("user/{userId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserIdAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while retrieving orders for user."
                        + Environment.NewLine
                        + "||{userIdName}: {userId}",
                    nameof(GetOrdersByUserId),
                    nameof(userId),
                    userId
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }

        [Authorize]
        [HttpGet("{orderId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            try
            {
                var order = await _orderService.GetOrderById(orderId);
                return Ok(order);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while retrieving an order by ID."
                        + Environment.NewLine
                        + "||{orderIdName}: {orderId}",
                    nameof(GetOrderById),
                    nameof(orderId),
                    orderId
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }


        [Authorize]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRoomServiceDTO order)
        {
            try
            {
                var created = await _orderService.PlaceOrderAsync(order);

                return CreatedAtAction(
                    nameof(PlaceOrder),
                    new { orderId = created },
                    created
                );
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InappropriateContentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while placing an order.",
                    nameof(PlaceOrder)
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }


        [Authorize]
        [HttpPatch("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromQuery] string status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return NoContent();
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var order = await _orderService.GetAllOrdersAsync();
            return Ok(order);
        }
    }
}
