using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities
{
    public class Warehouse : BaseEntity
    {

        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
