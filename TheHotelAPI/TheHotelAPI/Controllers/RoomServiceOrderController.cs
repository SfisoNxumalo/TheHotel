using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.RoomServiceOrder;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomServiceOrderController : ControllerBase
    {
        private readonly IRoomServiceOrderService _orderService;

        public RoomServiceOrderController(IRoomServiceOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            return Ok(order);
        }

        
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRoomServiceDTO order)
        {
            var created = await _orderService.PlaceOrderAsync(order);
            return CreatedAtAction(nameof(PlaceOrder), new { orderId = created });
        }

        [Authorize]
        [HttpPatch("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromQuery] string status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return NoContent();
        }
    }
}
