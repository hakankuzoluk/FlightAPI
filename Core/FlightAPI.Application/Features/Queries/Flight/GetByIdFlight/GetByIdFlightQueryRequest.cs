using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetByIdFlight
{
    public class GetByIdFlightQueryRequest : IRequest<GetByIdFlightQueryResponse>
    {
        public int Id { get; set; }
    }
}
