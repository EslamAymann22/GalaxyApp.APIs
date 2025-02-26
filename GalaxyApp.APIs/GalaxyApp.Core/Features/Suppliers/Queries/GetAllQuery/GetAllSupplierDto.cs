namespace GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery
{
    public class GetAllSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LatestPurchaseDto? LatestPurchase { get; set; } = null;

    }

    public class LatestPurchaseDto
    {
        public DateTime Date { get; set; }

        List<PurchaseItemsDto> PurchaseItems { get; set; }

    }

    public class PurchaseItemsDto
    {
        public int Id { get; set; }
        public int ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
