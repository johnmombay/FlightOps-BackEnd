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
    public class ReportsController : ControllerBase
    {
        private IflightscheduleServices _flightscheduleServ;
        private ImaintenanceServices _maintenanceServ;
        private IcrewPlanningServices _crewPlanningServ;
        private IaircraftServices _aircraftServ;
        private readonly appSettings _appSettings;
        public ReportsController(IflightscheduleServices flightscheduleServices, ImaintenanceServices maintenanceServices,
            IcrewPlanningServices crewPlanningServices, IaircraftServices aircraftServ, IOptions<appSettings> appSettings)
        {
            _maintenanceServ = maintenanceServices;
            _flightscheduleServ = flightscheduleServices;
            _crewPlanningServ = crewPlanningServices;
            _aircraftServ = aircraftServ;
            _appSettings = appSettings.Value;
        }
        #region GetAirports
        [HttpGet("airports")]
        public IActionResult GetAllAirport()
        {
            try
            {
                var profileDTO = _flightscheduleServ.GetAllAirport();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region GetCountries
        [HttpGet("countries")]
        public IActionResult GetAllCountry()
        {
            try
            {
                var profileDTO = _maintenanceServ.GetAllCountry();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region GetCities
        [HttpGet("cities")]
        public IActionResult GetAllCity()
        {
            try
            {
                var profileDTO = _maintenanceServ.GetAllCity();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region GetCrews
        [HttpGet("crews")]
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
        #endregion
        #region FlightSchedules
        [HttpPost("flight-schedules")]
        public IActionResult GetAllFlightSchedule(ReportFiltersDTO data)
        {
            try
            {
                var profileDTO = _flightscheduleServ.GetAllFlightScheduleOrderByFlightDate_withDateRange(data);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region MaintenanceSchedule
        [HttpPost("maintenance-schedules")]
        public IActionResult GetAllMaintenanceSchedule(ReportFiltersDTO data)
        {
            try
            {
                var profileDTO = _aircraftServ.GetAllMaintenanceSchedule_withDateRange(data);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region CrewSchedule
        [HttpPost("crew-schedules")]
        public IActionResult GetAllCrewSchedule(ReportFiltersDTO data)
        {
            try
            {
                var profileDTO = _crewPlanningServ.GetAllCrewSchedule_withDateRange(data);

                return Ok(profileDTO);
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