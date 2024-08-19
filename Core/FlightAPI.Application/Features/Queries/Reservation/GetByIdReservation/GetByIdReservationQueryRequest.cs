using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Features.Queries.Reservation.GetByIdReservation
{
    public class GetByIdReservationQueryRequest : IRequest<List<GetByIdReservationQueryResponse>>
    {
    }
}
