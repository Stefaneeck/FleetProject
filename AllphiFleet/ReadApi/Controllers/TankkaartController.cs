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
        //DI
        private readonly ITankkaartService _tankkaartService;
        private readonly ILoggerManager _logger;
        public TankkaartController(ITankkaartService tankkaartService, ILoggerManager logger)
        {
            _tankkaartService = tankkaartService;
            _logger = logger;
        }
        // GET: api/tankkaart
        [HttpGet(Name = "getAllTankkaarten")]
        //nog omzetten naar async? zie PS API cursus 'returning models instead of entities' hoofdstuk

        public IActionResult Get()
        {

            _logger.LogInfo("Alle tankkaarten aan het ophalen.");

            IEnumerable<TankkaartDTO> tankkaartDTOs = _tankkaartService.GetTankkaarten(null);

            //throw new Exception("Exception tijdens ophalen van chauffeurs.");

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
