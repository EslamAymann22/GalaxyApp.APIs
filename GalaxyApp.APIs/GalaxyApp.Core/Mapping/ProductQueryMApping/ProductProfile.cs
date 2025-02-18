using AutoMapper;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.ProductQueryMApping
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

            CreateMap<CreateProductModel, Product>()
                .ForMember(dest => dest.WarehouseQuantity, opt => opt.MapFrom(src => src.Quantity));
        }

    }
}
