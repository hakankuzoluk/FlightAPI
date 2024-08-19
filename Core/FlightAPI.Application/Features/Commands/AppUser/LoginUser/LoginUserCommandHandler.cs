using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.Abstractions.Token;
using FlightAPI.Application.DTOs;
using FlightAPI.Application.Exceptions;
using FlightAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
           return await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);

            //return new LoginUserSuccessCommandResponse()
            //{  
            //    Token = token,
            //};

        }
    }
}
