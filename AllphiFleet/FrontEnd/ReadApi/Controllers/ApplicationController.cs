using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly ILoggerManager _logger;
        public ApplicationController(IApplicationService applicationService, ILoggerManager logger)
        {
            _applicationService = applicationService;
            _logger = logger;
        }
        // GET: api/application
        [HttpGet(Name = "getAllApplications")]
        //async?
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all applications.");

            IEnumerable<ApplicationDTO> applicationDTOs = _applicationService.GetApplications();

            if (!applicationDTOs.Any())
            {
                _logger.LogInfo("No application records in database.");

                return NotFound("No applications have been found.");
            }

            _logger.LogInfo($"Retrieving {applicationDTOs.Count()} records.");

            return Ok(applicationDTOs);
        }

        [HttpGet("{id}", Name = "GetApplication")]
        public IActionResult Get(long id)
        {
            ApplicationDTO aanvraagDTO = _applicationService.GetApplication(id);
            if (aanvraagDTO == null)
            {
                return NotFound("Application has not been found.");
            }
            return Ok(aanvraagDTO);
        }

    }
}
