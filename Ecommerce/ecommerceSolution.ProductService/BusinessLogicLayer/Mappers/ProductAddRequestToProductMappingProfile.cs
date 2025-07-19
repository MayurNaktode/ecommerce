using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers
{
    public class ProductAddRequestToProductMappingProfile : Profile
    {
        public ProductAddRequestToProductMappingProfile()
        {
            CreateMap<ProductAddRequest, Product>();
        }
    }
}
