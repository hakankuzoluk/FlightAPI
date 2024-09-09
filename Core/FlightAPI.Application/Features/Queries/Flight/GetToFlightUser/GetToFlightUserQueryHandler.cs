using FlightAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetToFlightUser
{
    public class GetToFlightUserQueryHandler : IRequestHandler<GetToFlightUserQueryRequest, GetToFlightUserQueryResponse>
    {
        readonly IFlightReadRepository _flightReadRepository;

        public GetToFlightUserQueryHandler(IFlightReadRepository flightReadRepository)
        {
            _flightReadRepository = flightReadRepository;
        }

        public async Task<GetToFlightUserQueryResponse> Handle(GetToFlightUserQueryRequest request, CancellationToken cancellationToken)
        {
            var totalFlightCount = _flightReadRepository.GetAll(false).Count();
            var flights = _flightReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Departure,
                p.Destination,
                p.Date,
                p.Price,
                p.Capacity,
                p.CreatedDate,
                p.UpdateDate
            }).ToList();

            return new()
            {
                FlightsUser = flights,
                TotalFlightCountUser = totalFlightCount

            };
        }
    }
}
