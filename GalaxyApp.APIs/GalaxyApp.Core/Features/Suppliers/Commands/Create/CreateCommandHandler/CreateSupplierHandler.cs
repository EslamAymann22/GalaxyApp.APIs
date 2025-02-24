using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandHandler
{
    public record CreateSupplierModel : IRequest<BaseResponse<CreateSupplierModel>>
    {
        public string Name { get; set; }
    }
    public class CreateSupplierHandler : BaseResponseHandler
                                        , IRequestHandler<CreateSupplierModel, BaseResponse<CreateSupplierModel>>
    {
        private readonly ISupplierService _supplierService;

        public CreateSupplierHandler(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }


        public async Task<BaseResponse<CreateSupplierModel>> Handle(CreateSupplierModel request, CancellationToken cancellationToken)
        {
            Supplier AddedSupplier = new Supplier()
            {
                Name = request.Name
            };

            await _supplierService.AddAsync(AddedSupplier);

            return Success(request);

        }
    }
}
