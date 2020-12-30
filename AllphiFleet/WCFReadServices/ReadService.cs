using System;
using System.Collections.Generic;
using WCFReadEntities;

namespace WCFReadServices
{
    public class ReadService : IReadService
        //, IDisposable
    {
        //private readonly IAdresService _adresService;
        public ReadService()
        {
            //_adresService = adresService;
        }
        public List<Address> GetAddresses()
        {
            //return _adresService.GetAddressen();
            List<Address> addressList = new List<Address>();

            Address address1 = new Address
            {
                Id = 1,
                Street = "Hof ter Brempt",
                Number = 14,
                Zipcode = 9200,
                City = "Dendermonde"
            };
            Address address2 = new Address
            {
                Id = 2,
                Street = "Sporenpark",
                Number = 19,
                Zipcode = 9000,
                City = "Merelbeke"
            };

            addressList.Add(address1);
            addressList.Add(address2);

            return addressList;
        }

        /*
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        */
    }
}
