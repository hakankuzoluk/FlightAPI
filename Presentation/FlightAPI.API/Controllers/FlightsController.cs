using FlightAPI.Application.Features.Commands.Flight.CreateFlight;
using FlightAPI.Application.Features.Commands.Flight.RemoveFlight;
using FlightAPI.Application.Features.Commands.Flight.UpdateFlight;
using FlightAPI.Application.Features.Queries.Flight.GetAllFlight;
using FlightAPI.Application.Features.Queries.Flight.GetByIdFlight;
using FlightAPI.Application.Repositories;
using FlightAPI.Application.RequestParameters;
using FlightAPI.Application.ViewModels.Flights;
using FlightAPI.Application.ViewModels.Users;
using FlightAPI.Domain.Entities;
using FlightAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class FlightsController : ControllerBase
    {
        readonly private IFlightReadRepository _flightReadRepository;
        readonly private IFlightWriteRepository _flightWriteRepository;
        readonly IMediator _mediator;

        public FlightsController(IFlightReadRepository flightReadRepository, IFlightWriteRepository flightWriteRepository, IMediator mediator)
        {
            _flightReadRepository = flightReadRepository;
            _flightWriteRepository = flightWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFlightQueryRequest getAllFlightQueryRequest)
        {

            GetAllFlightQueryResponse response = await _mediator.Send(getAllFlightQueryRequest);
            return Ok(response);

          
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetId([FromRoute] GetByIdFlightQueryRequest getByIdFlightQueryRequest)
        {
            GetByIdFlightQueryResponse response = await _mediator.Send(getByIdFlightQueryRequest);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFlightCommandRequest createFlightCommandRequest)
        {
            CreateFlightCommandResponse response = await _mediator.Send(createFlightCommandRequest);
            
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateFlightCommandRequest updateFlightCommandRequest)
        {
            UpdateFlightCommandResponse response = await _mediator.Send(updateFlightCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] RemoveFlightCommendRequest removeFlightCommendRequest)
        {
            RemoveFlightCommendResponse response = await _mediator.Send(removeFlightCommendRequest);
            return Ok();
        }

    }
}
