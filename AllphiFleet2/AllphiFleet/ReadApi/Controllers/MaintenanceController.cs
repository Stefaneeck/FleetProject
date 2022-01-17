using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/maintenance")]
    [ApiController]
    public class MaintentanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly ILoggerManager _logger;
        public MaintentanceController(IMaintenanceService maintenanceService, ILoggerManager logger)
        {
            _maintenanceService = maintenanceService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllMaintenances")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all maintenances.");

            IEnumerable<MaintenanceDTO> maintenanceDTOs = _maintenanceService.GetMaintenances();

            if(!maintenanceDTOs.Any())
            {
                _logger.LogInfo("No maintenance records in database.");

                return NotFound("No maintenances have been found.");
            }

            _logger.LogInfo($"Retrieving {maintenanceDTOs.Count()} records.");

            return Ok(maintenanceDTOs);
        }

        [HttpGet("{id}", Name = "GetMaintenance")]
        public IActionResult Get(long id)
        {
            MaintenanceDTO maintenanceDTO = _maintenanceService.GetMaintenance(id);
            if (maintenanceDTO == null)
            {
                return NotFound("Maintenance has not been found.");
            }
            return Ok(maintenanceDTO);
        }

    }
}
