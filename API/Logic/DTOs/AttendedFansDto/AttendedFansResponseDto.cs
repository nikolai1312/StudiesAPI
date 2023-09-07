namespace StudiesAPI.Logic.DTOs.AttendedFansDto
{
    public class AttendedFansResponseDto
    {
        public bool HasError
        {
            get; set;
        }

        public string? Message
        {
            get; set;
        }

        public AttendedFansDto? Data
        {
            get; set;
        }
    }
}
