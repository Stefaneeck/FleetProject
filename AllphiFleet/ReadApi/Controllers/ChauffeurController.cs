using System;
using System.Collections.Generic;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;

namespace ReadApi.Controllers
{
    [Route("api/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        //DI van IDataRepository en IMapper
        private readonly IDataRepository<ChauffeurDTO> _dataRepository;
        //private readonly IMapper _mapper;

        /*
        public ChauffeurController(IDataRepository<Chauffeur> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        */
        public ChauffeurController(IDataRepository<ChauffeurDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk
        public IActionResult Get()
        {
            try
            {
                IEnumerable<ChauffeurDTO> chauffeurDTOs = _dataRepository.GetAll();

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
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            ChauffeurDTO chauffeurDTO = _dataRepository.Get(id);
            if (chauffeurDTO == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            return Ok(chauffeurDTO);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] ChauffeurDTO chauffeurDTO)
        {
            if (chauffeurDTO == null)
            {
                return BadRequest("Chauffeur is null.");
            }
            _dataRepository.Add(chauffeurDTO);
            return CreatedAtRoute(
                  "Get",
                  new { Id = chauffeurDTO.ChauffeurId },
                  chauffeurDTO);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ChauffeurDTO chauffeurDTO)
        {
            if (chauffeurDTO == null)
            {
                return BadRequest("Chauffeur is null.");
            }
            ChauffeurDTO chauffeurToUpdate = _dataRepository.Get(id);
            if (chauffeurToUpdate == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            _dataRepository.Update(chauffeurToUpdate, chauffeurDTO);
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ChauffeurDTO chauffeurDTO = _dataRepository.Get(id);
            if (chauffeurDTO == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            _dataRepository.Delete(chauffeurDTO);
            return NoContent();
        }
    }
}
