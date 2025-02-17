using AutoMapper;
using GalaxyApp.Core.Features.Products.Queries.Handlers;
using GalaxyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.Mapping
{
    public class ProductProfile : Profile
    {

        public ProductProfile() {
            CreateMap<Product, GetAllProductDto>();
        }

    }
}
