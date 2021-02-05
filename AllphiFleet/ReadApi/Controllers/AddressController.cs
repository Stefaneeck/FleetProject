using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILoggerManager _logger;
        public AddressController(IAddressService addressService, ILoggerManager logger)
        {
            _addressService = addressService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllAddresses")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all addresses.");

            IEnumerable<AddressDTO> adresDTOs = _addressService.GetAddresses();

            if (!adresDTOs.Any())
            {
                _logger.LogInfo("No address records in database.");

                return NotFound("No addresses have been found.");
            }

            _logger.LogInfo($"Retrieving {adresDTOs.Count()} records.");

            return Ok(adresDTOs);
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public IActionResult Get(long id)
        {
            AddressDTO adresDTO = _addressService.GetAddress(id);
            if (adresDTO == null)
            {
                return NotFound("Address has not been found.");
            }
            return Ok(adresDTO);
        }

    }
}
