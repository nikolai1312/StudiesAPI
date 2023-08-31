using StudiesAPI.Logic.DTOs.ConcertDto;

namespace StudiesAPI.Logic.Interfaces
{
    public interface IConcertService
    {
        Task<ConcertResponseDto> CreateConcertAsync(ConcertRequestDto request);

        Task<ConcertResponseDto> GetAllConcertsAsync();

        Task<ConcertResponseDto> GetConcertAsync(int id);
    }
}
