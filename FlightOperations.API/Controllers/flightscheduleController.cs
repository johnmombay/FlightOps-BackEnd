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
    public class flightscheduleController : Controller
    {
        private IflightscheduleServices _flightscheduleServices;
        private readonly appSettings _appSettings;
        public flightscheduleController(IflightscheduleServices flightscheduleServices, IOptions<appSettings> appSettings)
        {
            _flightscheduleServices = flightscheduleServices;
            _appSettings = appSettings.Value;
        }

        #region Airport Category
        [HttpPost("airport-category")]
        public IActionResult CreateAirportCategory([FromBody]AirportCategoryDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _flightscheduleServices.CreateAirportCategory(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airport-category")]
        public IActionResult GetAllAirportCategory()
        {
            try
            {
                var profileDTO = _flightscheduleServices.GetAllAirportCategory();

                return Ok(profileDTO);
            }             
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message
    });
            }
        }
        [HttpGet("airport-category/{id}")]
        public IActionResult GetAirportCategory(int id)
        {
            try
            { 
            var profileDTO = _flightscheduleServices.GetAirportCategory(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("airport-category/{id}")]
        public IActionResult DeleteAirportCategory(int id)
        {
            try
            { 
            _flightscheduleServices.DeleteAirportCategory(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("airport-category/{id}")]
        public IActionResult UpdateAirportCategory(int id, [FromBody]AirportCategoryDTO data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _flightscheduleServices.UpdateAirportCategory(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion      
        #region Airport
        [HttpPost("airport")]
        public IActionResult CreateAirport([FromBody]AirportDTO_edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _flightscheduleServices.CreateAirport(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airport")]
        public IActionResult GetAllAirport()
        {
            try
            {
                var profileDTO = _flightscheduleServices.GetAllAirport();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("airport/{id}")]
        public IActionResult GetAirport(int id)
        {
            try
            { 
            var profileDTO = _flightscheduleServices.GetAirport(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("airport/{id}")]
        public IActionResult DeleteAirport(int id)
        {
            try
            {
                _flightscheduleServices.DeleteAirport(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("airport/{id}")]
        public IActionResult UpdateAirport(int id, [FromBody]AirportDTO_edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _flightscheduleServices.UpdateAirport(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        /*
        #region Route
        [HttpPost("route/create")]
        public IActionResult CreateRoute([FromBody]RouteDTO_Edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _flightscheduleServices.CreateRoute(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("route")]
        public IActionResult GetAllRoute()
        {
            var profileDTO = _flightscheduleServices.GetAllRoute();

            return Ok(profileDTO);
        }
        [HttpGet("route/{id}")]
        public IActionResult GetRoute(int id)
        {
            var profileDTO = _flightscheduleServices.GetRoute(id);

            return Ok(profileDTO);
        }
        [HttpDelete("route/{id}/delete")]
        public IActionResult DeleteRoute(int id)
        {
            _flightscheduleServices.DeleteRoute(id);

            return Ok();
        }
        [HttpPut("route/{id}")]
        public IActionResult UpdateRoute(int id, [FromBody]RouteDTO_Edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _flightscheduleServices.UpdateRoute(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion */
        #region FlightSchedule
        [HttpPost()]
        public IActionResult CreateFlightSchedule([FromBody]FlightScheduleDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                //validations 


                var dto = _flightscheduleServices.CreateFlightSchedule(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet()]
        public IActionResult GetAllFlightSchedule()
        {
            try
            { 
            var profileDTO = _flightscheduleServices.GetAllFlightSchedule();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("byAirlineSchedID/{id}")]
        public IActionResult GetAllFlightSchedule(int id)
        {
            try
            { 
            var profileDTO = _flightscheduleServices.GetAllFlightSchedule_byAirlineSchedID(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
       
        [HttpPost("published/range")]
        public IActionResult GetAllPublishedFlightSchedule(DateParamDTO Range)
        {
            try
            {
                var profileDTO = _flightscheduleServices.GetAllPublishedFlightSchedule(Range.From, Range.To);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("published")]
        public IActionResult GetAllPublishedFlightSchedule([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            try
            {
                if(from == null || from <= DateTime.MinValue)
                {
                    from = DateTime.UtcNow;
                    to = from.AddDays(30);
                }
                var profileDTO = _flightscheduleServices.GetAllPublishedFlightSchedule(from.Date, to.Date);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("cancel/{id}")]
        public IActionResult CancelFlightSchedule(int id)
        {
            try
            {                
                _flightscheduleServices.CancelFlightSchedule(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetFlightSchedule(int id)
        {
            try
            { 
            var profileDTO = _flightscheduleServices.GetFlightSchedule(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFlightSchedule(int id)
        {
            try
            { 
            _flightscheduleServices.DeleteFlightSchedule(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut()]
        public IActionResult UpdateFlightSchedule([FromBody]FlightScheduleDTO data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _flightscheduleServices.UpdateFlightSchedule(data);

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