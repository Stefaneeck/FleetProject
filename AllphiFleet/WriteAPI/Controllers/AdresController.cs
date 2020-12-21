using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;
using Commands.AdresCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly INHRepository<Adres> _adresContext;
        private readonly IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AdresController(INHRepository<Adres> adresContext, IMediator mediator)
        {
            _adresContext = adresContext;
            _mediator = mediator;
        }

        [HttpPost("/writeapi/adres")]
        public async Task<IActionResult> CreateAdres(CreateAdresDTO createAdresDTO)
        {
            return Ok(await _mediator.Send(new CreateAdresCommand { CreateAdresDTO = createAdresDTO }));
        }

        [HttpPut("/writeapi/adres/update/{id}")]
        public async Task<IActionResult> UpdateAdres(UpdateAdresDTO updateAdresDTO)
        {
            return Ok(await _mediator.Send(new UpdateAdresCommand { UpdateAdresDTO = updateAdresDTO }));
        }

        [HttpDelete("/writeapi/adres/delete/{id}")]
        public async Task<IActionResult> DeleteAdres(long id)
        {
            //kijken of adres bestaat
            var adres = _adresContext.Adressen.FirstOrDefault(a => a.Id == id);

            if (adres == null)
            {
                return Ok("Adres bestaat niet");
            }
            else
            {
                return Ok(await _mediator.Send(new DeleteAdresCommand { Id = id }));
            }
        }
    }
}
