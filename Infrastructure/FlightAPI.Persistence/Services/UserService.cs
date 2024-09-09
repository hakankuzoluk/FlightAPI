using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.DTOs.User;
using FlightAPI.Application.Exceptions;
using FlightAPI.Application.Features.Commands.AppUser.CreateUser;
using FlightAPI.Application.Repositories;
using FlightAPI.Domain.Entities;
using FlightAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
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

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            return users.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName
            }).ToList();
        }

        public int TotalUsersCount => _userManager.Users.Count();

        public async Task AssignRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, roles);
            }
        }

        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrName);
            if(user == null)
                user = await _userManager.FindByNameAsync(userIdOrName);
            
            if (user != null) 
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            var userRoles = await GetRolesToUserAsync(name);

            if(!userRoles.Any())
                 return false; 

            Endpoint? endpoint = await _endpointReadRepository.Table
                .Include(e=>e.Roles)
                .FirstOrDefaultAsync(e =>e.Code == code);

            if(endpoint == null) return false;

            var hasRole = false;

            var endpointRoles = endpoint.Roles.Select(r => r.Name);


            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                        return true;
            }

            return false;

        }
        public async Task<bool> HasAnyRoleAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return false;

            var roles = await _userManager.GetRolesAsync(user);
            return roles.Count > 0; // En az bir role sahip mi
        }
    }
}
