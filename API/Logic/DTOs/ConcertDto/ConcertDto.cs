using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Logic.DTOs.ConcertDto
{
    public class ConcertDto : Entity <int>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }
    }
}
