using AutoMapper;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.ProductQueryMapping
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, GetAllProductDto>();

            CreateMap<Product, GetAllShopProductDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ShopQuantity));

            CreateMap<Product, GetAllWarehouseProductDto>()
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.WarehouseQuantity));


        }

    }
}
