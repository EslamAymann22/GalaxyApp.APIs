using GalaxyApp.Core.Features.Roles.Commands;
using GalaxyApp.Core.Features.Roles.Queries;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.APIs.Controllers
{

    public class RoleController : BaseController
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<BaseResponse<List<GetAllRoleDto>>>> GetAllRoles()
        {
            return BaseOk(await _mediator.Send(new GetAllRolesModel()));
        }

        [Authorize]
        [HttpGet("GetUserRoles")]
        public async Task<ActionResult<BaseResponse<List<GetAllRoleDto>>>> GetUserRoles([FromQuery] GetUserRolesModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("AddRoleForUser")]
        public async Task<ActionResult<BaseResponse<string>>> AddRoleFor([FromQuery] AddRoleModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }
    }
}
