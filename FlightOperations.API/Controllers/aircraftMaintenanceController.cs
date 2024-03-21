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
    public class aircraftMaintenanceController : ControllerBase
    {
        private IaircraftServices _aircraftServices;
        private readonly appSettings _appSettings;
        public aircraftMaintenanceController(IaircraftServices aircraftService, IOptions<appSettings> appSettings)
        {
            _aircraftServices = aircraftService;
            _appSettings = appSettings.Value;
        }
        #region AircraftMaintenance
        [HttpPost()]
        public IActionResult CreateAircraftMaintenance([FromBody]AircraftMaintenanceDTO_Edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _aircraftServices.CreateAircraftMaintenance(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet()]
        public IActionResult GetAllAircraftMaintenance()
        {
            try
            {
                var profileDTO = _aircraftServices.GetAllAircraftMaintenance();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAircraftMaintenance(int id)
        {
            try
            {
                var profileDTO = _aircraftServices.GetAircraftMaintenance(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAircraftMaintenance(int id)
        {
            try
            {
                _aircraftServices.DeleteAircraftMaintenance(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAircrafType(int id, [FromBody]AircraftMaintenanceDTO_Edit data)
        {
            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _aircraftServices.UpdateAircraftMaintenance(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region Maintenance Schedule
        [HttpPost("schedule")]
        public IActionResult CreateMaintenanceSchedule([FromBody]MaintenanceScheduleDTO_Edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _aircraftServices.CreateMaintenanceSchedule(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("schedule")]
        public IActionResult GetAllMaintenanceSchedule()
        {
            try
            {
                var profileDTO = _aircraftServices.GetAllMaintenanceSchedule();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("schedule/calendar")]
        public IActionResult GetAllMaintenanceSchedule([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            try
            {
                var calendar = _aircraftServices.GetAllMaintenanceScheduleCalendar(from,to);

                return Ok(calendar);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("schedule/{id}")]
        public IActionResult GetMaintenanceSchedule(int id)
        {
            try
            {
                var profileDTO = _aircraftServices.GetMaintenanceSchedule(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("schedule/{id}")]
        public IActionResult DeleteMaintenanceSchedule(int id)
        {
            try
            {
                _aircraftServices.DeleteMaintenanceSchedule(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("schedule/{id}")]
        public IActionResult UpdateMaintenanceSchedule(int id, [FromBody]MaintenanceScheduleDTO_Edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _aircraftServices.UpdateMaintenanceSchedule(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("schedule")]
        public IActionResult UpdateMaintenanceSchedule([FromBody]MaintenanceScheduleDTO_Edit data)
        {

            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _aircraftServices.UpdateMaintenanceSchedule_ByMany(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

    }
}