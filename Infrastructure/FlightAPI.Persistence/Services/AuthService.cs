using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.Abstractions.Services.Authentications;
using FlightAPI.Application.Abstractions.Token;
using FlightAPI.Application.DTOs;
using FlightAPI.Application.Exceptions;
using FlightAPI.Application.Features.Commands.AppUser.GoogleLogin;
using FlightAPI.Application.Features.Commands.AppUser.LoginUser;
using FlightAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Services
{


    public class AuthService : IAuthService
    {

        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly IUserService _userService;

       
        public AuthService(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<Domain.Entities.Identity.AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
        }

        async Task<GoogleLoginCommandResponse> CreateUserExternalAsync(AppUser user, string email, string name,UserLoginInfo info, int accessTokenLifeTime) //Yarın bir gün twitter, facebook ile giriş yapma özelliği gelirse diye eklendi tekrar etmesin diye.
        {
            bool result = user != null;

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        NameSurname = name,

                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                GoogleLoginCommandResponse res = new GoogleLoginCommandResponse();
                await _userManager.AddLoginAsync(user, info);
                res.Token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                res.NameSurname = user.NameSurname;
                await _userService.UpdateRefreshToken(res.Token.RefreshToken, user, res.Token.Expiration, 300);
                return res;
            }
            throw new Exception("Invalid external Auth");       
        }

        public async Task<GoogleLoginCommandResponse> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifeTime);
        }

        public async Task<LoginUserSuccessCommandResponse> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                LoginUserSuccessCommandResponse res = new LoginUserSuccessCommandResponse();
                res.Token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                res.NameSurname = user.NameSurname;
                await _userService.UpdateRefreshToken(res.Token.RefreshToken, user, res.Token.Expiration, 15);
                return res;
            }
            throw new Exception("Giriş Başarısız.");
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if(user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration,300);
                return token;
            }
            else
                throw new NotFoundUserException();
        }
    }
}
