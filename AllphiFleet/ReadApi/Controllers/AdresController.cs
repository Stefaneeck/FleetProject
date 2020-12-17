using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly IAdresService _adresService;
        private readonly ILoggerManager _logger;
        public AdresController(IAdresService adresService, ILoggerManager logger)
        {
            _adresService = adresService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllAdressen")]
        public IActionResult Get()
        {

            _logger.LogInfo("Alle adressen aan het ophalen.");

            IEnumerable<AdresDTO> adresDTOs = _adresService.GetAdressen(null);

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
