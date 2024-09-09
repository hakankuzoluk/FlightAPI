using FlightAPI.Application.Abstractions.Services;
using MediatR;

namespace FlightAPI.Application.Features.Queries.AppUser.HasAnyRole
{
    public class HasAnyRoleQueryHandler : IRequestHandler<HasAnyRoleQueryRequest, HasAnyRoleQueryResponse>
    {
        private readonly IUserService _userService;

        public HasAnyRoleQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HasAnyRoleQueryResponse> Handle(HasAnyRoleQueryRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcının herhangi bir role sahip olup olmadığını kontrol et
            var hasRole = await _userService.HasAnyRoleAsync(request.UserName);

            // Sonucu döndür
            return new HasAnyRoleQueryResponse { HasRole = hasRole };
        }
    }
}
