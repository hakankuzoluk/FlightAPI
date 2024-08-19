using FlightAPI.Application.Abstractions.Hubs;
using FlightAPI.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IFlightHubService, FlightHubService>();
            collection.AddSignalR();
        }
    }
}
