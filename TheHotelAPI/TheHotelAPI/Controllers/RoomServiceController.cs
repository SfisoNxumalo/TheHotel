using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomServiceController : Controller
    {
        private readonly IRoomServiceMenuService _menuService;

        public RoomServiceController(
        IRoomServiceMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("menu")]
        public async Task<IActionResult> GetMenu()
        {
            var menu = await _menuService.GetMenuAsync();
            return Ok(menu);
        }

        [HttpPost("menu")]
        public async Task<IActionResult> AddMenuItem(RoomServiceMenuEntity item)
        {
            var result = await _menuService.AddMenuItemAsync(item);
            return CreatedAtAction(nameof(GetMenu), new { id = result.Id }, result);
        }

        [HttpPut("menu/{id}")]
        public async Task<IActionResult> UpdateMenuItem(Guid id, RoomServiceMenuEntity item)
        {
            item.Id = id;
            var result = await _menuService.UpdateMenuItemAsync(item);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
