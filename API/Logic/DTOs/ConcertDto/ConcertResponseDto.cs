using StudiesAPI.Logic.DTOs.BandDtos;

namespace StudiesAPI.Logic.DTOs.ConcertDto
{
    public class ConcertResponseDto
    {
        public bool HasError
        {
            get; set;
        }

        public string? Message
        {
            get; set;
        }

        public ConcertDto? Data
        {
            get; set;
        }

        public IList<ConcertDto>? DataList
        {
            get; set;
        }
    }
}
