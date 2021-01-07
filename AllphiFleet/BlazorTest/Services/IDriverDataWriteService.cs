using ModelsStandard;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public interface IDriverDataWriteService
    {
        Task<Chauffeur> AddDriver(Chauffeur driver);
        Task UpdateDriver(Chauffeur driver);
        Task DeleteDriver(int driverId);
    }
}
