using AutoMapper;
using Catalog.ApplicationService.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.ApplicationService.Mapping
{
    public  class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductOperationDTO>();
            CreateMap<ProductOperationDTO, Product>();
        }
    }
}
