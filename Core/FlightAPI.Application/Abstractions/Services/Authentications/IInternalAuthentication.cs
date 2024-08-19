using FlightAPI.Application.Features.Commands.AppUser.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {

        Task<LoginUserSuccessCommandResponse> LoginAsync(string usernameOrEmail,string password, int accessTokenLifeTime);

        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
