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
        private readonly IDataRepository<Chauffeur> _dataRepository;
        private readonly IMapper _mapper;
        public ChauffeurController(IDataRepository<Chauffeur> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        // GET: api/Employee
        [HttpGet]
        
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Chauffeur> chauffeurs = _dataRepository.GetAll();

                //automapper, model omzetten naar DTO
                ChauffeurDTO[] dtos = _mapper.Map<ChauffeurDTO[]>(chauffeurs);

                return Ok(dtos);
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
            Chauffeur chauffeurs = _dataRepository.Get(id);
            if (chauffeurs == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            return Ok(chauffeurs);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Chauffeur chauffeur)
        {
            if (chauffeur == null)
            {
                return BadRequest("Chauffeur is null.");
            }
            _dataRepository.Add(chauffeur);
            return CreatedAtRoute(
                  "Get",
                  new { Id = chauffeur.ChauffeurId },
                  chauffeur);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Chauffeur chauffeur)
        {
            if (chauffeur == null)
            {
                return BadRequest("Chauffeur is null.");
            }
            Chauffeur chauffeurToUpdate = _dataRepository.Get(id);
            if (chauffeurToUpdate == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            _dataRepository.Update(chauffeurToUpdate, chauffeur);
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Chauffeur chauffeur = _dataRepository.Get(id);
            if (chauffeur == null)
            {
                return NotFound("The Chauffeur record couldn't be found.");
            }
            _dataRepository.Delete(chauffeur);
            return NoContent();
        }
    }
}
