using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Commands.FuelCardCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/fuelcard")]
    [ApiController]
    public class FuelCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FuelCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/writeapi/fuelcard")]
        public async Task<IActionResult> CreateFuelCard(CreateFuelCardDTO createFuelCardDTO)
        {
            return Ok(await _mediator.Send(new CreateFuelCardCommand { CreateFuelCardDTO = createFuelCardDTO }));
        }

        [HttpPut("/writeapi/fuelcard/update/{id}")]
        public async Task<IActionResult> UpdateFuelCard(UpdateFuelCardDTO updateFuelCardDTO)
        {
            return Ok(await _mediator.Send(new UpdateFuelCardCommand { UpdateFuelCardDTO = updateFuelCardDTO }));
        }

        [HttpDelete("/writeapi/fuelcard/delete/{id}")]
        public async Task<IActionResult> DeleteFuelCard(long id)
        {
            return Ok(await _mediator.Send(new DeleteFuelCardCommand { Id = id }));
        }
    }
}
