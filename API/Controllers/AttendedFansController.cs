using Microsoft.AspNetCore.Mvc;
using StudiesAPI.Filters;
using StudiesAPI.Logic.DTOs.BandDtos;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.Interfaces;
using StudiesAPI.Logic.Services;
using StudiesAPI.Logic.DTOs.AttendedFansDto;

namespace StudiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendedFansController : ControllerBase
    {
        private readonly ILogger<AttendedFansController> _logger;
        private readonly IAttendedFansService _service;

        public AttendedFansController(IAttendedFansService service, ILogger<AttendedFansController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecordAsync(AttendedFansRequestDto record)
        {
            var _response = await _service.InsertAttendedFansAsync(record);
            if (_response.HasError)
            {
                return BadRequest(new ErrorResponseDto { HasError = _response.HasError, Message = _response.Message });
            }
            return Created("", record);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            AttendedFansResponseDto _response = await _service.GetFansRecordAsync(id);

            return Ok(_response.Data);
        }
    }
}
