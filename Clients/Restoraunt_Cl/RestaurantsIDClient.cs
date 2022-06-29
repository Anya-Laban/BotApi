using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models.Restoraunt_M;
using System.Text.RegularExpressions;

namespace API.Clients.Restoraunt_Cl
{
    public class RestaurantsIDClient
    {
        private HttpClient _client;
        private static string _adressId;
        private static string _apiKey;
        private static string _apiHost;
        public RestaurantsIDClient()
        {
            _adressId = Constants.adressRestaurantsIdApi;
            _apiKey = Constants.apiKeyRestaurant;
            _apiHost = Constants.apiHostRestaurant;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adressId);
        }
        public async Task<string> GetRestaurantsIdByCity(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_adressId),
                Headers =
                {
                    { "X-RapidAPI-Host", _apiHost },
                    { "X-RapidAPI-Key", _apiKey },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", city },
                    { "language", "en_US" },
                }),
            };
            using (var response = await _client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CityRestaurants>(body);

                    string RestaurantsId = null;
                    if (result.results.data.Count == 0) { return null; }
                    for (int i = 0; i < result.results.data.Count; i++)
                    {
                        Regex regex = new Regex($"{city}.*", RegexOptions.Multiline);
                        MatchCollection matches = regex.Matches(result.results.data[i].Result_object.Name);
                        if (matches.Count != 0)
                        {
                            RestaurantsId = JsonConvert.DeserializeObject<string>(result.results.data[i].Result_object.Location_id);
                            break;
                        }
                        else continue;
                    }
                    return RestaurantsId;
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
        }

    }
}
