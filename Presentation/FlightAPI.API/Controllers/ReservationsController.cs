using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.Features.Commands.Reservation.CreateReservation;
using FlightAPI.Application.Features.Commands.Reservation.RemoveReservation;
using FlightAPI.Application.Features.Queries.Reservation.GetAllReservation;
using FlightAPI.Application.Features.Queries.Reservation.GetByIdReservation;
using FlightAPI.Application.ViewModels.Reservations;
using FlightAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ReservationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] GetByIdReservationQueryRequest getByIdReservationQueryRequest)
        {
            List<GetByIdReservationQueryResponse> response = await _mediator.Send(getByIdReservationQueryRequest);

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllReservation([FromQuery] GetAllReservationQueryRequest getAllReservationQueryRequest)
        {
            List<GetAllReservationQueryResponse> response = await _mediator.Send(getAllReservationQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateReservationCommandRequest createReservationCommandRequest)
        {
            CreateReservationCommandResponse response = await _mediator.Send(createReservationCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{ReservationId}")]
        public async Task<IActionResult> RemoveReservation([FromRoute] RemoveReservationCommandRequest removeReservationCommandRequest)
        {
            RemoveReservationCommandResponse response = await _mediator.Send(removeReservationCommandRequest);
            return Ok(response);
        }
    
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
