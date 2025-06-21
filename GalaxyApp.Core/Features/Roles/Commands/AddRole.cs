using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Roles.Commands
{



    public class AddRoleModel : IRequest<BaseResponse<string>>
    {
        public string UserId { get; set; }
        public UserRole Role { get; set; }
    }
    public class AddRoleHandler : BaseResponseHandler, IRequestHandler<AddRoleModel, BaseResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;

        public AddRoleHandler(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<BaseResponse<string>> Handle(AddRoleModel request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return Failed<string>(System.Net.HttpStatusCode.NotFound, "User not found");

            var IsRole = Enum.IsDefined(typeof(UserRole), request.Role);
            if (!IsRole)
                return Failed<string>(System.Net.HttpStatusCode.NotFound, "This isn't a role");

            var UserRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, UserRoles);
            await _userManager.AddToRoleAsync(user, request.Role.ToString());

            return Success($"{user.FirstName} now is a {Enum.GetName(typeof(UserRole), request.Role)}");


        }
    }
}
