using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Abstractions.Hubs
{
    public interface IFlightHubService
    {
        Task FlightAddedMessageAsync(string message);
    }
}
