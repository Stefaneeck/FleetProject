using System.Linq;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Commands.ChauffeurCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/chauffeur")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        private readonly IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public ChauffeurController(INHRepository<Chauffeur> chauffeurContext, IMediator mediator)
        {
            _chauffeurContext = chauffeurContext;
            _mediator = mediator;
        }
        // GET: api/chauffeur

        [HttpGet(Name = "getAllChauffeursWriteAPI")]
        public IActionResult Get()
        {
            var chauffeurs = _chauffeurContext.Chauffeurs.ToList();

            return Ok(chauffeurs);
        }

        //Get: api/chauffeur/1

        [HttpGet("/writeapi/chauffeur/{id}", Name = "GetChauffeurWriteAPI")]
        public IActionResult Get(long id)
        {
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


            //null reference exception indien we command hier niet aanmaken
            //return Ok(await Mediator.Send(command));

            //correcte manier
            return Ok(await _mediator.Send(new CreateChauffeurCommand { CreateChauffeurDTO = createChauffeurDTO }));
        }

        //id parameter niet echt nodig, want id is required in json
        [HttpPut("/writeapi/chauffeur/update/{id}")]
        public async Task<IActionResult> UpdateChauffeur(UpdateChauffeurDTO updateChauffeurDTO)
        {
            return Ok(await _mediator.Send(new UpdateChauffeurCommand { UpdateChauffeurDTO = updateChauffeurDTO }));
        }

        [HttpDelete("/writeapi/chauffeur/delete/{id}")]
        public async Task<IActionResult> DeleteChauffeur(long id)
        {
            return Ok(await _mediator.Send(new DeleteChauffeurCommand { Id = id }));
        }
    }
}
