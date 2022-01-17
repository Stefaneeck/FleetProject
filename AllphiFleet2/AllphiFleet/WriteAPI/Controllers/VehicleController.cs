using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Commands.VehicleCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/writeapi/vehicle")]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDTO createVehicleDTO)
        {
            return Ok(await _mediator.Send(new CreateVehicleCommand { CreateVehicleDTO = createVehicleDTO }));
        }

        [HttpPut("/writeapi/vehicle/update/{id}")]
        public async Task<IActionResult> UpdateFuelCard(UpdateVehicleDTO updateVehicleDTO)
        {
            return Ok(await _mediator.Send(new UpdateVehicleCommand { UpdateVehicleDTO = updateVehicleDTO }));
        }

        [HttpDelete("/writeapi/vehicle/delete/{id}")]
        public async Task<IActionResult> DeleteVehicle(long id)
        {
            return Ok(await _mediator.Send(new DeleteVehicleCommand { Id = id }));
        }
    }
}
