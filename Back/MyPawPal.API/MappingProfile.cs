using AutoMapper;
using MyPawPal.Domain.Entities;
using MyPawPal.Application.DTOs;

namespace MyPawPal.API
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInfo, UserDto>();
            CreateMap<UserDto, UserInfo>();
            CreateMap<DogInfo, DogDto>();
            CreateMap<DogDto, DogInfo>();
        }
    }
}
