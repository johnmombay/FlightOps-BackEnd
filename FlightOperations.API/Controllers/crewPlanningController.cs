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
    public class crewPlanningController : ControllerBase
    {
        private IcrewPlanningServices _crewPlanningServ;
        private readonly appSettings _appSettings;
        public crewPlanningController(IcrewPlanningServices crewPlanningServ, IOptions<appSettings> appSettings)
        {
            _crewPlanningServ = crewPlanningServ;
            _appSettings = appSettings.Value;
        }
        #region CrewPosition
        [HttpPost("schedule")]
        public IActionResult CreateCrewSchedule(CrewScheduleDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _crewPlanningServ.CreateCrewSchedule(data);
                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });

            }

        }
        [HttpPost("schedule/batch")]
        public IActionResult SaveCrewSchedule(BatchCrewScheduleDTO data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);

                

                var dto = _crewPlanningServ.SaveCrewSchedule(data.CrewSchedules, userId);
                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });

            }

        }
        [HttpGet("schedule")]
        public IActionResult GetAllCrewSchedule()
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetAllCrewSchedule();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("schedule/{id}")]
        public IActionResult GetCrewSchedule(int id)
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetCrewSchedule(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("schedule/{id}")]
        public IActionResult DeleteCrewSchedule(int id)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                _crewPlanningServ.DeleteCrewSchedule(id);
                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("schedule")]
        public IActionResult UpdateCrewPosition(CrewScheduleDTO_Edit data)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;
                _crewPlanningServ.UpdateCrewSchedule(data);

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