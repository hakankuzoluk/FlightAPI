using FlightAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.AuthorizationEndpoints.AssignRoleEndpoint
{
    public class AssignEndpointCommandHandler : IRequestHandler<AssignEndpointCommandRequest, AssignEndpointCommandResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public AssignEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<AssignEndpointCommandResponse> Handle(AssignEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
            return new()
            {

            };
        }
    }
}
