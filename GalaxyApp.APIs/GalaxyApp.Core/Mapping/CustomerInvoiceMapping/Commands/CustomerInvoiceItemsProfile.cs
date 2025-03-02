using AutoMapper;
using GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler;
using GalaxyApp.Data.Entities.CustomerFolder;

namespace GalaxyApp.Core.Mapping.CustomerInvoiceMapping.Commands
{
    public class CustomerInvoiceItemsProfile : Profile
    {

        public CustomerInvoiceItemsProfile()
        {
            CreateMap<CustomerInvoiceItemsDto, CustomerPurchaseItem>();
        }

    }
}
