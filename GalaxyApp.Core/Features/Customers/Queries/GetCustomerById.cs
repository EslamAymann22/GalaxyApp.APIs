using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Infrastructure.DbContextData;
using MediatR;

namespace GalaxyApp.Core.Features.Customers.Queries
{
    public class GetCustomerByIdModel : IRequest<BaseResponse<GetCustomersDto>>
    {
        public int Id { get; set; }
    }


    public class GetCustomerByIdHandler : BaseResponseHandler, IRequestHandler<GetCustomerByIdModel, BaseResponse<GetCustomersDto>>
    {
        private readonly GalaxyDbContext _galaxyDb;
        public GetCustomerByIdHandler(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }
        public async Task<BaseResponse<GetCustomersDto>> Handle(GetCustomerByIdModel request, CancellationToken cancellationToken)
        {
            var Customer = await _galaxyDb.customers.FindAsync(request.Id);
            if (Customer is null)
                return Failed<GetCustomersDto>(System.Net.HttpStatusCode.NotFound, "Customer not found");

            return Success(new GetCustomersDto
            {
                Id = Customer.Id,
                Name = Customer.Name,
                Phone = Customer.Phone
            });
        }
    }

}
