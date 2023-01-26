using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Domain.Entities;

namespace CleanArchApi.Application.Mappings;

public class EntityToDTOMappingProfile : Profile
{
    public EntityToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
