using Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFReadServices
{
    //made public for external access
    [ServiceContract]
    public interface IReadService
    {
        [OperationContract]
        Task<List<Driver>> GetDriversAsync();

        [OperationContract]
        Task<Driver> GetDriverById(int id);

        [OperationContract]
        Task<List<Address>> GetAddresses();

        [OperationContract]
        Task<Address> GetAddressById(int id);

        [OperationContract]
        Task<List<FuelCard>> GetFuelCards();

        [OperationContract]
        Task<FuelCard> GetFuelCardByIdAsync(int id);
    }
}
