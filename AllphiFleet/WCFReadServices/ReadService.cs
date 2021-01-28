using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;
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

        public List<WCFReadEntities.Driver> GetDrivers()
        {
            #region commentlinq
            /* not working (linq will try to find MapDriver at db level. Only after ToList() you are working outside of db.
            return dbContext.Chauffeurs.Select(c =>
           MapDriver(c)).ToList();
            */
            #endregion

            //solution with ToList()
            return dbContext.Drivers.ToList().Select(c =>
           MapDriver(c)).ToList();
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
            /*
            WCFReadEntities.Driver driver = null;

            // HTTP GET
            using(var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12})
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("http://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/driver/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                            driver = await response.Content.ReadAsAsync<WCFReadEntities.Driver>();
                            Console.WriteLine("{0}\t${1}\t{2}", driver.Name, driver.FirstName, driver.Address);
                        }
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return driver;
                    /*
                    // HTTP POST
                    var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                    response = await client.PostAsJsonAsync("api/products", gizmo);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;

                        // HTTP PUT
                        gizmo.Price = 80;   // Update price
                        response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                        // HTTP DELETE
                        response = await client.DeleteAsync(gizmoUrl);
                    }
                   
                }
            }
             
             */

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
