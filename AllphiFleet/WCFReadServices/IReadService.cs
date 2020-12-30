using System.Collections.Generic;
using System.ServiceModel;
using WCFReadEntities;

namespace WCFReadServices
{
    //made public for external access
    [ServiceContract]
    public interface IReadService
    {
        //[OperationContract]
        //List<Driver> GetDrivers();

        [OperationContract]
        List<Address> GetAddresses();
    }
}
