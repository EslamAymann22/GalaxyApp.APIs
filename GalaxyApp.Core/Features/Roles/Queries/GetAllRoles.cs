using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Core.Features.Roles.Queries
{
    public class GetAllRoleDto
    {
        public string RoleName { get; set; }
    }

    public class GetAllRolesModel : IRequest<BaseResponse<List<GetAllRoleDto>>>;

    public class GetAllRolesHandler : BaseResponseHandler, IRequestHandler<GetAllRolesModel, BaseResponse<List<GetAllRoleDto>>>
    {
        private readonly RoleManager<IdentityRole> _userRole;

        public GetAllRolesHandler(RoleManager<IdentityRole> userRole)
        {
            this._userRole = userRole;
        }

        public async Task<BaseResponse<List<GetAllRoleDto>>> Handle(GetAllRolesModel request, CancellationToken cancellationToken)
        {
            var roles =
            /*Enum.GetValues(typeof(UserRole))
            .Cast<UserRole>()
            .Select(role => new GetAllRoleDto { RoleName = role.ToString() })
            .ToList();*/

            (await _userRole.Roles.ToListAsync()).Select(R => new GetAllRoleDto { RoleName = R.Name }).ToList();

            return Success(roles);
        }
    }

}
