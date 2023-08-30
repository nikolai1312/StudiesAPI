using StudiesAPI.Logic.DTOs.BandDtos;

namespace StudiesAPI.Logic.Interfaces
{
    public interface IBandService
    {
        Task<BandResponseDto> CreateBandAsync(BandRequestDto request);

        Task<BandResponseDto> GetAllBandsAsync();

        Task<BandResponseDto> GetBandAsync(int id);
    }
}
