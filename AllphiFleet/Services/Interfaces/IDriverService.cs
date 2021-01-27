using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IDriverService
    {
        public IEnumerable<DriverDTO> GetDrivers();
        public DriverDTO GetDriver(long id);
        public long GetDriverIdByEmail(string email);
    }
}
