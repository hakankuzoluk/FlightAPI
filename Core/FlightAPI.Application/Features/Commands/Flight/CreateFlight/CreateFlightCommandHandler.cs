using FlightAPI.Application.Abstractions.Hubs;
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
        readonly IFlightHubService _flightHubService;

        public CreateFlightCommandHandler(IFlightWriteRepository flightWriteRepository, IFlightHubService flightHubService)
        {
            _flightWriteRepository = flightWriteRepository;
            _flightHubService = flightHubService;
        }

        public async Task<CreateFlightCommandResponse> Handle(CreateFlightCommandRequest request, CancellationToken cancellationToken)
        {
            await _flightWriteRepository.AddAsync(new()
            {
                Departure = request.Departure,
                Destination = request.Destination,
                Date = request.Date, //Convert
                Capacity = request.Capacity,
                Price = request.Price
            });
            await _flightWriteRepository.SaveAsync();
            await _flightHubService.FlightAddedMessageAsync($"{request.Departure} - {request.Destination} seferli uçuş eklenmiştir.");
            return new();
        }
    }
}
