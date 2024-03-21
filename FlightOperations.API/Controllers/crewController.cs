using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Enum;
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
    public class crewController : ControllerBase
    {
        private IcrewPlanningServices _crewPlanningServ;
        private readonly appSettings _appSettings;
        public crewController(IcrewPlanningServices crewPlanningServ, IOptions<appSettings> appSettings)
        {
            _crewPlanningServ = crewPlanningServ;
            _appSettings = appSettings.Value;
        }
        #region CrewPosition
        [HttpPost("position")]
        public IActionResult CreateCrewPlanning(CrewPositionDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _crewPlanningServ.CreateCrewPosition(data);
                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });

            }

        }
        [HttpGet("position")]
        public IActionResult GetAllCrewPosition()
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetAllCrewPosition();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("position/{id}")]
        public IActionResult GetCrewPosition(int id)
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetCrewPosition(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("position/{id}")]
        public IActionResult DeleteCrewPosition(int id)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                _crewPlanningServ.DeleteCrewPosition(id);
                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("position")]
        public IActionResult UpdateCrewPosition(CrewPositionDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;
                _crewPlanningServ.UpdateCrewPosition(data);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        #endregion
        #region Crew
        [HttpPost()]
        public IActionResult CreateCrew(CrewDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _crewPlanningServ.CreateCrew(data);
                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });

            }

        }
        [HttpGet()]
        public IActionResult GetAllCrew()
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetAllCrew();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("Position/{id}")]
        public IActionResult GetAllCrew(int id)
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetAllCrew_ByCrewPos(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("PositionType/{id}")]
        public IActionResult GetAllCrewByType(int id)
        {
            try
            {
                var positionType = (PositionTypeEnum)id;

                var profileDTO = _crewPlanningServ.GetAllCrew_ByCrewPositionType(positionType);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCrew(int id)
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetCrew(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCrew(int id)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                _crewPlanningServ.DeleteCrew(id);
                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut()]
        public IActionResult UpdateCrew(CrewDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;
                _crewPlanningServ.UpdateCrew(data);

                return Ok();
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