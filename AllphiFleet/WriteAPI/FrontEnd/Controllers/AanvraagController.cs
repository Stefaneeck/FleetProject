using System.Linq;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteAPI.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WriteAPI.Features.ChauffeurFeatures;
using WriteAPI.Features.AanvraagFeatures;

namespace WriteApi.FrontEnd.Controllers
{
    [Route("writeapi/chauffeur")]
    [ApiController]
    public class AanvraagController : ControllerBase
    {
        //DI

        //private readonly ILoggerManager _logger;

        //nhibernate
        private readonly IMapperSession<Aanvraag> _session;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AanvraagController(IMapperSession<Aanvraag> session)
        {
            _session = session;
        }
        // GET: api/aanvraag

        [HttpGet(Name = "getAllAanvragenWriteAPI")]
        public IActionResult Get()
        {
            var chauffeurs = _session.Chauffeurs.ToList();

            return Ok(chauffeurs);
        }

        //Get: api/chauffeur/1

        [HttpGet("{id}", Name = "GetAanvraagWriteAPI")]
        public IActionResult Get(long id)
        {
            //ChauffeurDTO chauffeurDTO = _chauffeurService.GetChauffeur(id);
            AanvraagDTO aanvraagDTO = null;
            if (aanvraagDTO == null)
            {
                return NotFound("Aanvraag niet gevonden.");
            }
            return Ok(aanvraagDTO);
        }

        [HttpPost("/writeapi/aanvraag")]
        public async Task<IActionResult> CreateAanvraag(CreateAanvraagCommand command)
        {
            //we willen dat de validatie in de pipeline gebeurt
            //vroeger valideren we pas als we al in de applicatielogica zitten
            //bij dit model: als het geldig is komt het in de applicatielogica, anders niet

            Aanvraag a = new Aanvraag();

            //map van command naar chauffeur
            a.DatumAanvraag = command.DatumAanvraag;
            a.GewensteData = command.GewensteData;
            a.StatusAanvraag = command.StatusAanvraag;
            a.TypeAanvraag = command.TypeAanvraag;
            a.VoertuigId = command.VoertuigId;

            /*
            _session.BeginTransaction();

            await _session.Save(a);
            await _session.Commit();
            */

            return Ok(await Mediator.Send(command));
        }
    }
}
