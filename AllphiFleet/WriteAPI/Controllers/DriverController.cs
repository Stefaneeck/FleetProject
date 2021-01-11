using System.Linq;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Commands.DriverCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly INHRepository<Driver> _driverContext;
        private readonly IMediator _mediator;
        public DriverController(INHRepository<Driver> driverContext, IMediator mediator)
        {
            _driverContext = driverContext;
            _mediator = mediator;
        }

        // GET: api/driver
        [HttpGet(Name = "getAllDriversWriteAPI")]
        public IActionResult Get()
        {
            var drivers = _driverContext.Drivers.ToList();

            return Ok(drivers);
        }

        //Get: api/driver/1

        [HttpGet("/writeapi/driver/{id}", Name = "GetDriverWriteAPI")]
        public IActionResult Get(long id)
        {
            DriverDTO driverDTO = null;
            if (driverDTO == null)
            {
                return NotFound("Driver has not been found.");
            }
            return Ok(driverDTO);
        }


        [HttpPost("/writeapi/driver")]
        public async Task<IActionResult> CreateDriver(CreateDriverDTO createDriverDTO)
        {
            //we willen dat de validatie in de pipeline gebeurt
            //vroeger valideren we pas als we al in de applicatielogica zitten
            //bij dit model: als het geldig is komt het in de applicatielogica, anders niet


            //null reference exception indien we command hier niet aanmaken
            //return Ok(await Mediator.Send(command));

            //correcte manier
            return Ok(await _mediator.Send(new CreateDriverCommand { CreateDriverDTO = createDriverDTO }));
        }

        //id parameter niet echt nodig, want id is required in json
        [HttpPut("/writeapi/driver/update/{id}")]
        public async Task<IActionResult> UpdateDriver(UpdateDriverDTO updateDriverDTO)
        {
            return Ok(await _mediator.Send(new UpdateDriverCommand { UpdateDriverDTO = updateDriverDTO }));
        }

        [HttpDelete("/writeapi/driver/delete/{id}")]
        public async Task<IActionResult> DeleteDriver(long id)
        {
            return Ok(await _mediator.Send(new DeleteDriverCommand { Id = id }));
        }
    }
}
