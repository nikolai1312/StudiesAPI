namespace StudiesAPI.Logic.DTOs
{
    public class GuestResponseDto
    {
        public bool HasError
        {
            get; set;
        }

        public string? Message
        {
            get; set;
        }

        public GuestDto? Data
        {
            get; set;
        }

        public IList<GuestDto>? DataList
        {
            get; set;
        }
    }
}
