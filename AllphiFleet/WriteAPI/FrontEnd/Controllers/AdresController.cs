using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteAPI.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WriteAPI.Features.ChauffeurFeatures;
using WriteAPI.Features.AdresFeatures;

namespace WriteApi.FrontEnd.Controllers
{
    [Route("writeapi/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly INHRepository<Adres> _session;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AdresController(INHRepository<Adres> session)
        {
            _session = session;
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
            return Ok(await Mediator.Send(new DeleteAdresCommand { Id = id }));
        }
    }
}
