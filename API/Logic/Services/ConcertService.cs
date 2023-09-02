using AutoMapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs.ConcertDto;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Logic.Services
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _repository;
        private readonly IMapper _mapper;

        public ConcertService(IConcertRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ConcertResponseDto> CreateConcertAsync(ConcertRequestDto request)
        {
            ConcertResponseDto _response = new() { HasError = false };

            var _concertToBeCreated = _mapper.Map<Concert>(request);

            try
            {
                await _repository.CreateAsync(_concertToBeCreated);
            }
            catch (Exception ex)
            {
                _response.HasError = true;
                _response.Message = "Algo de errado aconteceu.";
                return _response;
            }

            return _response;
        }

        public async Task<ConcertResponseDto> GetAllConcertsAsync()
        {
            ConcertResponseDto _response = new() { HasError = false };
            IEnumerable<Concert> _concertsToBeMapped = await _repository.GetAllAsync();

            var _mappedConcerts = _mapper.Map<IList<ConcertDto>>(_concertsToBeMapped);
            _response.DataList = _mappedConcerts;

            return _response;
        }

        public async Task<ConcertResponseDto> GetConcertAsync(int id)
        {
            ConcertResponseDto _response =  new() { HasError = false };

            var _concertToBeMapped = await _repository.GetAsync(id);
            var _mappedConcert = _mapper.Map<ConcertDto>(_concertToBeMapped);

            _response.Data = _mappedConcert;

            return _response;
        }
    }
}
