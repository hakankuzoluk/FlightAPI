using FlightAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Flight.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommandRequest, UpdateFlightCommandResponse>
    {
        readonly IFlightReadRepository _flightReadRepository;
        readonly IFlightWriteRepository _flightWriteRepository;

        public UpdateFlightCommandHandler(IFlightReadRepository flightReadRepository, IFlightWriteRepository flightWriteRepository)
        {
            _flightReadRepository = flightReadRepository;
            _flightWriteRepository = flightWriteRepository;
        }

        
        public async Task<UpdateFlightCommandResponse> Handle(UpdateFlightCommandRequest request, CancellationToken cancellationToken)
        {
            FlightAPI.Domain.Entities.Flight flight = await _flightReadRepository.GetByIdAsync(request.Id);
            flight.Departure = request.Departure;
            flight.Price = request.Price;
            flight.Capacity = request.Capacity;
            flight.Date = request.Date;
            flight.IsActive = request.IsActive;
            flight.Destination = request.Destination;

            await _flightWriteRepository.SaveAsync();
            return new();
        }
    }
}
