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
            List<Address> mappedList = adressenList.Select(a =>
            
                new Address()
                {
                    Id = a.Id,
                    Street = a.Straat,
                    Number = a.Nummer,
                    Zipcode = a.Postcode,
                    City = a.Stad
                })
                .ToList();

            return mappedList;
        }

        public List<Driver> GetDrivers()
        {
            List<Chauffeur> chauffeursList = dbContext.Chauffeurs.ToList();
            List<Driver> driverList = chauffeursList.Select (c =>

            new Driver()
            {
                Active = c.Actief,
                AddressId = c.AdresId,
                DateOfBirth = c.GeboorteDatum,
                Id = c.Id,
                Name = c.Naam,
                FirstName = c.Voornaam,
                FuelCardId = c.TankkaartId,
                SocSecNumber = c.RijksRegisterNummer
            })
                .ToList();

            return driverList;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
