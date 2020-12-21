using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Commands.AanvraagCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/chauffeur")]
    [ApiController]
    public class AanvraagController : ControllerBase
    {
        private readonly INHRepository<Aanvraag> _aanvraagContext;
        private readonly IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AanvraagController(INHRepository<Aanvraag> aanvraagContext, IMediator mediator)
        {
            _aanvraagContext = aanvraagContext;
            _mediator = mediator;
        }

        [HttpPost("/writeapi/aanvraag")]
        public async Task<IActionResult> CreateAanvraag(CreateAanvraagDTO createAanvraagDTO)
        {
            return Ok(await _mediator.Send(new CreateAanvraagCommand { CreateAanvraagDTO = createAanvraagDTO }));
        }

        [HttpPut("/writeapi/aanvraag/update/{id}")]
        public async Task<IActionResult> UpdateAanvraag(UpdateAanvraagDTO updateAanvraagDTO)
        {
            return Ok(await _mediator.Send(new UpdateAanvraagCommand { UpdateAanvraagDTO = updateAanvraagDTO }));
        }

        [HttpDelete("/writeapi/aanvraag/delete/{id}")]
        public async Task<IActionResult> DeleteAanvraag(long id)
        {
            return Ok(await _mediator.Send(new DeleteAanvraagCommand { Id = id }));
        }
    }
}
