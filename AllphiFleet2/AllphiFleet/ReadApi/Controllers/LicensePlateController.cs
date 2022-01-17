using System.Collections.Generic;
using System.Linq;
using DTO.LicensePlate;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/licenseplate")]
    [ApiController]
    public class LicensePlateController : ControllerBase
    {
        private readonly ILicensePlateService _licensePlateService;
        private readonly ILoggerManager _logger;
        public LicensePlateController(ILicensePlateService licensePlateService, ILoggerManager logger)
        {
            _licensePlateService = licensePlateService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllLicensePlates")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all license plates.");

            IEnumerable<LicensePlateDTO> licensePlateDTOs = _licensePlateService.GetLicensePlates();

            if (!licensePlateDTOs.Any())
            {
                _logger.LogInfo("No license plate records in database.");

                return NotFound("No license plates have been found.");
            }

            _logger.LogInfo($"Retrieving {licensePlateDTOs.Count()} records.");

            return Ok(licensePlateDTOs);
        }

        [HttpGet("{id}", Name = "GetLicensePlate")]
        public IActionResult Get(long id)
        {
            LicensePlateDTO licensePlateDTO = _licensePlateService.GetLicensePlate(id);
            if (licensePlateDTO == null)
            {
                return NotFound("License plate has not been found.");
            }
            return Ok(licensePlateDTO);
        }
    }
}
