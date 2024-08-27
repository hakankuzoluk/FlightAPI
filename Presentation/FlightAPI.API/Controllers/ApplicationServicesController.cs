﻿using FlightAPI.Application.Abstractions.Services.Configurations;
using FlightAPI.Application.CustomAttributes;
using FlightAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType =ActionType.Reading, Definition ="Get Authorize Definition Endpoint", Menu ="Application Services")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas =   _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
