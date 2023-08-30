using Microsoft.AspNetCore.Mvc;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.DTOs.BandDtos;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BandController : Controller
    {
        private readonly ILogger<BandController> _logger;
        private readonly IBandService _bandService;

        public BandController(ILogger<BandController> logger, IBandService bandService)
        {
            _logger = logger;
            _bandService = bandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBandAsync(BandRequestDto band)
        {
            var _response = await _bandService.CreateBandAsync(band);
            if (_response.HasError)
            {
                return BadRequest(new ErrorResponseDto { HasError = _response.HasError, Message = _response.Message });
            }
            return Created("", band);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            BandResponseDto _response = await _bandService.GetBandAsync(id);

            return Ok(_response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetBandsListAsync()
        {
            var _response = await _bandService.GetAllBandsAsync();

            return Ok(_response.DataList);
        }
    }
}