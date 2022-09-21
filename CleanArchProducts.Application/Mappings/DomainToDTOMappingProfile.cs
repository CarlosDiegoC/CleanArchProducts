using AutoMapper;
using CleanArchProducts.Application.DTO;
using CleanArchProducts.Application.Products.Commands;
using CleanArchProducts.Domain.Entities;

namespace CleanArchProducts.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();          
        }
    }
}