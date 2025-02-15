using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities
{
    public class Purchase : BaseEntity
    {

        public DateTime Date { get; set; } = DateTime.Now;
       
        public decimal TotalInDiscount { get; set; }

        public List<InvoiceItems> PurchaseItems { get; set; } = new List<InvoiceItems>();
    }
}
