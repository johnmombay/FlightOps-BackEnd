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
    public class commercialPlanningController : Controller
    {

        private IcommercialPlanningServices _commPServices;
        private readonly appSettings _appSettings;
        public commercialPlanningController(IcommercialPlanningServices commPServices, IOptions<appSettings> appSettings)
        {
            _commPServices = commPServices;
            _appSettings = appSettings.Value;
        }
        #region Airline Schedule
        [HttpPost("airline-schedule")]
        public IActionResult CreateAirlineSchedule([FromBody]AirlineScheduleDTO_edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _commPServices.CreateAirlineSchedule(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airline-schedule")]
        public IActionResult GetAllAirlineSchedule()
        {
            try
            { 
            var profileDTO = _commPServices.GetAllAirlineSchedule();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airline-schedule/{id}")]
        public IActionResult GetAirlineSchedule(int id)
        {
            try
            { 
            var profileDTO = _commPServices.GetAirlineSchedule(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("airline-schedule/{id}")]
        public IActionResult DeleteAirlineSchedule(int id)
        {
            try
            { 
            _commPServices.DeleteAirlineSchedule(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("airline-schedule/{id}")]
        public IActionResult UpdateAirlineSchedule(int id, [FromBody]AirlineScheduleDTO_edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _commPServices.UpdateAirlineSchedule(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("Publish")]
        public IActionResult PublishAirlineSchedule(AirlineScheduleDTO_verify data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _commPServices.PublishAirlineSchedule(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("Unpublish")]
        public IActionResult UnpublishAirlineSchedule(AirlineScheduleDTO_verify data)
        {

            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;
                // check if fligts assigned. If yes, cannot unpublish

                _commPServices.UnpublishAirlineSchedule(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region Schedule AircraftType
        [HttpPost("airline-schedule/aircraft-type")]
        public IActionResult CreateSchedule_AircraftType([FromBody]Schedule_AircraftTypeDTO_edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _commPServices.CreateSchedule_AircraftType(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airline-schedule/aircraft-type")]
        public IActionResult GetAllSchedule_AircraftType()
        {
            try
            { 
            var profileDTO = _commPServices.GetAllSchedule_AircraftType();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airline-schedule/{id}/aircraft-type/")]
        public IActionResult GetAllSchedule_AircraftType_ByAirlineSched(int id)
        {
            try
            { 
            var profileDTO = _commPServices.GetAllSchedule_AircraftType_ByAirlineSched(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airline-schedule/aircraft-type/{id}")]
        public IActionResult GetSchedule_AircraftType(int id)
        {
            var profileDTO = _commPServices.GetSchedule_AircraftType(id);

            return Ok(profileDTO);
        }
        [HttpDelete("airline-schedule/aircraft-type/{id}")]
        public IActionResult DeleteSchedule_AircraftType(int id)
        {
            try
            { 
            _commPServices.DeleteAirlineSchedule(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("airline-schedule/aircraft-type/{id}")]
        public IActionResult UpdateSchedule_AircraftType(int id, [FromBody]AirlineScheduleDTO_edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _commPServices.UpdateAirlineSchedule(data);

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