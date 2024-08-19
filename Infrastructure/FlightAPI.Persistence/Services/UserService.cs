using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.DTOs.User;
using FlightAPI.Application.Exceptions;
using FlightAPI.Application.Features.Commands.AppUser.CreateUser;
using FlightAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Services
{
    public class UserService : IUserService
    {

        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                UserName = model.UserName,
                Email = model.Email,
            }, model.Pass);

            CreateUserResponse response = new() { Succeeded = result.Succeeded};

            if (result.Succeeded)
                return new()
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarıyla oluşturulmuştur."
                };
            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur. ";
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }


        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }
    }
}
