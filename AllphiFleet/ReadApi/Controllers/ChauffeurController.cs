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
    [Route("api/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        private readonly IChauffeurService _chauffeurService;
        private readonly ILoggerManager _logger;
        public ChauffeurController(IChauffeurService chauffeurService, ILoggerManager logger)
        {
            _chauffeurService = chauffeurService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet(Name = "getAllChauffeurs")]
        public IActionResult Get()
        {

            _logger.LogInfo("Alle chauffeurs aan het ophalen.");

            IEnumerable<ChauffeurDTO> chauffeurDTOs = _chauffeurService.GetChauffeurs(null);

            _logger.LogInfo($"Ophalen van {chauffeurDTOs.Count()} records.");

            return Ok(chauffeurDTOs);
        }

        //Get: api/chauffeur/1
        [HttpGet("{id}", Name = "GetChauffeur")]
        public IActionResult Get(long id)
        {
            ChauffeurDTO chauffeurDTO = _chauffeurService.GetChauffeur(id);
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
