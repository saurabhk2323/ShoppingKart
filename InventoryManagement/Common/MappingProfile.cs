using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Entities;

namespace InventoryManagement.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ResponseProductDto>();
        }
    }
}
