using AutoMapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs.AttendedFansDto;
using StudiesAPI.Logic.Interfaces;

namespace StudiesAPI.Logic.Services
{
    public class AttendedFansService : IAttendedFansService
    {
        private readonly IAttendedFansRepository _repository;
        private readonly IConcertRepository _concerRepository;
        private readonly IMapper _mapper;
        public AttendedFansService(IAttendedFansRepository repository, IMapper mapper, IConcertRepository concerRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _concerRepository = concerRepository;
        }

        public async Task<AttendedFansResponseDto> GetFansRecordAsync(int id)
        {
            AttendedFansResponseDto _response = new() { HasError = false };
            var _result = await _repository.GetAsync(id);

            _response.Data = _mapper.Map<AttendedFansDto>(_result);
            return _response;
        }

        public async Task<AttendedFansResponseDto> InsertAttendedFansAsync(AttendedFansRequestDto request)
        {
            AttendedFansResponseDto _response = new() { HasError = false };
            var _existingConcert = await _concerRepository.GetAsync(request.ConcertId);
            
            if(_existingConcert is null)
            {
                _response.HasError = true;
                _response.Message = "Esse evento não existe.";
                return _response;
            }

            AttendedFans _recordToBeCreated = _mapper.Map<AttendedFans>(request);

            try
            {
                await _repository.CreateAsync(_recordToBeCreated);
            }
            catch (Exception ex)
            {
                _response.HasError = true;
                _response.Message = ex.Message;
                return _response;
            }

            return _response;
        }
    }
}
