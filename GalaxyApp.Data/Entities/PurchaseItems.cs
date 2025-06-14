namespace GalaxyApp.Data.Entities
{
    public class PurchaseItems : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Discount { get; set; } = 0;
        public int ProductId { get; set; }
        public Product ItemProduct { get; set; }

        public int PurchaseId;
        public Purchase Purchase { get; set; }


        public decimal TotalInDiscount
        {
            get
            {
                return Quantity * ItemProduct.PurchasingPrice * (1M - Discount);
            }

        }



    }
}
