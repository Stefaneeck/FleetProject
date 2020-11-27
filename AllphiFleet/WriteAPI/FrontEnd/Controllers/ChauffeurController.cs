using System.Linq;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteAPI.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteApi.FrontEnd.Controllers
{
    [Route("writeapi/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        //DI
        //private readonly ILoggerManager _logger;

        //nhibernate
        private readonly INHRepository<Chauffeur> _session;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public ChauffeurController(INHRepository<Chauffeur> session)
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

        [HttpGet("/writeapi/chauffeur/{id}", Name = "GetChauffeurWriteAPI")]
        public IActionResult Get(long id)
        {
            //ChauffeurDTO chauffeurDTO = _session.Chauffeurs.FirstOrDefault(e => e.Id == id);

            ChauffeurDTO chauffeurDTO = null;
            if (chauffeurDTO == null)
            {
                return NotFound("Chauffeur niet gevonden.");
            }
            return Ok(chauffeurDTO);
        }


        [HttpPost("/writeapi/chauffeur")]
        public async Task<IActionResult> CreateChauffeur(CreateChauffeurDTO createChauffeurDTO)
        {
            //we willen dat de validatie in de pipeline gebeurt
            //vroeger valideren we pas als we al in de applicatielogica zitten
            //bij dit model: als het geldig is komt het in de applicatielogica, anders niet

            //return Ok(await Mediator.Send(command));
            return Ok(await Mediator.Send(new CreateChauffeurCommand { CreateChauffeurDTO = createChauffeurDTO }));
        }

        //correcte syntax
        [HttpDelete("/writeapi/chauffeur/delete/{id}")]
        //writeapi/chauffeur/delete?id
        //aanpassen naar betere route

        //gewoon int meegeven ipv dto? consistentie..
        //id blijft op 0 staan, maken
        public async Task<IActionResult> DeleteChauffeur(long id)
        {
            /*
            var entity = await _service.ReadAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            */
            //return Ok(await Mediator.Send(new DeleteChauffeurCommand { DeleteChauffeurDTO = deleteChauffeurDTO }));

            //nog aanpassen, fixed value
            return Ok(await Mediator.Send(new DeleteChauffeurCommand { Id = id }));
        }
    }
}
