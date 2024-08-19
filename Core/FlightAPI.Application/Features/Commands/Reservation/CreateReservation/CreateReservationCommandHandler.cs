using FlightAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, CreateReservationCommandResponse>
    {
        
        readonly IReservationService _reservationService;

        public CreateReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
        {
            await _reservationService.AddReservationAsync(new()
            {
                FlightId = request.FlightId,
                Quantity = request.Quantity,
            });

            return new();
        }
    }
}
