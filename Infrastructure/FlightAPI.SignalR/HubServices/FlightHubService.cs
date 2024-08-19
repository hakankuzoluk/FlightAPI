using FlightAPI.Application.Abstractions.Hubs;
using FlightAPI.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.SignalR.HubServices
{
    internal class FlightHubService : IFlightHubService
    {
        readonly IHubContext<FlightHub> _hubContext;

        public FlightHubService(IHubContext<FlightHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task FlightAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.FlightAddedMessage, message);
        }
    }
}
