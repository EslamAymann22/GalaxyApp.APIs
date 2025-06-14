using AutoMapper;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.ProductMapping.ProductCommandMapping
{
    public class ProductCommandProfile : Profile
    {
        public ProductCommandProfile()
        {

            CreateMap<CreateProductModel, Product>()
                .ForMember(dest => dest.WarehouseQuantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<UpdateProductModel, Product>();
            CreateMap<Product, Product>();
        }

    }
}
