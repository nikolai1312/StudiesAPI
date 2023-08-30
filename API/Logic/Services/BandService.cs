using AutoMapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs.BandDtos;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Logic.Services
{
    public class BandService : IBandService
    {
        private readonly IBandRepository _repository;
        private readonly IMapper _mapper;

        public BandService(IBandRepository guestRepository, IMapper mapper)
        {
            _repository = guestRepository;
            _mapper = mapper;
        }

        public async Task<BandResponseDto> CreateBandAsync(BandRequestDto request)
        { 
            BandResponseDto _response = new() { HasError = false };
            Band _band = new() { Genre = request.Genre, Name = request.Name };
            
            try
            {
            await _repository.CreateAsync(_band);
            }
            catch
            {
                _response.HasError = true;
                _response.Message = "Algo de errado aconteceu.";
                return _response;
            }

            return _response;
        }

        public async Task<BandResponseDto> GetAllBandsAsync()
        {
            BandResponseDto _guestList = new() { HasError = false };
            IEnumerable<Band> _result = await _repository.GetAllAsync();

            var _mappedGuests = _mapper.Map<List<BandDto>>(_result);
            _guestList.DataList = _mappedGuests;

            return _guestList;
        }

        public async Task<BandResponseDto> GetBandAsync(int bandId)
        {
            BandResponseDto _response = new() { HasError = false };
            var _result = await _repository.GetAsync(bandId);

            _response.Data = _mapper.Map<BandDto>(_result);
            return _response;
        }
    }
}
