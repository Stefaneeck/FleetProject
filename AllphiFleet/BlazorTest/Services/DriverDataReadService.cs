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
    }
}
