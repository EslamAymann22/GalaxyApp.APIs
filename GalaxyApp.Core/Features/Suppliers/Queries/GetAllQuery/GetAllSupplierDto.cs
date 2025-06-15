namespace GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery
{
    public class GetAllSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public LatestPurchaseDto? LatestPurchase { get; set; } = null;

    }

    public class LatestPurchaseDto
    {
        public DateTime Date { get; set; }

        public List<PurchaseItemsDto> PurchaseItems { get; set; }

    }

    public class PurchaseItemsDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
