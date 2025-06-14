namespace GalaxyApp.Data.Entities.CustomerFolder
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<CustomerPurchase> customerPurchases { get; set; } = new List<CustomerPurchase>();
    }
}
