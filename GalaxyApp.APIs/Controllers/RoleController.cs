using GalaxyApp.Core.Features.Roles.Commands;
using GalaxyApp.Core.Features.Roles.Queries;
using GalaxyApp.Core.ResponseBase.GeneralResponse;
using MediatR;
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
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<BaseResponse<List<GetAllRoleDto>>>> GetAllRoles()
        {
            return BaseOk(await _mediator.Send(new GetAllRolesModel()));
        }

        [HttpGet("GetUserRolesById")]
        public async Task<ActionResult<BaseResponse<List<GetAllRoleDto>>>> GetUserRoles([FromQuery] GetUserRolesModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }

        [HttpGet("AddRoleFor")]
        public async Task<ActionResult<BaseResponse<string>>> AddRoleFor([FromQuery] AddRoleModel model)
        {
            return BaseOk(await _mediator.Send(model));
        }
    }
}
