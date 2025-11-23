using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs;
using TheHotel.Domain.Entities;

namespace TheHotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomServiceController : Controller
    {
        private readonly IRoomServiceMenuService _menuService;
        private readonly ILogger<RoomServiceController> _logger;

        public RoomServiceController(IRoomServiceMenuService menuService, ILogger<RoomServiceController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("menu")]
        [ProducesResponseType(200, Type = typeof(MenuItemDTO))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMenu()
        {
            try
            {
                var menu = await _menuService.GetMenuAsync();
                return Ok(menu);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while retrieving menu.",
                    nameof(GetMenu)
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }

        [Authorize]
        [HttpGet("menu/{id:guid}")]
        [ProducesResponseType(200, Type = typeof(MenuItemDTO))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMenuItemById([FromRoute] Guid id)
        {
            try
            {
                var menu = await _menuService.GetMenuItemByIdAsync(id);
                return Ok(menu);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "{functionName} encountered an error while getting menu item by ID."
                        + Environment.NewLine
                        + "||{idName}: {id}",
                    nameof(GetMenuItemById),
                    nameof(id),
                    id
                );

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request"
                );
            }
        }

        [Authorize]
        [HttpPost("menu")]
        public async Task<IActionResult> AddMenuItem(RoomServiceMenuEntity item)
        {
            var result = await _menuService.AddMenuItemAsync(item);
            return CreatedAtAction(nameof(GetMenu), new { id = result.Id }, result);
        }

        [HttpPut("menu/{id}")]
        public async Task<IActionResult> UpdateMenuItem([FromRoute] Guid id, RoomServiceMenuEntity item)
        {
            item.Id = id;
            var result = await _menuService.UpdateMenuItemAsync(item);
            if (result == null) return NotFound();
            return Ok(result);
        }

        //[HttpPost("checkout")]
        //public async Task<IActionResult> Checkout(RoomServiceMenuEntity item)
        //{
        //    var result = await _menuService.AddMenuItemAsync(item);
        //    return CreatedAtAction(nameof(GetMenu), new { id = result.Id }, result);
        //}
    }
}
