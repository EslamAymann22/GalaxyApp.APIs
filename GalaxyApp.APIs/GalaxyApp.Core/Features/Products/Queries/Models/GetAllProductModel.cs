using Azure.Core;
using GalaxyApp.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.Features.Products.Queries.Models
{
    public record GetAllProductModel : IRequest<List<Product>>;
}
