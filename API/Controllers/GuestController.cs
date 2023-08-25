using Microsoft.AspNetCore.Mvc;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : Controller
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestService _guestService;

        public GuestController(ILogger<GuestController> logger, IGuestService guestService)
        {
            _logger = logger;
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(GuestRequestDto guest)
        {
            var _response = await _guestService.CreateGuestAsync(guest);
            if (_response.HasError)
            {
                return BadRequest(new ErrorResponseDto { HasError = _response.HasError, Message = _response.Message });
            }
            return Created("", guest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            GuestResponseDto _response = await _guestService.GetGuestAsync(id);

            return Ok(_response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuestsListAsync()
        {
            var _response = await _guestService.GetAllGuestsAsync();

            return Ok(_response.DataList);
        }
    }
}