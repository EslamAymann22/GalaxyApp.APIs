using GalaxyApp.Core.Features.Accounts.Commands.Create;
using GalaxyApp.Core.Features.Accounts.Commands.Update.Password;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<string>>> CreateAccount([FromQuery] CreateAccountModel Model)
        {
            return BaseOk(await _mediator.Send(Model));
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<BaseResponse<string>>> ChangePassword([FromQuery] UpdateAccountPasswordModel Model)
        {
            return BaseOk(await _mediator.Send(Model));
        }

    }
}
