using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using API.Models.Hotel_M;
using System.Text.RegularExpressions;

namespace API.Clients.Hotel_Cl
{
    public class HotelsCityIdClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;
        private static string _apiHost;
        public HotelsCityIdClient()
        {
            _address = Constants.adressHotelApi;
            _apiKey = Constants.apiKeyHotel;
            _apiHost = Constants.apiHostHotel;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<string> GetHotelsByCity(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/locations/v2/search?query={city}&locale=en_US&currency=USD"),
                Headers =
                {
                    { "X-RapidAPI-Host",_apiHost },
                    { "X-RapidAPI-Key", _apiKey },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CityHotels>(body);
                    string HotelsId = null;
                    for (int i = 0; i < result.Suggestions.Count; i++)
                    {
                        if (city == result.Suggestions[0].Entities[i].Name)
                        {
                            HotelsId = JsonConvert.DeserializeObject<string>(result.Suggestions[0].Entities[i].DestinationId);
                            break;
                        }
                        else continue; ;
                    }


                    return HotelsId;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
