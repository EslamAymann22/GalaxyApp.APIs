using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Accounts.Commands.Update.Password
{

    public record UpdateAccountPasswordModel : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

    }
    public class UpdateAccountPasswordHandler : BaseResponseHandler,
                                                IRequestHandler<UpdateAccountPasswordModel, BaseResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateAccountPasswordHandler(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<BaseResponse<string>> Handle(UpdateAccountPasswordModel request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);

            var Result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (!Result.Succeeded)
                return Failed<string>(System.Net.HttpStatusCode.BadRequest, Result.Errors.FirstOrDefault().Description);

            return Success("Password Changed Successfully");
        }
    }
}
