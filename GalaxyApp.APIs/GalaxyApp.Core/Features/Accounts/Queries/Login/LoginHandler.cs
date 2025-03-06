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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthenticationServices _authenticationServices;

        public LoginHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IAuthenticationServices authenticationServices)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._authenticationServices = authenticationServices;
        }

        public async Task<BaseResponse<LoginDto>> Handle(LoginModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var check = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!check) return Failed<LoginDto>(System.Net.HttpStatusCode.BadRequest, "Password or Email isn't correct!!");

            var SignInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!SignInResult.Succeeded)
                return Failed<LoginDto>(System.Net.HttpStatusCode.BadRequest);

            var token = await _authenticationServices.GetJWTTokenAsync(user, _userManager);

            var Response = new LoginDto()
            {
                UserName = user.UserName,
                Token = token
            };

            return Success(Response);
        }

    }
}
