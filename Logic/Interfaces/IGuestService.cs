using StudiesAPI.Logic.DTOs;

namespace StudiesAPI.Logic.Interfaces
{
    public interface IGuestService
    {
        Task<GuestResponseDto> CreateGuestAsync(GuestRequestDto request);

        Task<GuestResponseDto> GetAllGuestsAsync();

        Task<GuestResponseDto> GetGuestAsync(GenericDto id);
    }
}
