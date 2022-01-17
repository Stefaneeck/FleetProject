using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly ILoggerManager _logger;
        public DriverController(IDriverService driverService, ILoggerManager logger)
        {
            _driverService = driverService;
            _logger = logger;
        }

        //currently disabled for blazor
        //[Authorize]
        [HttpGet(Name = "getAllDrivers")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all drivers.");

            IEnumerable<DriverDTO> driverDTOs = _driverService.GetDrivers();

            if (!driverDTOs.Any())
            {
                _logger.LogInfo("No driver records in database.");

                return NotFound("No drivers have been found.");
            }

            _logger.LogInfo($"Retrieving {driverDTOs.Count()} records.");

            return Ok(driverDTOs);
        }

        //Get: api/driver/1
        [HttpGet("{id}", Name = "GetDriver")]
        public IActionResult Get(long id)
        {
            DriverDTO driverDTO = _driverService.GetDriver(id);
            if (driverDTO == null)
            {
                return NotFound("Driver has not been found.");
            }
            return Ok(driverDTO);
        }

        //Get: api/driver/getbyemail/test@mail.com
        [HttpGet("getbyemail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var driverId = _driverService.GetDriverIdByEmail(email);
            return Ok(driverId);
        }

        //Get: api/driver/getbysocsecnr/111-222-333
        [HttpGet("getbysocsecnr/{socSecNr}")]
        public IActionResult GetBySocSecNr(string socSecNr)
        {
            var driverId = _driverService.GetDriverIdBySocSecNr(socSecNr);
            return Ok(driverId);
        }

        [HttpGet("Claims")]
        //without roles, returns 401 if not authorized. With roles, returns 403 if wrong role.
        //[Authorize(Roles = "admin")]
        //[EnableCors("AllowAllReadApi")]
        public IActionResult Claims()
        {
            //not returning object since a type can be non unique
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }
    }
}
