using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Products.Commands;

namespace CleanArchApi.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
