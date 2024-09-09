using FlightAPI.Application.Repositories;
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
        readonly IFlightReadRepository _repository;

        public GetAllFlightQueryV2Handler(IFlightReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetAllFlightQueryV2Response> Handle(GetAllFlightQueryV2Request request, CancellationToken cancellationToken)
        {
            var flights = _repository.GetAll(false).Select(p => new
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

            var response = new GetAllFlightQueryV2Response
            {
                FlightsAll = flights,
                
            };

            return Task.FromResult(response);
        }
    }
}
