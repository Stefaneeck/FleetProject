using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace WCFReadServices
{
    public class ReadService : IReadService, IDisposable
    {
        readonly WCFReadData.AllphiFleetWCFContext dbContext = new WCFReadData.AllphiFleetWCFContext();
        public ReadService()
        {

        }

        public async Task<List<Driver>> GetDriversAsync()
        {
            List<Driver> drivers = new List<Driver>();

            // HTTP GET
            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/driver");
                        if (response.IsSuccessStatusCode)
                        {
                            drivers = await response.Content.ReadAsAsync<List<Driver>>();
                        }
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return drivers;
                }
            }

            #region commentEF
            /* should we be using EF6 to retrieve data:
             * not working (linq will try to find MapDriver at db level. Only after ToList() you are working outside of db.
               return dbContext.Driver.Select(c =>
               MapDriver(c)).ToList();
           
               solution with ToList():

               return dbContext.Drivers.ToList().Select(c =>
               MapDriver(c)).ToList();
            */
            #endregion

        }

        public async Task<Driver> GetDriverById(int id)
        {
            Driver driver = null;

            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/driver/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                            driver = await response.Content.ReadAsAsync<Driver>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return driver;
                }
            }

            //should we be using EF6
            //return MapDriver(dbContext.Drivers.FirstOrDefault(c => c.Id == id));
        }

        public async Task<List<Address>> GetAddresses()
        {
            List<Address> addressList = new List<Address>();

            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/address");
                        if (response.IsSuccessStatusCode)
                        {
                            addressList = await response.Content.ReadAsAsync<List<Address>>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return addressList;
                }
            }
        }

        public async Task<Address> GetAddressById(int id)
        {
            Address address = null;

            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/address/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                            address = await response.Content.ReadAsAsync<Address>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return address;
                }
            }
        }

        public async Task<List<FuelCard>> GetFuelCards()
        {
            #region commentEF6
            /*
             * should we be using EF6:
             * 
            //convert EF address to WCF address
            return dbContext.FuelCards.Select(f =>

           new FuelCard()
           {
               Id = f.Id,
               AuthType = (Models.Enums.AuthenticationTypes)f.AuthType,
               CardNumber = f.CardNumber,
               Pincode = f.Pincode,
               ValidUntilDate = f.ValidUntilDate,
               Options = f.Options
           })
                .ToList();
            */
            #endregion

            List<FuelCard> fuelCardList = new List<FuelCard>();

            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/fuelcard");
                        if (response.IsSuccessStatusCode)
                        {
                            fuelCardList = await response.Content.ReadAsAsync<List<FuelCard>>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return fuelCardList;
                }
            }
        }

        public async Task<FuelCard> GetFuelCardByIdAsync(int id)
        {
            #region commentEF6
            /*
             * should we be using EF6;
             * 
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
            */
            #endregion

            FuelCard fuelCard = null;

            using (var clientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 })
            {
                using (var client = new HttpClient(clientHandler, disposeHandler: true))
                {

                    client.BaseAddress = new Uri("https://localhost:44334/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"api/fuelcard/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                            fuelCard = await response.Content.ReadAsAsync<FuelCard>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write(e.InnerException);
                    }
                    return fuelCard;
                }
            }
        }

        public Driver MapDriver(WCFReadData.Driver d)
        {
            //convert from EF type to WCF type
            return new Driver()
            {
                Active = d.Active,
                BirthDate = d.BirthDate,
                Id = d.Id,
                Name = d.Name,
                FirstName = d.FirstName,
                SocSecNr = d.SocSecNr,

                Address = new Address()
                {
                    Id = d.Address.Id,
                    Street = d.Address.Street,
                    Number = d.Address.Number,
                    Zipcode = d.Address.Zipcode,
                    City = d.Address.City
                },
                FuelCard = new FuelCard()
                {
                    Id = d.FuelCard.Id,
                    AuthType = (Models.Enums.AuthenticationTypes)d.FuelCard.AuthType,
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
