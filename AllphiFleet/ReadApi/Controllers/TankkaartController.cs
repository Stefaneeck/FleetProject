using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/tankkaart")]
    [ApiController]
    public class TankkaartController : ControllerBase
    {
        private readonly ITankkaartService _tankkaartService;
        private readonly ILoggerManager _logger;
        public TankkaartController(ITankkaartService tankkaartService, ILoggerManager logger)
        {
            _tankkaartService = tankkaartService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllTankkaarten")]
        public IActionResult Get()
        {

            _logger.LogInfo("Alle tankkaarten aan het ophalen.");

            IEnumerable<TankkaartDTO> tankkaartDTOs = _tankkaartService.GetTankkaarten(null);

            _logger.LogInfo($"Ophalen van {tankkaartDTOs.Count()} records.");

            return Ok(tankkaartDTOs);
        }

        [HttpGet("{id}", Name = "GetTankkaart")]
        public IActionResult Get(long id)
        {
            TankkaartDTO tankkaartDTO = _tankkaartService.GetTankkaart(id);
            if (tankkaartDTO == null)
            {
                return NotFound("Tankkaart niet gevonden.");
            }
            return Ok(tankkaartDTO);
        }

    }
}
