using API.Models.Places_M;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Clients.Places_Cl
{
    public class PlacesClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;
        private static string _apiHost;
        public PlacesClient()
        {
            _address = Constants.adressPlacessApi;
            _apiKey = Constants.apiKeyPlaces;
            _apiHost = Constants.apiHostPlaces;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<Places> GetPlaces(string radius, string lon, string lat, string rate, string limit )
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/en/places/radius?radius={radius}&lon={lon}&lat={lat}&rate={rate}&limit={limit}"),
                Headers =
                {
                     { "X-RapidAPI-Host", _apiHost },
                    { "X-RapidAPI-Key", _apiKey },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Places>(body);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
