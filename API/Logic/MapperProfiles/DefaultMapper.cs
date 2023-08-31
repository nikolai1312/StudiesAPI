using AutoMapper;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.DTOs.BandDtos;
using StudiesAPI.Logic.DTOs.ConcertDto;

namespace StudiesAPI.Logic.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper() {
            CreateMap<Band, BandDto> ().ReverseMap();
            CreateMap<Concert, ConcertDto>().ReverseMap();
            CreateMap<Entity<int>, GenericDto>().ReverseMap();
        }
    }
}
