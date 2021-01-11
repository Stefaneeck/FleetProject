﻿using System;
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
            //convert EF address to WCF address
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
            /* not working (linq will try to find MapDriver at db level. Only after ToList() you are working outside of db.
            return dbContext.Chauffeurs.Select(c =>
           MapDriver(c)).ToList();
            */

            //solution with ToList()
            return dbContext.Drivers.ToList().Select(c =>
           MapDriver(c)).ToList();
        }

        public List<WCFReadEntities.FuelCard> GetFuelCards()
        {
            //convert EF address to WCF address

            return dbContext.FuelCards.Select(f =>

           new WCFReadEntities.FuelCard()
           {
               Id = f.Id,
               AuthType = f.AuthType,
               CardNumber = f.CardNumber,
               Pincode = f.Pincode,
               ValidUntilDate = f.ValidUntilDate,
               Options = f.Options
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

        public WCFReadEntities.Driver MapDriver(WCFReadData.Driver d)
        {
            //convert from EF type to WCF type
            return new WCFReadEntities.Driver()
            {
                Active = d.Active,
                DateOfBirth = d.BirthDate,
                Id = d.Id,
                Name = d.Name,
                FirstName = d.FirstName,
                SocSecNumber = d.SocSecNr,

                Address = new WCFReadEntities.Address()
                {
                    Id = d.Address.Id,
                    Street = d.Address.Street,
                    Number = d.Address.Number,
                    Zipcode = d.Address.Zipcode,
                    City = d.Address.City
                },
                FuelCard = new WCFReadEntities.FuelCard()
                {
                    Id = d.FuelCard.Id,
                    AuthType = d.FuelCard.AuthType,
                    CardNumber = d.FuelCard.CardNumber,
                    Pincode = d.FuelCard.Pincode,
                    ValidUntilDate = d.FuelCard.ValidUntilDate,
                    Options = d.FuelCard.Options
                }
            };
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
