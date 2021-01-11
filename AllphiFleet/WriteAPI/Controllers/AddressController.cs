using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using System.Threading.Tasks;
using System.Linq;
using Commands.AddressCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly INHRepository<Address> _addressContext;
        private readonly IMediator _mediator;
        public AddressController(INHRepository<Address> addressContext, IMediator mediator)
        {
            _addressContext = addressContext;
            _mediator = mediator;
        }

        [HttpPost("/writeapi/address")]
        public async Task<IActionResult> CreateAddress(CreateAddressDTO createAddressDTO)
        {
            return Ok(await _mediator.Send(new CreateAddressCommand { CreateAddressDTO = createAddressDTO }));
        }

        [HttpPut("/writeapi/address/update/{id}")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDTO updateAddressDTO)
        {
            return Ok(await _mediator.Send(new UpdateAddressCommand { UpdateAddressDTO = updateAddressDTO }));
        }

        [HttpDelete("/writeapi/address/delete/{id}")]
        public async Task<IActionResult> DeleteAddress(long id)
        {
            //kijken of adres bestaat
            var adres = _addressContext.Addresses.FirstOrDefault(a => a.Id == id);

            if (adres == null)
            {
                return Ok("Address does not exist.");
            }
            else
            {
                return Ok(await _mediator.Send(new DeleteAddressCommand { Id = id }));
            }
        }
    }
}
