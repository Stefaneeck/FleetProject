using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface ITankkaartService
    {
        public IEnumerable<TankkaartDTO> GetTankkaarten(DriverFilter filter);
        public TankkaartDTO GetTankkaart(long id);
    }
}
