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
        List<Driver> GetDrivers();

        [OperationContract]
        Driver GetDriverById(int id);

        [OperationContract]
        List<Address> GetAddresses();

        [OperationContract]
        Address GetAddressById(int id);

        [OperationContract]
        List<FuelCard> GetFuelCards();

        [OperationContract]
        Task<FuelCard> GetFuelCardByIdAsync(int id);
    }
}
