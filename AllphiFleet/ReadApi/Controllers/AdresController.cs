using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        //DI
        private readonly IAdresService _adresService;
        private readonly ILoggerManager _logger;
        public AdresController(IAdresService adresService, ILoggerManager logger)
        {
            _adresService = adresService;
            _logger = logger;
        }
        // GET: api/aanvraag
        [HttpGet(Name = "getAllAdressen")]
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk

        public IActionResult Get()
        {

            _logger.LogInfo("Alle adressen aan het ophalen.");

            IEnumerable<AdresDTO> adresDTOs = _adresService.GetAdressen(null);

            //throw new Exception("Exception tijdens ophalen van chauffeurs.");

            _logger.LogInfo($"Ophalen van {adresDTOs.Count()} records.");

            return Ok(adresDTOs);
        }

        [HttpGet("{id}", Name = "GetAdres")]
        public IActionResult Get(long id)
        {
            AdresDTO adresDTO = _adresService.GetAdres(id);
            if (adresDTO == null)
            {
                return NotFound("Adres niet gevonden.");
            }
            return Ok(adresDTO);
        }

    }
}
