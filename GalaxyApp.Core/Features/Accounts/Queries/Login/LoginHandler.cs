using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.Identity;
using GalaxyApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Accounts.Queries.Login
{
    public class LoginModel : IRequest<BaseResponse<LoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginHandler : BaseResponseHandler, IRequestHandler<LoginModel, BaseResponse<LoginDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthenticationServices _authenticationServices;

        public LoginHandler(UserManager<AppUser> userManager, IAuthenticationServices authenticationServices)
        {

            this._userManager = userManager;
            this._authenticationServices = authenticationServices;
        }

        public async Task<BaseResponse<LoginDto>> Handle(LoginModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            bool LoginSuccess = true;
            if (user is null)
                LoginSuccess = false;

            LoginSuccess &= await _userManager.CheckPasswordAsync(user, request.Password);

            if (!LoginSuccess)
                return Failed<LoginDto>(System.Net.HttpStatusCode.BadRequest, "Password or Email isn't correct!!");

            var Response = new LoginDto()
            {
                UserName = user.UserName,
                Token = await _authenticationServices.GetJWTTokenAsync(user, _userManager),
                UserId = user.Id,
                UserRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };


            return Success(Response);
        }

    }
}
