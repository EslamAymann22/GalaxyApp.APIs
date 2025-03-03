using AutoMapper;
using GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler;
using GalaxyApp.Core.Features.CustomerInvoices.Queries;
using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Core.Mapping.CustomerInvoiceMapping
{
    public class CustomerInvoiceItemsProfile : Profile
    {

        public CustomerInvoiceItemsProfile()
        {
            CreateMap<CustomerInvoiceItemsDto, CustomerPurchaseItem>();
            CreateMap<CustomerPurchase, GetAllCustomerPurchaseDto>()
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Customer.Phone))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.PurchseDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.PurchaseId, opt => opt.MapFrom(src => src.Id));
        }

    }
}
