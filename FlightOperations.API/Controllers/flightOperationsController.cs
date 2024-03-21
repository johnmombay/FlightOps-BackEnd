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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlightOperations.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class flightOperationsController : ControllerBase
    {
        private IflightOperationsServices _flightOpsServices;
        private readonly appSettings _appSettings;
        public flightOperationsController(IflightOperationsServices flightOpsServices, IOptions<appSettings> appSettings)
        {
            _flightOpsServices = flightOpsServices;
            _appSettings = appSettings.Value;
        }
        [HttpPost("AircraftSchedule/Assign")]
        public IActionResult AssignAircraftSchedule(AssignAircraftSchedDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);

                var dto = _flightOpsServices.AssignAircraft(data, userId);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("AircraftSchedule/Update")]
        public IActionResult UpdateAircraftSchedule(UpdateAircraftSchedDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);

                var dto = _flightOpsServices.UpdateAircraftSched(data, userId);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("AircraftSchedule/Actual")]
        public IActionResult SetActual(ActualFlightDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);

                var dto = _flightOpsServices.SetActual(data, userId);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("AircraftSchedule/{AirlineScheduleID}/{ResourceID}")]
        public IActionResult GetAircraftSchedule(int AirlineScheduleID,int ResourceID)
        {
            try
            {
                // save
                var dto = _flightOpsServices.GetAllAircraftSchedules_byResourceID(AirlineScheduleID, ResourceID);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("AircraftSchedule/AllEvents")]
        public IActionResult GetAircraftSchedule(DateParamDTO param)
        {
            try
            {               
                // save
                var dto = _flightOpsServices.GetAircraftSchedules(param);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("AircraftSchedule/AllEvents/Range")]
        public IActionResult GetAircraftSchedule([FromQuery] DateTime From, [FromQuery] DateTime To)
        {
            try
            {
                
                // save
                var dto = _flightOpsServices.GetAircraftSchedules(new  DateParamDTO { From = From.AddDays(-1), To = To.AddDays(1) }) ;

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("Schedule-Resource/published")]
        public IActionResult GetAllPublishedScheduleResource()
        {
            try
            {
                // save
                var dto = _flightOpsServices.GetAllPublishedScheduleResource();

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}