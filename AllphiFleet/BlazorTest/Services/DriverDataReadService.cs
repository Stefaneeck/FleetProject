using ModelsStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    //splitted in read and write because of builder.Services.AddHttpClient<IDriverDataReadService, DriverDataReadService>(client => client.BaseAddress = new Uri("https://localhost:44334/")); in program.cs
    //need 2 different uri's, but can only add one per statement, so splitted in 2
    public class DriverDataReadService : IDriverDataReadService
    {
        private readonly HttpClient _httpClient;

        public DriverDataReadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Driver>>
                    (await _httpClient.GetStreamAsync($"api/driver"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Driver> GetDriverDetails(int driverId)
        {
            return await JsonSerializer.DeserializeAsync<Driver>
                (await _httpClient.GetStreamAsync($"api/driver/{driverId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
