using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using FlightOperations.Model.DTO;
using FlightOperations.Services;
using FlightOperations.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlightOperations.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IflightscheduleServices _flightscheduleServices;
        private IflightOperationsServices _flightOpsServices;
        private IcrewPlanningServices _crewPlanningServices;
        private readonly appSettings _appSettings;
        public DashboardController(IflightscheduleServices flightscheduleServices, IflightOperationsServices flightOpsServices,
         IcrewPlanningServices crewPlanningServices, IOptions<appSettings> appSettings)
        {
            _flightscheduleServices = flightscheduleServices;
            _flightOpsServices = flightOpsServices;
            _crewPlanningServices = crewPlanningServices;
            _appSettings = appSettings.Value;
        }
        [HttpPost("number-of-flights")]
        public IActionResult NumberOfFlights(NumberOfFlightsDTO data)
        {
            try
            {
                var profileDTO = _flightscheduleServices.NumberOfFlights(data);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPost("total-delayed-flights")]
        public IActionResult DelayedFlights(DelayedFlightsDTO data)
        {
            try
            {
                var profileDTO = _flightOpsServices.NumberOfDelayedFlights(data);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPost("crews-assigned")]
        public IActionResult NumberOfCrews(CrewsAssignedDTO data)
        {
            try
            {
                var profileDTO = _crewPlanningServices.NumberOfCrews(data);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}