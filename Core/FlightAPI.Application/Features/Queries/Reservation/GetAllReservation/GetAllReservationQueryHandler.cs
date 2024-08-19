using FlightAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Reservation.GetAllReservation
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQueryRequest, List<GetAllReservationQueryResponse>>
    {

        readonly IReservationService _reservationService;

        public GetAllReservationQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        async Task<List<GetAllReservationQueryResponse>> IRequestHandler<GetAllReservationQueryRequest, List<GetAllReservationQueryResponse>>.Handle(GetAllReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetAllReservationAsync();
            return reservations.Select(r => new GetAllReservationQueryResponse
            {
                UserName = r.UserName,
                Name = r.Name,
                ReservationId = r.ReservationId,
                Destination = r.Destination,
                Departure = r.Departure,
                ReservationTime = r.ReservationTime,
                Quantity = r.Quantity
            }).ToList();
        }
    }
}
