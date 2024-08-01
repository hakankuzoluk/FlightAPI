using FlightAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Domain.Entities
{
    public class Flight : BaseEntity
    {
        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public int Capacity { get; set; }

        public float Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
