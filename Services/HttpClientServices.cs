using IntergalacticAirways.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntergalacticAirways.Services
{
    public class HttpClientServices
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public HttpClientServices()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Starships> GetStarships(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<Starships>(content);
                return dto;
            }
            return null;
        }

        public async Task<Pilot> GetPilot(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<Pilot>(content);
                return dto;
            }
            return null;
        }
    }
}
