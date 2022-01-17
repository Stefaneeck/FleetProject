using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AllphiFleet
{
        //dit zou eigenlijk onder apicontrollers project moeten komen, maar door aspnetcore.mvc dependency hier even getest
        [Route("api/chauffeur")]
        [ApiController]
        public class ChauffeurController : ControllerBase
        {
            private readonly IDataRepository<Chauffeur> _dataRepository;
            public ChauffeurController(IDataRepository<Chauffeur> dataRepository)
            {
                _dataRepository = dataRepository;
            }
            // GET: api/Employee
            [HttpGet]
            public IActionResult Get()
            {
                IEnumerable<Chauffeur> chauffeurs = _dataRepository.GetAll();
                return Ok(chauffeurs);
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
