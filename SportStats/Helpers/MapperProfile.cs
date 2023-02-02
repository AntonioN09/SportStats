using AutoMapper;
using SportStats.Models;
using SportStats.Models.DTOs;

namespace SportStats.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Manager, ManagerAuthRequestDto>();
            CreateMap<ManagerAuthRequestDto, Manager>();
            CreateMap<ManagerAuthResponseDto, Manager>();
            CreateMap<Manager, ManagerAuthResponseDto>();
        }
    }
}
