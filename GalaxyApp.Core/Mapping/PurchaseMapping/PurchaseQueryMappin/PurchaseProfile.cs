using AutoMapper;
using GalaxyApp.Core.Features.Purchases.Queries;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.PurchaseMapping.PurchaseQueryMappin
{
    public class PurchaseProfile : Profile
    {

        public PurchaseProfile()
        {
            CreateMap<Purchase, GetAllPurchaseDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TotalInDiscount))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
        }

    }
}
