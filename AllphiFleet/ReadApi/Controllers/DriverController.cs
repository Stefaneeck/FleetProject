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

            IEnumerable<DriverDTO> chauffeurDTOs = _driverService.GetDrivers();

            _logger.LogInfo($"Retrieving {chauffeurDTOs.Count()} records.");

            return Ok(chauffeurDTOs);
        }

        //Get: api/driver/1
        [HttpGet("{id}", Name = "GetDriver")]
        public IActionResult Get(long id)
        {
            DriverDTO chauffeurDTO = _driverService.GetDriver(id);
            if (chauffeurDTO == null)
            {
                return NotFound("Chauffeur niet gevonden.");
            }
            return Ok(chauffeurDTO);
        }

        //testing
        [HttpGet("Privacy")]
        //without roles, returns 401 if not authorized. With roles, returns 403 if wrong role.
        [Authorize(Roles = "admin")]
        //[EnableCors("AllowAllReadApi")]
        public IActionResult Privacy()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }
    }
}
