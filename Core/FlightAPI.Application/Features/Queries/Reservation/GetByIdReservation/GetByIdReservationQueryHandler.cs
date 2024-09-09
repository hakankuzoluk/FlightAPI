using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Reservation.GetByIdReservation
{
    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQueryRequest, List<GetByIdReservationQueryResponse>>
    {

        readonly IReservationService _reservationService;

        public GetByIdReservationQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        async Task<List<GetByIdReservationQueryResponse>> IRequestHandler<GetByIdReservationQueryRequest, List<GetByIdReservationQueryResponse>>.Handle(GetByIdReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetReservationsAsync();
            return reservations.Select(ra => new GetByIdReservationQueryResponse
            {
                ReservationId = ra.Id,
                UserName = ra.User.UserName,
                NameSurname = ra.User.NameSurname,
                UserId = ra.User.Id,
                Departure = ra.Flight.Departure,
                Destination = ra.Flight.Destination,
                Date = ra.Flight.Date,
                Price = ra.Flight.Price,
                Quantity = ra.Quantity,
            }).ToList();
        }
    }
}