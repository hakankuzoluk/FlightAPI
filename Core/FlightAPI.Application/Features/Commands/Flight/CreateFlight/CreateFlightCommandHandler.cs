using FlightAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Flight.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommandRequest, CreateFlightCommandResponse>
    {
        readonly IFlightWriteRepository _flightWriteRepository;

        public CreateFlightCommandHandler(IFlightWriteRepository flightWriteRepository)
        {
            _flightWriteRepository = flightWriteRepository;
        }

        public async Task<CreateFlightCommandResponse> Handle(CreateFlightCommandRequest request, CancellationToken cancellationToken)
        {
            await _flightWriteRepository.AddAsync(new()
            {
                Departure = request.Departure,
                Destination = request.Destination,
                Date = request.Date,
                Capacity = request.Capacity,
                Price = request.Price
            });
            await _flightWriteRepository.SaveAsync();

            return new();
        }
    }
}
