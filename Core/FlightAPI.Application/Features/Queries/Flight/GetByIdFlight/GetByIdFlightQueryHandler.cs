using FlightAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Flight.GetByIdFlight
{
    public class GetByIdFlightQueryHandler : IRequestHandler<GetByIdFlightQueryRequest, GetByIdFlightQueryResponse>
    {
        IFlightReadRepository _flightReadRepository;

        public GetByIdFlightQueryHandler(IFlightReadRepository flightReadRepository)
        {
            _flightReadRepository = flightReadRepository;
        }

        public async Task<GetByIdFlightQueryResponse> Handle(GetByIdFlightQueryRequest request, CancellationToken cancellationToken)
        {
            FlightAPI.Domain.Entities.Flight flight =await _flightReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Capacity = flight.Capacity,
                Price = flight.Price,
                Departure = flight.Departure,
                Destination = flight.Destination,
                Date = flight.Date,
                IsActive = flight.IsActive,


            };
        }
    }
}
