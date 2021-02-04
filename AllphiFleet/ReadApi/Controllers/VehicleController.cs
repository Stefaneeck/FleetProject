using System.Collections.Generic;
using System.Linq;
using DTO;
using DTO.LicensePlate;
using DTO.MileageHistory;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILoggerManager _logger;
        public VehicleController(IVehicleService vehicleService, ILoggerManager logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllVehicles")]
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all vehicles.");

            IEnumerable<VehicleDTO> vehicleDTOs = _vehicleService.GetVehicles();

            _logger.LogInfo($"Retrieving {vehicleDTOs.Count()} records.");

            return Ok(vehicleDTOs);
        }

        [HttpGet("{id}", Name = "GetVehicle")]
        public IActionResult Get(long id)
        {
            VehicleDTO vehicleDTO = _vehicleService.GetVehicle(id);
            if (vehicleDTO == null)
            {
                return NotFound("Vehicle has not been found.");
            }
            return Ok(vehicleDTO);
        }

        [HttpGet("getmileagehistory/{vehicleId:int}", Name = "GetVehicleMileageHistory")]
        public IActionResult GetMileageHistory(long vehicleId)
        {
            IEnumerable<MileageHistoryDTO> mileageHistoryDTOs = _vehicleService.GetVehicleMileageHistory(vehicleId);
            if (!mileageHistoryDTOs.Any())
            {
                //not returning notfound because we need to read the 0 value on angular side
                return Ok(0);
            }
            return Ok(mileageHistoryDTOs);
        }

        [HttpGet("getvehiclelicenseplates/{vehicleId:int}", Name = "GetVehicleLicensePlates")]
        public IActionResult GetVehicleLicensePlates(long vehicleId)
        {
            IEnumerable<LicensePlateDTO> licensePlateDTOs = _vehicleService.GetVehicleLicensePlates(vehicleId);
            if(!licensePlateDTOs.Any())
            {
                return Ok(0);
            }
            return Ok(licensePlateDTOs);
        }

    }
}
