using FlightAPI.Domain.Entities.Common;
using FlightAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }

        public int FlightId { get; set; }

        public int NumberOfPeople { get; set; }

        public int Quantity { get; set; }

        public DateTime ReservationTime { get; set; }

        public AppUser User { get; set; }

        public Flight Flight { get; set; }
    }
}
