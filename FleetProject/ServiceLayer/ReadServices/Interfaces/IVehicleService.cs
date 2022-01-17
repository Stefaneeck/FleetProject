using DTO;
using DTO.LicensePlate;
using DTO.MileageHistory;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IVehicleService
    {
        public IEnumerable<VehicleDTO> GetVehicles();
        public VehicleDTO GetVehicle(long id);
        public IEnumerable<MileageHistoryDTO> GetVehicleMileageHistory(long vehicleId);
        public IEnumerable<LicensePlateDTO> GetVehicleLicensePlates(long vehicleId);
    }
}
