namespace GalaxyApp.Data.Entities
{
    public class InvoiceItems : BaseEntity
    {
        public int ItemProductId { get; set; }
        public Product ItemProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } = 0;

        public decimal TotalInDiscount => Quantity * ItemProduct.PurchasingPrice * (1M - Discount);



    }
}
