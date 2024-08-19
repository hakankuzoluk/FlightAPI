using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Reservation.RemoveReservation
{
    public class RemoveReservationCommandRequest : IRequest<RemoveReservationCommandResponse>
    {
        public int ReservationId { get; set; }
    }
}
