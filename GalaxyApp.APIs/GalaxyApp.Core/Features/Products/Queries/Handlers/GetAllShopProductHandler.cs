﻿using AutoMapper;
using GalaxyApp.Core.BaseResponse;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.Features.Products.Queries.Handlers
{
    public record GetAllShopProductModel : IRequest<BaseResponse<List<GetAllShopProductDto>>>;

    public class GetAllShopProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllShopProductModel, BaseResponse<List<GetAllShopProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllShopProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllShopProductDto>>> Handle(GetAllShopProductModel request, CancellationToken cancellationToken)
        {
            var ProductList = await _productService.GetAllAsync();
            var MappedProduct = _mapper.Map<List<GetAllShopProductDto>>(ProductList);

            return Success(MappedProduct);
        }
    }

}
