using MediatR;

namespace FlightAPI.Application.Features.Queries.AppUser.HasAnyRole
{
    public class HasAnyRoleQueryRequest : IRequest<HasAnyRoleQueryResponse>
    {
        public string UserName { get; set; }
    }
}
