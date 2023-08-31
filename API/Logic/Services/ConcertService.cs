using AutoMapper;
using StudiesAPI.Data.Interfaces;
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
        }

        public async Task<ConcertResponseDto> GetAllConcertsAsync()
        {
        }

        public async Task<ConcertResponseDto> GetConcertAsync(int id)
        {
        }
    }
}
