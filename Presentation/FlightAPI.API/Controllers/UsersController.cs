using FlightAPI.Application.CustomAttributes;
using FlightAPI.Application.Features.Commands.AppUser.AssignRoleToUser;
using FlightAPI.Application.Features.Commands.AppUser.CreateUser;
using FlightAPI.Application.Features.Commands.AppUser.GoogleLogin;
using FlightAPI.Application.Features.Commands.AppUser.LoginUser;
using FlightAPI.Application.Features.Queries.AppUser.GetAllUsers;
using FlightAPI.Application.Features.Queries.AppUser.GetRolesToUser;
using FlightAPI.Application.Features.Queries.AppUser.HasAnyRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes ="Admin")]
        [AuthorizeDefinition(ActionType = Application.Enums.ActionType.Reading, Definition ="Get All Users", Menu ="Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = Application.Enums.ActionType.Writing, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-roles-to-user/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = Application.Enums.ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest getRolesToUserQueryRequest)
        {

            GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
          
            return Ok(response);
        }
        [HttpGet("has-any-role")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> HasAnyRole()
        {
            var userName = User.Identity?.Name;
            var hasRole = await _mediator.Send(new HasAnyRoleQueryRequest { UserName = userName });
            return Ok(hasRole);
        }

    }
}
