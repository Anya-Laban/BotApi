using API.Models.Places_M;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Clients.Places_Cl
{
    public class PlacesCityClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;
        private static string _apiHost;
        public PlacesCityClient()
        {
            _address = Constants.adressPlacessApi;
            _apiKey = Constants.apiKeyPlaces;
            _apiHost = Constants.apiHostPlaces;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<CityPlaces> GetPlacesInCity(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/en/places/geoname?name={city}"),
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
                    var result = JsonConvert.DeserializeObject<CityPlaces>(body);
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
