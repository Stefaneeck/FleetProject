using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/fuelcard")]
    [ApiController]
    public class FuelCardController : ControllerBase
    {
        private readonly IFuelCardService _fuelCardService;
        private readonly ILoggerManager _logger;
        public FuelCardController(IFuelCardService fuelCardService, ILoggerManager logger)
        {
            _fuelCardService = fuelCardService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllFuelCards")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all fuelcards.");

            IEnumerable<FuelCardDTO> tankkaartDTOs = _fuelCardService.GetFuelCards();

            _logger.LogInfo($"Retrieving {tankkaartDTOs.Count()} records.");

            return Ok(tankkaartDTOs);
        }

        [HttpGet("{id}", Name = "GetFuelCard")]
        public IActionResult Get(long id)
        {
            FuelCardDTO tankkaartDTO = _fuelCardService.GetFuelCard(id);
            if (tankkaartDTO == null)
            {
                return NotFound("Fuelcard has not been found.");
            }
            return Ok(tankkaartDTO);
        }

    }
}
