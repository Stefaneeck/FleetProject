using ModelsStandard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public interface IDriverDataReadService
    {
        Task<IEnumerable<Chauffeur>> GetAllDrivers();
        Task<Chauffeur> GetDriverDetails(int driverId);
        Task<Chauffeur> AddDriver(Chauffeur driver);
        Task UpdateDriver(Chauffeur driver);
        Task DeleteDriver(int driverId);
    }
}
