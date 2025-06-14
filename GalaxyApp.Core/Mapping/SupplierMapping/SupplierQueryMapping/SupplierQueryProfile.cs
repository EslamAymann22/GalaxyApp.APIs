using AutoMapper;
using GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.SupplierMapping.SupplierQueryMapping
{
    public class SupplierQueryProfile : Profile
    {
        public SupplierQueryProfile()
        {

            CreateMap<PurchaseItems, PurchaseItemsDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ItemProduct.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ItemProduct.PurchasingPrice));


            CreateMap<Purchase, LatestPurchaseDto>();

            CreateMap<Supplier, GetAllSupplierDto>();

            //    .ForMember(dest => dest.LatestPurchase, opt => opt.MapFrom(src => src.LatestPurchase))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


        }

    }
}
