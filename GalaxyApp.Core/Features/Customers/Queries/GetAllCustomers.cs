using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Core.ResponseBase.Paginations;
using GalaxyApp.Infrastructure.DbContextData;
using MediatR;

namespace GalaxyApp.Core.Features.Customers.Queries
{
    public class GetCustomersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class GetAllCustomersModel : PaginationParams, IRequest<PaginatedResponse<GetCustomersDto>>;

    public class GetAllCustomersHandler : BaseResponseHandler, IRequestHandler<GetAllCustomersModel, PaginatedResponse<GetCustomersDto>>
    {
        private readonly GalaxyDbContext _galaxyDb;

        public GetAllCustomersHandler(GalaxyDbContext galaxyDb)
        {
            this._galaxyDb = galaxyDb;
        }
        public async Task<PaginatedResponse<GetCustomersDto>> Handle(GetAllCustomersModel request, CancellationToken cancellationToken)
        {
            var Customers = await _galaxyDb.customers.Where(C => C.Name.ToLower().Contains(request.SearchFilter ?? "".ToLower()))
                .Select(c => new GetCustomersDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Phone = c.Phone
                }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Customers;
        }
    }

}
