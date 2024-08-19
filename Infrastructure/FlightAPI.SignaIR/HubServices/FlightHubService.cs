using FlightAPI.Application.Abstractions.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.SignaIR.HubServices
{
    public class FlightHubService : IFlightHubService
    {
        public Task FlightAddedMessageAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
