using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/aanvraag")]
    [ApiController]
    public class AanvraagController : ControllerBase
    {
        //DI
        private readonly IAanvraagService _aanvraagService;
        private readonly ILoggerManager _logger;
        public AanvraagController(IAanvraagService aanvraagService, ILoggerManager logger)
        {
            _aanvraagService = aanvraagService;
            _logger = logger;
        }
        // GET: api/aanvraag
        [HttpGet(Name = "getAllAanvragen")]
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk

        public IActionResult Get()
        {

            _logger.LogInfo("Alle aanvragen aan het ophalen.");

            IEnumerable<AanvraagDTO> aanvraagDTOs = _aanvraagService.GetAanvragen(null);

            //throw new Exception("Exception tijdens ophalen van chauffeurs.");

            _logger.LogInfo($"Ophalen van {aanvraagDTOs.Count()} records.");

            return Ok(aanvraagDTOs);
        }

        [HttpGet("{id}", Name = "GetAanvraag")]
        public IActionResult Get(long id)
        {
            AanvraagDTO aanvraagDTO = _aanvraagService.GetAanvraag(id);
            if (aanvraagDTO == null)
            {
                return NotFound("Aanvraag niet gevonden.");
            }
            return Ok(aanvraagDTO);
        }

    }
}
