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
    public class DriverDataWriteService : IDriverDataWriteService
    {
        private readonly HttpClient _httpClient;

        public DriverDataWriteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Chauffeur> AddDriver(Chauffeur driver)
        {
            var driverJson =
                new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("writeapi/chauffeur", driverJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Chauffeur>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteDriver(int driverId)
        {
            await _httpClient.DeleteAsync($"writeapi/chauffeur/delete/{driverId}");
        }

        public async Task UpdateDriver(Chauffeur driver)
        {
            var driverJson =
                new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("writeapi/chauffeur", driverJson);
        }
    }
}
