using System;
using System.Collections.Generic;
using System.Linq;
using WCFReadData;
using WCFReadEntities;

namespace WCFReadServices
{
    public class ReadService : IReadService, IDisposable
    {
        readonly AllphiFleetWCFContext dbContext = new AllphiFleetWCFContext();
        public ReadService()
        {

        }
        public List<WCFReadEntities.Address> GetAddresses()
        {

            return dbContext.Addresses.Select(a =>

                new WCFReadEntities.Address()
                {
                    Id = a.Id,
                    Street = a.Street,
                    Number = a.Number,
                    Zipcode = a.Zipcode,
                    City = a.City
                })
                .ToList();

        }

        public List<WCFReadEntities.Driver> GetDrivers()
        {
            /* not working (linq will try to find MapChauffeurToDriver at db level. Only after ToList() you are working outside of db.
            return dbContext.Chauffeurs.Select(c =>
           MapChauffeurToDriver(c)).ToList();
            */

            //solution with ToList()
            return dbContext.Drivers.ToList().Select(c =>
           MapDriver(c)).ToList();
        }

        public List<WCFReadEntities.FuelCard> GetFuelCards()
        {
            return dbContext.FuelCards.Select( t =>

           new WCFReadEntities.FuelCard()
           {
               Id = t.Id,
               AuthType = t.AuthType,
               CardNumber = t.CardNumber,
               Pincode = t.Pincode,
               ValidUntilDate = t.ValidUntilDate,
               Options = t.Options
           })
                .ToList();
        }
      
        public WCFReadEntities.Address GetAddressById(int id)
        {
            var address = dbContext.Addresses.FirstOrDefault(a => a.Id == id);

            return new WCFReadEntities.Address()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                Zipcode = address.Zipcode,
                City = address.City
            };
        }

        public WCFReadEntities.Driver GetDriverById(int id)
        {
            return MapDriver(dbContext.Drivers.FirstOrDefault(c => c.Id == id));
        }

        public WCFReadEntities.FuelCard GetFuelCardById(int id)
        {
            var fuelCard = dbContext.FuelCards.FirstOrDefault(t => t.Id == id);

            return new WCFReadEntities.FuelCard()
            {
                Id = fuelCard.Id,
                AuthType = fuelCard.AuthType,
                CardNumber = fuelCard.CardNumber,
                Pincode = fuelCard.Pincode,
                ValidUntilDate = fuelCard.ValidUntilDate,
                Options = fuelCard.Options
            };
        }

        public WCFReadEntities.Driver MapDriver(WCFReadData.Driver c)
        {
            //convert from EF type to WCF type
            return new WCFReadEntities.Driver()
            {
                Active = c.Active,
                DateOfBirth = c.BirthDate,
                Id = c.Id,
                Name = c.Name,
                FirstName = c.FirstName,
                SocSecNumber = c.SocSecNr,

                Address = new WCFReadEntities.Address()
                {
                    Id = c.Address.Id,
                    Street = c.Address.Street,
                    Number = c.Address.Number,
                    Zipcode = c.Address.Zipcode,
                    City = c.Address.City
                },
                FuelCard = new WCFReadEntities.FuelCard()
                {
                    Id = c.FuelCard.Id,
                    AuthType = c.FuelCard.AuthType,
                    CardNumber = c.FuelCard.CardNumber,
                    Pincode = c.FuelCard.Pincode,
                    ValidUntilDate = c.FuelCard.ValidUntilDate,
                    Options = c.FuelCard.Options
                }
            };
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
