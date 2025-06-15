using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandHandler
{
    public record CreateSupplierModel : IRequest<BaseResponse<string>>
    {
        public string Name { get; set; }
        public IFormFile? Photo { get; set; }

    }
    public class CreateSupplierHandler : BaseResponseHandler
                                        , IRequestHandler<CreateSupplierModel, BaseResponse<string>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IFileServices _fileServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateSupplierHandler(ISupplierService supplierService, IFileServices fileServices, IHttpContextAccessor httpContextAccessor)
        {
            this._supplierService = supplierService;
            this._fileServices = fileServices;
            this._httpContextAccessor = httpContextAccessor;
        }


        public async Task<BaseResponse<string>> Handle(CreateSupplierModel request, CancellationToken cancellationToken)
        {
            Supplier AddedSupplier = new Supplier()
            {
                Name = request.Name
            };
            if (request.Photo is not null)
            {
                var FilePath = _fileServices.UploadFile(request.Photo, "Suppliers");
                var Request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                AddedSupplier.PhotoUrl = $"{baseUrl}/{FilePath}";

            }

            await _supplierService.AddAsync(AddedSupplier);

            return Created("Supplier Add Successfully");

        }
    }
}
