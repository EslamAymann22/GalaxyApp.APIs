namespace GalaxyApp.Data.Entities
{
    public class Supplier : BaseEntity
    {

        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public string? PhotoFileName { get; set; }
        public int? LatestPurchaseId { get; set; }
        public Purchase? LatestPurchase { get; set; }

        public List<Purchase> Purchases { get; set; } = new List<Purchase>();

    }
}
