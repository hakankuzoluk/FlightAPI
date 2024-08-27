using FlightAPI.Application.Abstractions.Services.Configurations;
using FlightAPI.Application.Abstractions.Token;
using FlightAPI.Infrastructure.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, Infrastructure.Services.Token.TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
