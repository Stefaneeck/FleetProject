using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteAPI.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WriteAPI.Features.ChauffeurFeatures;
using WriteAPI.Features.AdresFeatures;
using System.Linq;

namespace WriteApi.FrontEnd.Controllers
{
    [Route("writeapi/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly INHRepository<Adres> _context;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AdresController(INHRepository<Adres> context)
        {
            _context = context;
        }

        [HttpPost("/writeapi/adres")]
        public async Task<IActionResult> CreateAdres(CreateAdresDTO createAdresDTO)
        {
            return Ok(await Mediator.Send(new CreateAdresCommand { CreateAdresDTO = createAdresDTO }));
        }

        [HttpPut("/writeapi/adres/update/{id}")]
        public async Task<IActionResult> UpdateAdres(UpdateAdresDTO updateAdresDTO)
        {
            return Ok(await Mediator.Send(new UpdateAdresCommand { UpdateAdresDTO = updateAdresDTO }));
        }

        [HttpDelete("/writeapi/adres/delete/{id}")]
        public async Task<IActionResult> DeleteAdres(long id)
        {
            //todo
            //checken of hij wel bestaat
            //kijken of adres bestaat
            var adres = _context.Adressen.FirstOrDefault(a => a.Id == id);

            //met mediatr teruggeven ipv ex
            //custom validator maken? logica naar daar verhuizen niet zo goed
            if (adres == null)
            {
                return Ok("Adres bestaat niet");
            }
            else
            {
                return Ok(await Mediator.Send(new DeleteAdresCommand { Id = id }));
            }
        }
    }
}
