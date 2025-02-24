using AutoMapper;
using GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery;
using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Mapping.SupplierMapping.SupplierQueryMapping
{
    public class SupplierQueryProfile : Profile
    {
        public SupplierQueryProfile()
        {

            CreateMap<Supplier, GetAllSupplierDto>();

            //    .ForMember(dest => dest.LatestPurchase, opt => opt.MapFrom(src => src.LatestPurchase))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


        }

    }
}
