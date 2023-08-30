using AutoMapper;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.DTOs.BandDtos;

namespace StudiesAPI.Logic.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper() {
            CreateMap<Band, BandDto> ().ReverseMap();
            CreateMap<Entity<int>, GenericDto>().ReverseMap();
        }
    }
}
