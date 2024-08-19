using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetAllFlight
{
    public class GetAllFlightQueryRequest : IRequest<GetAllFlightQueryResponse>

    {

        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;



    }
}
