using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Flight.RemoveFlight
{
    public class RemoveFlightCommendRequest : IRequest<RemoveFlightCommendResponse>
    {
        public int Id { get; set; }
    }
}
