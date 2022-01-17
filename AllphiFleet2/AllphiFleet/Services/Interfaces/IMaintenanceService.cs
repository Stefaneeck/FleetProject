using DTO;
using Models;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IMaintenanceService
    {
        public IEnumerable<MaintenanceDTO> GetMaintenances();
        public MaintenanceDTO GetMaintenance(long id);
    }
}
