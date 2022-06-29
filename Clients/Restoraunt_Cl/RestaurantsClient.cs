using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;
using API.Models.Restoraunt_M;

namespace API.Clients.Restoraunt_Cl
{
    public class RestaurantsClient
    {
        private HttpClient _client;
        private static string _adress;
        private static string _apiKey;
        private static string _apiHost;
        public RestaurantsClient()
        {
            _adress = Constants.adressRestaurantsApi;
            _apiKey = Constants.apiKeyRestaurant;
            _apiHost = Constants.apiHostRestaurant;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }
        public async Task<Restaurants> GetRestaurantsByCityId(string Id, string limit)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_adress),
                Headers =
                {
                    { "X-RapidAPI-Host", _apiHost },
                    { "X-RapidAPI-Key", _apiKey },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "language", "en_US" },
                    { "limit", limit },
                    { "location_id", Id },
                    { "currency", "USD" },
                }),
            };
            using (var response = await _client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Restaurants>(body);
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
