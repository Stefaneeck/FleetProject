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
        private readonly INHRepository<Aanvraag> _aanvraagContext;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AanvraagController(INHRepository<Aanvraag> aanvraagContext)
        {
            _aanvraagContext = aanvraagContext;
        }

        [HttpPost("/writeapi/aanvraag")]
        public async Task<IActionResult> CreateAanvraag(CreateAanvraagDTO createAanvraagDTO)
        {
            return Ok(await Mediator.Send(new CreateAanvraagCommand { CreateAanvraagDTO = createAanvraagDTO }));
        }

        //probleem bij update, hij maakt nieuw voertuig object aan
        [HttpPut("/writeapi/aanvraag/update/{id}")]
        public async Task<IActionResult> UpdateAanvraag(UpdateAanvraagDTO updateAanvraagDTO)
        {
            return Ok(await Mediator.Send(new UpdateAanvraagCommand { UpdateAanvraagDTO = updateAanvraagDTO }));
        }

        [HttpDelete("/writeapi/aanvraag/delete/{id}")]
        public async Task<IActionResult> DeleteAanvraag(long id)
        {
            return Ok(await Mediator.Send(new DeleteAanvraagCommand { Id = id }));
        }
    }
}
