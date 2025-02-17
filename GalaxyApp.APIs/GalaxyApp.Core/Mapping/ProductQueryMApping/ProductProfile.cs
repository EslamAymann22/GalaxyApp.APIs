using AutoMapper;
using GalaxyApp.Core.Features.Products.Commands.CreateCommand;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
