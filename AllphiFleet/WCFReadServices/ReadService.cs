using System;
using System.Collections.Generic;
using System.Linq;
using WCFReadData;
using WCFReadEntities;

namespace WCFReadServices
{
    public class ReadService : IReadService, IDisposable
    {
        readonly FleetDBContext dbContext = new FleetDBContext();
        public ReadService()
        {

        }
        public List<Address> GetAddresses()
        {

            return dbContext.Adressens.Select(a =>

                new Address()
                {
                    Id = a.Id,
                    Street = a.Straat,
                    Number = a.Nummer,
                    Zipcode = a.Postcode,
                    City = a.Stad
                })
                .ToList();

        }

        public List<Driver> GetDrivers()
        {
            /* not working (linq will try to find MapChauffeurToDriver at db level. Only after ToList() you are working outside of db.
            return dbContext.Chauffeurs.Select(c =>
           MapChauffeurToDriver(c)).ToList();
            */

            //solution with ToList()
            return dbContext.Chauffeurs.ToList().Select(c =>
           MapChauffeurToDriver(c)).ToList();
        }

        public List<FuelCard> GetFuelCards()
        {
            return dbContext.Tankkaartens.Select(t =>

           new FuelCard()
           {
               Id = t.Id,
               AuthType = t.AuthType,
               CardNumber = t.Kaartnummer,
               Pincode = t.Pincode,
               ValidUntilDate = t.GeldigheidsDatum,
               Options = t.Opties
           })
                .ToList();
        }
      
        public Address GetAddressById(int id)
        {
            var address = dbContext.Adressens.FirstOrDefault(a => a.Id == id);

            return new Address()
            {
                Id = address.Id,
                Street = address.Straat,
                Number = address.Nummer,
                Zipcode = address.Postcode,
                City = address.Stad
            };
        }

        public Driver GetDriverById(int id)
        {
            return MapChauffeurToDriver(dbContext.Chauffeurs.FirstOrDefault(c => c.Id == id));
        }

        public FuelCard GetFuelCardById(int id)
        {
            throw new NotImplementedException();
        }

        public Driver MapChauffeurToDriver(Chauffeur c)
        {
            return new Driver()
            {
                Active = c.Actief,
                DateOfBirth = c.GeboorteDatum,
                Id = c.Id,
                Name = c.Naam,
                FirstName = c.Voornaam,
                SocSecNumber = c.RijksRegisterNummer,

                Address = new Address()
                {
                    Id = c.Adressen.Id,
                    Street = c.Adressen.Straat,
                    Number = c.Adressen.Nummer,
                    Zipcode = c.Adressen.Postcode,
                    City = c.Adressen.Stad
                },
                FuelCard = new FuelCard()
                {
                    Id = c.Tankkaarten.Id,
                    AuthType = c.Tankkaarten.AuthType,
                    CardNumber = c.Tankkaarten.Kaartnummer,
                    Pincode = c.Tankkaarten.Pincode,
                    ValidUntilDate = c.Tankkaarten.GeldigheidsDatum,
                    Options = c.Tankkaarten.Opties
                }
            };
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
