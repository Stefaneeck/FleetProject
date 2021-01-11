using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public interface IDriverDataReadService
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<Driver> GetDriverDetails(int driverId);

    }
}
