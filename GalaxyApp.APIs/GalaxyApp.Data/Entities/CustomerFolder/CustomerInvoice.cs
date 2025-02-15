using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities.CustomerFolder
{
    public class CustomerInvoice : BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; } = 0M;

        public List<InvoiceItems> invoiceItems { get; set; } = new List<InvoiceItems>();


    }
}
