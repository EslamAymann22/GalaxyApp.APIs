using AutoMapper;
using GalaxyApp.Core.BaseResponse;
using GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto;
using GalaxyApp.Service.Interfaces.ProductInterface;
using MediatR;

namespace GalaxyApp.Core.Features.Products.Commands.Delete
{
    public record DeleteProductModel : IRequest<BaseResponse<GetAllProductDto>>
    {
        public int Id { get; set; }
    }

    public class DeleteProductHandler : BaseResponseHandler,
                                        IRequestHandler<DeleteProductModel, BaseResponse<GetAllProductDto>>

    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }
        public async Task<BaseResponse<GetAllProductDto>> Handle(DeleteProductModel request, CancellationToken cancellationToken)
        {
            var DeletedProduct = await _productService.GetByIdAsync(request.Id);
            if (DeletedProduct == null)
                return Failed<GetAllProductDto>(System.Net.HttpStatusCode.NotFound);

            _productService.Delete(DeletedProduct);
            var DeletedDto = _mapper.Map<GetAllProductDto>(DeletedProduct);
            return Success(DeletedDto);

        }
    }
}
