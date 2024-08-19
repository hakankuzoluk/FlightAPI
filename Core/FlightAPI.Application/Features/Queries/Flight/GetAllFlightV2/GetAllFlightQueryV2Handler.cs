using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetAllFlightV2
{
    internal class GetAllFlightQueryV2Handler : IRequestHandler<GetAllFlightQueryV2Request, GetAllFlightQueryV2Response>
    {
        readonly IFlightReadRepository _flightReadRepository;

        public GetAllFlightQueryHandler(IFlightReadRepository flightReadRepository)
        {
            _flightReadRepository = flightReadRepository;
        }
        public Task<GetAllFlightQueryV2Response> Handle(GetAllFlightQueryV2Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
