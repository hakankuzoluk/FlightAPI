using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetAllFlight
{
    public class GetAllFlightQueryResponse
    {
        public int TotalCount { get; set; }
        public object Flights { get; set; }
    }


}
