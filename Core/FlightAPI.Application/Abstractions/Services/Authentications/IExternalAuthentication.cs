using FlightAPI.Application.Features.Commands.AppUser.GoogleLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {

        Task<GoogleLoginCommandResponse> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
