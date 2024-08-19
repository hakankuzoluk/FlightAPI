using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.Abstractions.Token;
using FlightAPI.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.AppUser.GoogleLogin
{

    
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {

        readonly IAuthService _authService;
        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.GoogleLoginAsync(request.IdToken, 900);
          
          
        }
    }
}
