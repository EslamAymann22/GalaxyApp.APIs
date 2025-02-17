using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{
    public class GetAllProductDto
    {

        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Evaluation { get; set; }
        public int Quantity { get; set; }

    }
}
