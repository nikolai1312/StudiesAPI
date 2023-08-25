using AutoMapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Logic.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;

        public GuestService(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        public async Task<GuestResponseDto> CreateGuestAsync(GuestRequestDto request)
        { 
            GuestResponseDto _response = new() { HasError = false };
            Guest _guest = new() { CPF = request.CPF, Name = request.Name };
            
            try
            {
            await _guestRepository.CreateAsync(_guest);
            }
            catch
            {
                _response.HasError = true;
                _response.Message = "Algo de errado aconteceu.";
                return _response;
            }

            return _response;
        }

        public async Task<GuestResponseDto> GetAllGuestsAsync()
        {
            GuestResponseDto _guestList = new() { HasError = false };
            IEnumerable<Guest> _result = await _guestRepository.GetAllAsync();

            var _mappedGuests = _mapper.Map<List<GuestDto>>(_result);
            _guestList.DataList = _mappedGuests;

            return _guestList;
        }

        public async Task<GuestResponseDto> GetGuestAsync(int guestId)
        {
            GuestResponseDto _response = new() { HasError = false };
            var _result = await _guestRepository.GetAsync(guestId);

            _response.Data = _mapper.Map<GuestDto>(_result);
            return _response;
        }
    }
}
