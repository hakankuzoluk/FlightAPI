using FlightAPI.Application.Features.Commands.AuthorizationEndpoints.AssignRoleEndpoint;
using FlightAPI.Application.Features.Queries.AuthorizationEndpoints.GetRolesToEndpoint;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQueryRequest getRolesToEndpointQueryRequest)
        {
            GetRolesToEndpointQueryResponse response = await _mediator.Send(getRolesToEndpointQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignEndpointCommandRequest assignEndpointCommandRequest)
        {
            assignEndpointCommandRequest.Type = typeof(Program);
            AssignEndpointCommandResponse response = await _mediator.Send(assignEndpointCommandRequest);
            return Ok(response);
        }
    }
}
