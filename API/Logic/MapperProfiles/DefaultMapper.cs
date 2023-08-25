using AutoMapper;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs;

namespace StudiesAPI.Logic.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper() {
            CreateMap<Guest, GuestDto> ().ReverseMap();
            CreateMap<Entity<int>, GenericDto>().ReverseMap();
        }
    }
}
