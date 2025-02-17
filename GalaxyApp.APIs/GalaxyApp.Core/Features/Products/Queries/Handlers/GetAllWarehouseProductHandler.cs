using AutoMapper;
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
    public record GetAllWarehouseProductModel : IRequest<BaseResponse<List<GetAllWarehouseProductDto>>>;

    public class GetAllWarehouseProductHandler : BaseResponseHandler,

        IRequestHandler<GetAllWarehouseProductModel, BaseResponse<List<GetAllWarehouseProductDto>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllWarehouseProductHandler(IProductService productService
                                    , IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllWarehouseProductDto>>> Handle(GetAllWarehouseProductModel request, CancellationToken cancellationToken)
        {
            var ProductList = await _productService.GetAllAsync();
            var MappedProduct = _mapper.Map<List<GetAllWarehouseProductDto>>(ProductList);

            return Success(MappedProduct);
        }
    }

}
