using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.ViewModels.Reservations
{
    public class VM_Create_Reservations
    {
        public int FlightId { get; set; }

        public int Quantity { get; set; }
    }
}
