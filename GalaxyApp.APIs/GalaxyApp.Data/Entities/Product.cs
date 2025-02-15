using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal sellingPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } = 0M;

        public string Color { get; set; }
        [Range(1,10,ErrorMessage ="Rate Must be between 1 and 10")]
        [Required]
        public int Evaluation {  get; set; }

        public string? ImageUrl { get; set; }

        public string? ImageFileName { get; set; }

    }
}
