using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetToFlightUser
{
    public class GetToFlightUserQueryResponse
    {
        public int TotalFlightCountUser { get; set; }
        public object FlightsUser { get; set; }
    }
}
