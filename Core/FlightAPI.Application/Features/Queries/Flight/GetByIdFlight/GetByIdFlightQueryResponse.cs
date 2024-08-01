using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetByIdFlight
{
    public class GetByIdFlightQueryResponse
    {
        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public int Capacity { get; set; }

        public float Price { get; set; }

        public bool IsActive { get; set; }
    }
}
