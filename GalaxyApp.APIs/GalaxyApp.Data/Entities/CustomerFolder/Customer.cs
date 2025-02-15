using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities.CustomerFolder
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<CustomerInvoice> CustomerInvoices { get; set; } = new List<CustomerInvoice>();
    }
}
