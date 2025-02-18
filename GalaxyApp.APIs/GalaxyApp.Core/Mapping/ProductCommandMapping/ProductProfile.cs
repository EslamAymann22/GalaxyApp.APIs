using AutoMapper;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.ProductCommandMapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<CreateProductModel, Product>()
                .ForMember(dest => dest.WarehouseQuantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<UpdateProductModel, Product>();
        }

    }
}
