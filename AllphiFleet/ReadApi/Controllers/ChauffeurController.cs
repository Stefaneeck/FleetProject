using System;
using System.Collections.Generic;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ReadApi.Controllers
{
    [Route("api/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        //DI
        //interface van maken of niet?
        private readonly IChauffeurService _chauffeurService;
        public ChauffeurController(IChauffeurService chauffeurService)
        {
            _chauffeurService = chauffeurService;

        }
        // GET: api/chauffeur
        [HttpGet]        
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk
        public IActionResult Get()
        {
            try
            {
                IEnumerable<ChauffeurDTO> chauffeurDTOs = _chauffeurService.GetChauffeurs(null);

                //automapper, model omzetten naar DTO
                //hier niet omzetten maar in servicelaag (chauffeurrepository)
                //ChauffeurDTO[] dtos = _mapper.Map<ChauffeurDTO[]>(chauffeurs);

                return Ok(chauffeurDTOs);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
            
        }
        // GET: api/chauffeur/1
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            ChauffeurDTO chauffeurDTO = _chauffeurService.GetChauffeur(id);
            if (chauffeurDTO == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            return Ok(chauffeurDTO);
        }
    }
}
