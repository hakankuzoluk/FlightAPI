﻿using FlightAPI.Application.Consts;
using FlightAPI.Application.CustomAttributes;
using FlightAPI.Application.Enums;
using FlightAPI.Application.Features.Commands.Flight.CreateFlight;
using FlightAPI.Application.Features.Commands.Flight.RemoveFlight;
using FlightAPI.Application.Features.Commands.Flight.UpdateFlight;
using FlightAPI.Application.Features.Queries.Flight.GetAllFlight;
using FlightAPI.Application.Features.Queries.Flight.GetAllFlightV2;
using FlightAPI.Application.Features.Queries.Flight.GetByIdFlight;
using FlightAPI.Application.Features.Queries.Flight.GetToFlightUser;
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

        [HttpGet("User")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Flights, ActionType = ActionType.Reading, Definition = "Read Flights")]
        public async Task<IActionResult> GetToFlightUser([FromQuery] GetToFlightUserQueryRequest getToFlightUserQueryRequest)
        {

            GetToFlightUserQueryResponse response = await _mediator.Send(getToFlightUserQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetId([FromRoute] GetByIdFlightQueryRequest getByIdFlightQueryRequest)
        {
            GetByIdFlightQueryResponse response = await _mediator.Send(getByIdFlightQueryRequest);
            
            return Ok(response);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFlightQueryV2Request getAllFlightQueryV2Request)
        {
            GetAllFlightQueryV2Response response = await _mediator.Send(getAllFlightQueryV2Request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Flights, ActionType = ActionType.Writing, Definition = "Add Flights")]
        public async Task<IActionResult> Post(CreateFlightCommandRequest createFlightCommandRequest)
        {
            CreateFlightCommandResponse response = await _mediator.Send(createFlightCommandRequest);
            
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Flights, ActionType = ActionType.Updating, Definition = "Update Flights")]
        public async Task<IActionResult> Put([FromBody] UpdateFlightCommandRequest updateFlightCommandRequest)
        {
            UpdateFlightCommandResponse response = await _mediator.Send(updateFlightCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Flights, ActionType = ActionType.Deleting, Definition = "Remove Flights")]
        public async Task<IActionResult> Delete([FromRoute] RemoveFlightCommendRequest removeFlightCommendRequest)
        {
            RemoveFlightCommendResponse response = await _mediator.Send(removeFlightCommendRequest);
            return Ok();
        }

    }
}
