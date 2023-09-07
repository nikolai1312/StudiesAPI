using StudiesAPI.Logic.DTOs.AttendedFansDto;
using StudiesAPI.Logic.DTOs.BandDtos;

namespace StudiesAPI.Logic.Interfaces
{
    public interface IAttendedFansService
    {
        Task<AttendedFansResponseDto> InsertAttendedFansAsync(AttendedFansRequestDto request);

        Task<AttendedFansResponseDto> GetFansRecordAsync(int id);
    }
}
