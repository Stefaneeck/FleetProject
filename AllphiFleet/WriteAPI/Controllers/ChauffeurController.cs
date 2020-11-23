using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using ReadApi;
using Services;
using WriteAPI;

namespace WriteApi.Controllers
{
    [Route("writeapi/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        //DI

        //private readonly ILoggerManager _logger;

        //nhibernate
        private readonly IMapperSession _session;
        public ChauffeurController(IMapperSession session)
        {
            _session = session;
        }
        // GET: api/chauffeur

        [HttpGet(Name = "getAllChauffeursWriteAPI")]
        public IActionResult Get()
        {

            var chauffeurs = _session.Chauffeurs.ToList();

            //IEnumerable<ChauffeurDTO> chauffeurDTOs = _chauffeurService.GetChauffeurs(null);

            //throw new Exception("Exception tijdens ophalen van chauffeurs.");

            return Ok(chauffeurs);
        }

        //Get: api/chauffeur/1

        [HttpGet("{id}", Name = "GetChauffeurWriteAPI")]
        public IActionResult Get(long id)
        {
            //ChauffeurDTO chauffeurDTO = _chauffeurService.GetChauffeur(id);
            ChauffeurDTO chauffeurDTO = null;
            if (chauffeurDTO == null)
            {
                return NotFound("Chauffeur niet gevonden.");
            }
            return Ok(chauffeurDTO);
        }

        [HttpPost("/writeapi/chauffeur")]
        public IActionResult AddChauffeur(Chauffeur chauffeur)
        {
            _session.BeginTransaction();
            _session.Save(chauffeur);
            _session.Commit();

            return Ok(chauffeur);
        }
    }
}
