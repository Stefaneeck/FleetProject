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
        /*
        public IActionResult AddChauffeur(Chauffeur chauffeur)
        {
            _session.BeginTransaction();
            _session.Save(chauffeur);
            _session.Commit();

            return Ok(chauffeur);
        }*/

        public async Task<IActionResult> CreateChauffeur(CreateChauffeurCommand command)
        {
            //we willen dat de validatie in de pipeline gebeurt
            //vroeger valideren we pas als we al in de applicatielogica zitten
            //bij dit model: als het geldig is komt het in de applicatielogica, anders niet

            //gebeurt nu in createchauffeurcommandhandler
            /*
            Chauffeur c = new Chauffeur();
           
            //map van command naar chauffeur
            c.Naam = command.Naam;
            c.Voornaam = command.Voornaam;
            c.RijksRegisterNummer = command.RijksRegisterNummer;
            c.TankkaartId = command.TankkaartId;
            c.Actief = command.Actief;
            c.AdresId = command.AdresId;
            c.GeboorteDatum = command.GeboorteDatum;
            c.Id = command.Id;
            c.TypeRijbewijs = command.TypeRijbewijs;
            */

            //gebeurt nu in createchauffeurcommand, ok?
            /*
            _session.BeginTransaction();

            await _session.Save(c);
            await _session.Commit();
            */

            return Ok(await Mediator.Send(command));
        }
    }
}
