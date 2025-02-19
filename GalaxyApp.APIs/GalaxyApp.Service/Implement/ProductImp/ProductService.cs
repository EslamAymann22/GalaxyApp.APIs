﻿using GalaxyApp.Data.Entities;
using GalaxyApp.Infrastructure.Repositories.Interfaces;
using GalaxyApp.Service.Interfaces.ProductInterface;
using System.Net;

namespace GalaxyApp.Service.Implement.ProductImp
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }

        /* public async Task<bool> AddAsync(Product product)
         {
             var productToAdd = (await _productRepo.GetAllAsync())
                 .Where(P => P.Color == product.Color && P.Name == product.Name).FirstOrDefault();

             if (productToAdd != null) return false;

             await _productRepo.AddAsync(product);
             return true;

         }*/

        public async Task AddAsync(Product product)
        => await _productRepo.AddAsync(product);

        public async Task<List<Product>> GetAllAsync()
        => await _productRepo.GetAllAsync();

        public async Task<Product> GetByIdAsync(int Id)
        => await _productRepo.GetByIdAsync(Id);

        public IQueryable<Product> GetQueryableNoTracking()
        => _productRepo.GetQueryableNoTracking();
        public async Task<HttpStatusCode> CheckProductUpdate(Product product)
        {
            var SearchProd = await GetByIdAsync(product.Id);

            if (SearchProd is null)
                return HttpStatusCode.NotFound;

            if ((await GetAllAsync())
                .Any(P => P.Name == product.Name
                && P.Color == product.Color
                && P.PurchasingPrice == product.PurchasingPrice
                && P.Id != product.Id))
            {
                return HttpStatusCode.Conflict;
            }

            return HttpStatusCode.OK;
        }

        public void Update(Product product)
        {

            _productRepo.Update(product);

        }

        public void Delete(Product product)
        => _productRepo.Delete(product);

        public IQueryable<Product> ApplyOrderByAndSearchFilter(IQueryable<Product> Data, string OrderBy, string Search)
        {
            if (Search != null)
            {
                Data = Data.Where(X => X.Name.ToLower().Contains(Search.ToLower())
                                || X.Color.ToLower().Contains(Search.ToLower()));
            }
            if (OrderBy != null)
            {
                Data = OrderBy.ToLower() switch
                {
                    "name" => Data.OrderBy(x => x.Name),
                    "namedes" => Data.OrderByDescending(x => x.Name),
                    "price" => Data.OrderBy(x => x.sellingPrice),
                    "pricedes" => Data.OrderByDescending(x => x.sellingPrice),
                    "evaluation" => Data.OrderBy(x => x.Evaluation),
                    "evaluationdes" => Data.OrderByDescending(x => x.Evaluation),
                    "discount" => Data.OrderBy(x => x.Discount),
                    "discountdes" => Data.OrderByDescending(x => x.Discount),
                    "quantity" => Data.OrderBy(x => x.ShopQuantity + x.WarehouseQuantity),
                    "quantitydes" => Data.OrderByDescending(x => x.ShopQuantity + x.WarehouseQuantity),
                    _ => Data.OrderBy(x => x.Id)
                };
            }

            return Data;
        }
    }
}
