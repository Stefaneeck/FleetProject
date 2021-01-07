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

            IEnumerable<ApplicationDTO> aanvraagDTOs = _applicationService.GetApplications();

            _logger.LogInfo($"Retrieving {aanvraagDTOs.Count()} records.");

            return Ok(aanvraagDTOs);
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
