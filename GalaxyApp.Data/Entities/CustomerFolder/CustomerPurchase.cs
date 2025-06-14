namespace GalaxyApp.Data.Entities.CustomerFolder
{
    public class CustomerPurchase : BaseEntity
    {

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal TotalPrice
        {
            get
            {
                decimal Ret = 0;
                foreach (var item in purchaseItems)
                    Ret += item.TotalInDiscount;
                return Ret;
            }
        }

        public List<CustomerPurchaseItem> purchaseItems { get; set; } = new List<CustomerPurchaseItem>();


    }
}
