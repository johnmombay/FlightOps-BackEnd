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
    public class aircraftController : Controller
    {
        private IaircraftServices _aircraftServices;
        private readonly appSettings _appSettings;

        public aircraftController(IaircraftServices aircraftService, IOptions<appSettings> appSettings)
        {
            _aircraftServices = aircraftService;
            _appSettings = appSettings.Value;
        }
        #region AircraftType
        [HttpPost("aircraft-type")]
        public IActionResult CreateAircraftType([FromBody]AircraftTypeDTO_Edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _aircraftServices.CreateAircraftType(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("aircraft-type")]
        public IActionResult GetAllAircrafType()
        {
            try
            { 
            var profileDTO = _aircraftServices.GetAllAircraftType();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("aircraft-type/{id}")]
        public IActionResult GetAllAircrafType(int id)
        {
            try
            { 
            var profileDTO = _aircraftServices.GetAircraftType(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("aircraft-type/{id}")]
        public IActionResult DeleteAircrafType(int id)
        {
            try
            { 
          _aircraftServices.DeleteAircraftType(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("aircraft-type/{id}")]
        public IActionResult UpdateAircrafType(int id, [FromBody]AircraftTypeDTO_Edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _aircraftServices.UpdateAircraftType(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region Aircraft
        [HttpPost("create")]
        public IActionResult CreateAircraft([FromBody]AircraftDTO_edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _aircraftServices.CreateAircraft(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet()]
        public IActionResult GetAllAircraft()
        {
            try
            { 
            var profileDTO = _aircraftServices.GetAllAircraft();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAllAircraft(int id)
        {
            try
            { 
            var profileDTO = _aircraftServices.GetAircraft(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAircraft(int id)
        {
            try
            { 
            _aircraftServices.DeleteAircraft(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAircraft(int id, [FromBody]AircraftDTO_edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _aircraftServices.UpdateAircraft(data);

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
