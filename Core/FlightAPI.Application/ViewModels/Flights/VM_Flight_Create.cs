using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.ViewModels.Flights
{
    public class VM_Flight_Create
    {
        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public int Capacity { get; set; }

        public float Price { get; set; }
    }
}
