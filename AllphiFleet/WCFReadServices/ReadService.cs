using System;
using System.Collections.Generic;
using System.Linq;
using WCFReadData;
using WCFReadEntities;

namespace WCFReadServices
{
    public class ReadService : IReadService
        //, IDisposable
    {
        readonly FleetDBContext dbContext = new FleetDBContext();
        public ReadService()
        {

        }
        public List<Address> GetAddresses()
        {
            List<Adressen> adressenList = dbContext.Adressens.ToList();
            List<Address> mappedList = adressenList.Select(i =>
            
                new Address()
                {
                    Id = i.Id,
                    Street = i.Straat,
                    Number = i.Nummer,
                    Zipcode = i.Postcode,
                    City = i.Stad
                })
                .ToList();

            return mappedList;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
