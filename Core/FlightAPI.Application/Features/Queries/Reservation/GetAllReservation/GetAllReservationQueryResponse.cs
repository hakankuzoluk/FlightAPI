using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Reservation.GetAllReservation
{
    public class GetAllReservationQueryResponse 
    {
        public int ReservationId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime ReservationTime { get; set; }
        public int Quantity { get; set; }
    }
}
