using FlightAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Flight.RemoveFlight
{
    public class RemoveFlightCommendHandler : IRequestHandler<RemoveFlightCommendRequest, RemoveFlightCommendResponse>
    {
        
        readonly IFlightWriteRepository _flightWriteRepository;

        public RemoveFlightCommendHandler(IFlightWriteRepository flightWriteRepository)
        {
            _flightWriteRepository = flightWriteRepository;
        }

        public async Task<RemoveFlightCommendResponse> Handle(RemoveFlightCommendRequest request, CancellationToken cancellationToken)
        {
            await _flightWriteRepository.RemoveAsync(request.Id);
            await _flightWriteRepository.SaveAsync();
            return new();
        }
    }
}
