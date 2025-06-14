using AutoMapper;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using GalaxyApp.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Accounts.Commands.Create
{

    public record CreateAccountModel : IRequest<BaseResponse<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }

    }


    public class CreateAccountHandler : BaseResponseHandler, IRequestHandler<CreateAccountModel, BaseResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateAccountHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<string>> Handle(CreateAccountModel request, CancellationToken cancellationToken)
        {

            var User = await _userManager.FindByNameAsync(request.UserName);
            if (User is not null)
                return Failed<string>(System.Net.HttpStatusCode.BadRequest, "This UserName Already Exists");

            User = _mapper.Map<AppUser>(request);
            var Result = await _userManager.CreateAsync(User, request.Password);

            if (!Result.Succeeded)
                return Failed<string>(System.Net.HttpStatusCode.BadRequest, Result.Errors.FirstOrDefault().Description);
            return Created("Account is created!");

        }
    }
}
