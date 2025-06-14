using System.ComponentModel.DataAnnotations;

namespace GalaxyApp.Data.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal sellingPrice { get; set; }
        public int Quantity
        {
            get
            {
                return WarehouseQuantity + ShopQuantity;
            }
        }
        public int WarehouseQuantity { get; set; } = 0;
        public int ShopQuantity { get; set; } = 0;
        public decimal Discount { get; set; } = 0M;
        public string Color { get; set; }
        [Range(1, 10, ErrorMessage = "Rate Must be between 1 and 10")]
        [Required]
        public int Evaluation { get; set; }

        public string? ImageUrl { get; set; }

        public string? ImageFileName { get; set; }

    }
}
