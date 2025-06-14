using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.CustomerFolder;
using GalaxyApp.Service.Interfaces;
using MediatR;

namespace GalaxyApp.Core.Features.Customers.Commands.Create.CreateCommandHandler
{

    public class CreateCustomerModel : IRequest<BaseResponse<CreateCustomerModel>>
    {
        public string Name { get; set; }
        public string Phone { get; set; }

    }

    public class CreateCustomerHandler : BaseResponseHandler,
                                         IRequestHandler<CreateCustomerModel, BaseResponse<CreateCustomerModel>>
    {
        private readonly ICustomerServices _customerServices;

        public CreateCustomerHandler(ICustomerServices customerServices)
        {
            this._customerServices = customerServices;
        }

        public async Task<BaseResponse<CreateCustomerModel>> Handle(CreateCustomerModel request, CancellationToken cancellationToken)
        {
            Customer CreatedCustomer = new Customer()
            {
                Name = request.Name,
                Phone = request.Phone
            };

            await _customerServices.AddAsync(CreatedCustomer);

            return Created(request);

        }
    }
}
