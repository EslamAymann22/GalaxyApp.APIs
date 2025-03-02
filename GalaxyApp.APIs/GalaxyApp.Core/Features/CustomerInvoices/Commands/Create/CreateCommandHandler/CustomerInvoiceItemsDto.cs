namespace GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler
{
    public class CustomerInvoiceItemsDto
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
