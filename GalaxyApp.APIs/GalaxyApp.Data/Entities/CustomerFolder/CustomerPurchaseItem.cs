namespace GalaxyApp.Data.Entities.CustomerFolder
{
    public class CustomerPurchaseItem : BaseEntity
    {



        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerPurchaseId { get; set; }
        public CustomerPurchase CustomerPurchase { get; set; }


        public decimal TotalInDiscount => Quantity * Product.sellingPrice * (1M - Discount);


    }
}
