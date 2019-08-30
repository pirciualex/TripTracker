using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.API.Models;
using TripTracker.API.Services;

namespace TripTracker.UI.Services
{
    public class ApiClient : ITripService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAsync(Trip trip)
        {
            var response = await SendJsonAsync(_httpClient, HttpMethod.Post, "api/Trips", trip);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Trips{id}");
        }

        public async Task<IEnumerable<Trip>> GetAsync()
        {
            var response = await _httpClient.GetAsync("/api/Trips");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var jsonReader = new JsonTextReader(new StreamReader(stream));
            return _jsonSerializer.Deserialize<IEnumerable<Trip>>(jsonReader);
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Trips/{id}");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var jsonReader = new JsonTextReader(new StreamReader(stream));
            return _jsonSerializer.Deserialize<Trip>(jsonReader);
        }

        public bool TripExists(int id)
        {
            var trip = GetByIdAsync(id);
            return trip.Result == null;
        }

        public async Task UpdateAsync(Trip trip)
        {
            var response = await SendJsonAsync(_httpClient, HttpMethod.Put, $"api/Trips/{trip.Id}", trip);
            response.EnsureSuccessStatusCode();
        }

        public static Task<HttpResponseMessage> SendJsonAsync(HttpClient client, HttpMethod method, string url, Trip value)
        {
            var stream = new MemoryStream();
            var jsonWriter = new JsonTextWriter(new StreamWriter(stream));

            _jsonSerializer.Serialize(jsonWriter, value);

            jsonWriter.Flush();

            stream.Position = 0;

            var request = new HttpRequestMessage(method, url)
            {
                Content = new StreamContent(stream)
            };

            request.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");

            return client.SendAsync(request);
        }
    }
}
