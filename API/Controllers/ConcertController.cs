using Microsoft.AspNetCore.Mvc;
using StudiesAPI.Filters;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.DTOs.ConcertDto;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConcertController : ControllerBase
    {
        private readonly ILogger<ConcertController> _logger;
        private readonly IConcertService _concertService;

        public ConcertController(IConcertService concertService, ILogger<ConcertController> logger)
        {
            _concertService = concertService;
            _logger = logger;
        }

        [HttpPost]
        [ConcertNameSanitizeFilter]
        public async Task<IActionResult> CreateConcertAsync(ConcertRequestDto concert)
        {
            var _response = await _concertService.CreateConcertAsync(concert);
            if (_response.HasError)
            {
                return BadRequest(new ErrorResponseDto { HasError = _response.HasError, Message = _response.Message });
            }

            return Created("", null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcertById(int id)
        {
            var _response = await _concertService.GetConcertAsync(id);

            return Ok(_response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConcerts()
        {
            var _response = await _concertService.GetAllConcertsAsync();

            return Ok(_response.DataList);
        }
    }
}
