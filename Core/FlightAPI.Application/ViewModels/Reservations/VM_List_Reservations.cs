using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.ViewModels.Reservations
{
    public class VM_List_Reservations
    {
            public string UserId { get; set; }
            public int FlightId { get; set; }
            public int ReservationId { get; set; }
            public string UserName { get; set; }
            public string Departure { get; set; }
            public string Name { get; set; }
            public string Destination { get; set; }
            public DateTime ReservationTime { get; set; }
            public int Quantity { get; set; }
        
    }
}
