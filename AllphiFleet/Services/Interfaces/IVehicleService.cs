using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IVehicleService
    {
        public IEnumerable<VehicleDTO> GetVehicles();
        public VehicleDTO GetVehicle(long id);
    }
}
