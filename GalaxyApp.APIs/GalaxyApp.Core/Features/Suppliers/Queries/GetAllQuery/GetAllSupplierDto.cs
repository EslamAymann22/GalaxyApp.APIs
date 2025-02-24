using GalaxyApp.Data.Entities;

namespace GalaxyApp.Core.Features.Suppliers.Queries.GetAllQuery
{
    public class GetAllSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Purchase? LatestPurchase { get; set; } = null;

    }

}
