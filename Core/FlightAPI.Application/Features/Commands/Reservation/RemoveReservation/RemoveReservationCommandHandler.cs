using FlightAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Commands.Reservation.RemoveReservation
{
    public class RemoveReservationCommandHandler : IRequestHandler<RemoveReservationCommandRequest, RemoveReservationCommandResponse>
    {
        readonly IReservationService _reservationService;

        public RemoveReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<RemoveReservationCommandResponse> Handle(RemoveReservationCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _reservationService.RemoveReservationAsync(request.ReservationId);
            return new()
            {
                IsSuccess = result
            };
        }
    }
}
