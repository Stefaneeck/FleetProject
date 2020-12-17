using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/factuur")]
    [ApiController]
    public class FactuurController : ControllerBase
    {
        private readonly IFactuurService _factuurService;
        private readonly ILoggerManager _logger;
        public FactuurController(IFactuurService factuurService, ILoggerManager logger)
        {
            _factuurService = factuurService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllFacturen")]
        //authorize ter test
        [Authorize] 
        public IActionResult Get()
        {

            _logger.LogInfo("Alle facturen aan het ophalen.");

            IEnumerable<FactuurDTO> factuurDTOs = _factuurService.GetFacturen(null);

            _logger.LogInfo($"Ophalen van {factuurDTOs.Count()} records.");

            return Ok(factuurDTOs);
        }

        [HttpGet("{id}", Name = "GetFactuur")]
        public IActionResult Get(long id)
        {
            FactuurDTO factuurDTO = _factuurService.GetFactuur(id);
            if (factuurDTO == null)
            {
                return NotFound("Factuur niet gevonden.");
            }
            return Ok(factuurDTO);
        }

    }
}
