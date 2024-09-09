using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Reservation.GetByIdReservation
{
    public class GetByIdReservationQueryResponse
    {
        public int ReservationId { get; set; }

        public string UserName { get; set; }

        public string NameSurname { get; set; }

        public string UserId { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

    }
}