using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Commands.ApplicationCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/driver")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly INHRepository<Application> _applicationContext;
        private readonly IMediator _mediator;

        public ApplicationController(INHRepository<Application> applicationContext, IMediator mediator)
        {
            _applicationContext = applicationContext;
            _mediator = mediator;
        }

        [HttpPost("/writeapi/application")]
        public async Task<IActionResult> CreateApplication(CreateApplicationDTO createApplicationDTO)
        {
            return Ok(await _mediator.Send(new CreateApplicationCommand { CreateApplicationDTO = createApplicationDTO }));
        }

        [HttpPut("/writeapi/application/update/{id}")]
        public async Task<IActionResult> UpdateApplication(UpdateApplicationDTO updateApplicationDTO)
        {
            return Ok(await _mediator.Send(new UpdateApplicationCommand { UpdateApplicationDTO = updateApplicationDTO }));
        }

        [HttpDelete("/writeapi/application/delete/{id}")]
        public async Task<IActionResult> DeleteApplication(long id)
        {
            return Ok(await _mediator.Send(new DeleteApplicationCommand { Id = id }));
        }
    }
}
