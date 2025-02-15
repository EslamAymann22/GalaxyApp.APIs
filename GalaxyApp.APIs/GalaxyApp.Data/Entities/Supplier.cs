using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities
{
    public class Supplier : BaseEntity
    {

        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoFileName { get; set; }
        public Purchase LatestPurchase {  get; set; }

        List<Purchase> Purchases { get; set; } = new List<Purchase>();

    }
}
