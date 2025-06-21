using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Roles.Queries
{

    public class GetUserRolesModel : IRequest<BaseResponse<List<GetAllRoleDto>>>
    {
        public string UserId { get; set; }
    }

    public class GetUserRolesHandler : BaseResponseHandler, IRequestHandler<GetUserRolesModel, BaseResponse<List<GetAllRoleDto>>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserRolesHandler(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<BaseResponse<List<GetAllRoleDto>>> Handle(GetUserRolesModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return Failed<List<GetAllRoleDto>>(System.Net.HttpStatusCode.NotFound, "User not found");

            var roles = await _userManager.GetRolesAsync(user);

            var roleDtos = roles.Select(role => new GetAllRoleDto { RoleName = role }).ToList();

            return Success(roleDtos);


        }
    }
}
