namespace GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandHandler
{
    public class CreateInvoiceItemDto
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
