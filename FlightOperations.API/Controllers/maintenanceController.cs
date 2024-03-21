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
    /// <summary>
    /// Controller responsible for maintenance
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class maintenanceController : Controller
    {
        private ImaintenanceServices _maintenanceServices;
        private readonly appSettings _appSettings;
        public maintenanceController(ImaintenanceServices maintenanceService, IOptions<appSettings> appSettings)
        {
            _maintenanceServices = maintenanceService;
            _appSettings = appSettings.Value;
        }

        #region Country
        [HttpPost("country")]
        public IActionResult CreateCountry([FromBody]CountryDTO_edit data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _maintenanceServices.CreateCountry(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
     
        [HttpGet("country")]
        public IActionResult GetAllCountry()
        {
            try { 
            var profileDTO = _maintenanceServices.GetAllCountry();

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
      
        [HttpGet("country/{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                var profileDTO = _maintenanceServices.GetCountry(id);

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpDelete("country/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            try
            { 
                _maintenanceServices.DeleteCountry(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("country/{id}")]
        public IActionResult UpdateCountry(int id, [FromBody]CountryDTO_edit data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;          
                _maintenanceServices.UpdateCountry(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region City
        [HttpPost("city")]
        public IActionResult CreateCity([FromBody]CityDTO data)
        {
            try
            {
                // save
                var userId = int.Parse(User.Identity.Name);
                data.CreatedBy = userId;
                data.UpdatedBy = userId;

                var dto = _maintenanceServices.CreateCity(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("city")]
        public IActionResult GetAllCity()
        {
            try
            {
                var profileDTO = _maintenanceServices.GetAllCity();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("city/{id}")]
        public IActionResult GetCity(int id)
        {
            try
            { 
            var profileDTO = _maintenanceServices.GetCity(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("city/{id}")]
        public IActionResult DeleteCity(int id)
        {
            try
            { 
                _maintenanceServices.DeleteCity(id);

                return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("city/{id}")]
        public IActionResult UpdateCity(int id, [FromBody]CityDTO data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _maintenanceServices.UpdateCity(data);

                return Ok(data);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
        #region User
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UserDTO data)
        {
            var user = _maintenanceServices.Authenticate(data.Username, data.Password);

            if (user == null)
            {
                var badrequest = BadRequest("Username or password is incorrect");

                return badrequest;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Token = tokenString
            });
        }
        [AllowAnonymous]
        [HttpPost("user/create")]
        public IActionResult CreateUser([FromBody]UserDTO data)
        {
            try
            {

                var dto = _maintenanceServices.CreateUser(data);

                return Ok(dto);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("user")]
        public IActionResult GetAllUser()
        {
            try
            {
                var profileDTO = _maintenanceServices.GetAllUser();

                return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("user/{id}")]
        public IActionResult GetUser(int id)
        {
            try
            { 
            var profileDTO = _maintenanceServices.GetUser(id);

            return Ok(profileDTO);
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("user/{id}/delete")]
        public IActionResult DeleteUser(int id)
        {
            try
            { 
            _maintenanceServices.DeleteUser(id);

            return Ok();
            }
            catch (appException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("user/{id}")]
        public IActionResult UpdateUser(int id, [FromBody]UserDTO data)
        {

            data.Id = id;
            try
            {
                var userId = int.Parse(User.Identity.Name);
                data.UpdatedBy = userId;

                _maintenanceServices.UpdateUser(data);

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