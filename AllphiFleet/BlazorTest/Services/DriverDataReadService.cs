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
    public class DriverDataReadService : IDriverDataReadService
    {
        private readonly HttpClient _httpClient;

        public DriverDataReadService(HttpClient httpClient)
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

        public async Task<IEnumerable<Chauffeur>> GetAllDrivers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Chauffeur>>
                    (await _httpClient.GetStreamAsync($"api/chauffeur"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Chauffeur> GetDriverDetails(int driverId)
        {
            return await JsonSerializer.DeserializeAsync<Chauffeur>
                (await _httpClient.GetStreamAsync($"api/chauffeur/{driverId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateDriver(Chauffeur driver)
        {
            var driverJson =
                new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("writeapi/chauffeur", driverJson);
        }
    }
}
