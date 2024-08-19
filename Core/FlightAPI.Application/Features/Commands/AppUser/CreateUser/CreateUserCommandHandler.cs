using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.DTOs.User;
using FlightAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {

            _userService = userService;
            
        }


        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Pass = request.Pass,
                PassAgain = request.PassAgain,
                UserName = request.UserName,
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };       
        }   
    }
}
