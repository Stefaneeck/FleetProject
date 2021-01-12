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
            //We want the validation to take place in the pipline, before mediatr we didnt validate until we had already reached the business logic.
            //With the mediatr pattern the valdiation takes place before entering the business logic.

            return Ok(await _mediator.Send(new CreateDriverCommand { CreateDriverDTO = createDriverDTO }));
        }

        [HttpPut("/writeapi/driver/update/{id}")]
        public async Task<IActionResult> UpdateDriver(UpdateDriverDTO updateDriverDTO, long id)
        {
            updateDriverDTO.Id = id;
            return Ok(await _mediator.Send(new UpdateDriverCommand { UpdateDriverDTO = updateDriverDTO }));
        }

        [HttpDelete("/writeapi/driver/delete/{id}")]
        public async Task<IActionResult> DeleteDriver(long id)
        {
            return Ok(await _mediator.Send(new DeleteDriverCommand { Id = id }));
        }
    }
}
