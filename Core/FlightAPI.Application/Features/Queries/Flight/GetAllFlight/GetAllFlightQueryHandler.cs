using FlightAPI.Application.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightAPI.Domain.Entities;
using FlightAPI.Application.RequestParameters;

namespace FlightAPI.Application.Features.Queries.Flight.GetAllFlight
{
    public class GetAllFlightQueryHandler : IRequestHandler<GetAllFlightQueryRequest, GetAllFlightQueryResponse>
    {
        readonly IFlightReadRepository _flightReadRepository;

        public GetAllFlightQueryHandler(IFlightReadRepository flightReadRepository)
        {
            _flightReadRepository = flightReadRepository;
        }

        public async Task<GetAllFlightQueryResponse> Handle(GetAllFlightQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _flightReadRepository.GetAll(false).Count();
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
                Flights = flights,
                TotalCount = totalCount
                
            };
        }
    }
}
