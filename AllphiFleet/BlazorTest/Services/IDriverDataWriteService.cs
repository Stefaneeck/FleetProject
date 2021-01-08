using ModelsStandard;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public interface IDriverDataWriteService
    {
        Task<Driver> AddDriver(Driver driver);
        Task UpdateDriver(Driver driver);
        Task DeleteDriver(int driverId);
    }
}
