using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandRequest : IRequest<CreateReservationCommandResponse>
    {
        public int FlightId { get; set; }
        public int Quantity { get; set; }
    }
}
