﻿using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WCFReadEntities;

namespace WCFReadServices
{
    //made public for external access
    [ServiceContract]
    public interface IReadService
    {
        [OperationContract]
        List<Driver> GetDrivers();

        [OperationContract]
        Task<Driver> GetDriverByIdAsync(int id);

        [OperationContract]
        List<Address> GetAddresses();

        [OperationContract]
        Address GetAddressById(int id);

        [OperationContract]
        List<FuelCard> GetFuelCards();

        [OperationContract]
        FuelCard GetFuelCardById(int id);
    }
}
