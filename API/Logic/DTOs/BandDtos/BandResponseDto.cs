namespace StudiesAPI.Logic.DTOs.BandDtos
{
    public class BandResponseDto
    {
        public bool HasError
        {
            get; set;
        }

        public string? Message
        {
            get; set;
        }

        public BandDto? Data
        {
            get; set;
        }

        public IList<BandDto>? DataList
        {
            get; set;
        }
    }
}
