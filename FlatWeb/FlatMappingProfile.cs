using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using System.Diagnostics;

namespace FlatWeb
{
    public class FlatMappingProfile : Profile
    {
        public FlatMappingProfile()
        {
            CreateMap<Flat, FlatDto>()
            .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
            .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
            .ForMember(m => m.StreetNumber, c => c.MapFrom(s => s.Address.StreetNumber));

            CreateMap<CreateUserDto, User>();

            CreateMap<User, CreateUserDto>();
        }       
    }
}
