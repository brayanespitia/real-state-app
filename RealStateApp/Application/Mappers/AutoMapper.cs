using AutoMapper;
using RealStateApp.Application.Dto;
using RealStateApp.Domain.Entities;
using System.Runtime;

namespace RealStateApp.Application.Mappers
{
    public class AutoMapper : Profile 
    {
        public AutoMapper()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageDto>().ReverseMap();
        }
    }
}
