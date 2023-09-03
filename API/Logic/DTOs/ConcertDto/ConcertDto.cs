using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Logic.DTOs.ConcertDto
{
    public class ConcertDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
    }
}
