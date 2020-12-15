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
        //DI
        private readonly IFactuurService _factuurService;
        private readonly ILoggerManager _logger;
        public FactuurController(IFactuurService factuurService, ILoggerManager logger)
        {
            _factuurService = factuurService;
            _logger = logger;
        }
        // GET: api/factuur
        [HttpGet(Name = "getAllFacturen")]
        //authorize ter test
        [Authorize] 
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk

        public IActionResult Get()
        {

            _logger.LogInfo("Alle facturen aan het ophalen.");

            IEnumerable<FactuurDTO> factuurDTOs = _factuurService.GetFacturen(null);

            //throw new Exception("Exception tijdens ophalen van chauffeurs.");

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
