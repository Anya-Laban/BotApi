using API.Models.Weather_M;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Clients.Weather_Cl
{
    public class WeatherClient
    {
        private HttpClient _client;
        private static string _adress;
        private static string _apiKey;
        private static string _apiHost;
        public WeatherClient()
        {
            _adress = Constants.apiWeather;
            _apiKey = Constants.apiKeyWeather;
            _apiHost = Constants.apiHostWeather;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }
        public async Task<WeatherByCity> GetWeatherByCity(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_adress}/forecast/daily?q={city}&cnt=7&units=metric"),
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
                    var result = JsonConvert.DeserializeObject<WeatherByCity>(body);
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
