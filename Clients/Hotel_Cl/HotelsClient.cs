using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using API.Models.Hotel_M;

namespace API.Clients.Hotel_Cl
{
    public class HotelsClient
    {

        private HttpClient _client;
        private static string _address;
        private static string _apiKey;
        private static string _apiHost;
        public HotelsClient()
        {
            _address = Constants.adressHotelApi;
            _apiKey = Constants.apiKeyHotel;
            _apiHost = Constants.apiHostHotel;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<Hotels> GetHotels(string Id, string checkIn, string checkOut, string adults_number, string sortOrder)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/properties/list?destinationId={Id}&pageNumber=1&pageSize=10&checkIn={checkIn}&checkOut={checkOut}&adults1={adults_number}&sortOrder={sortOrder}&locale=en_US&currency=USD"),
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
                    var result = JsonConvert.DeserializeObject<Hotels>(body);
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
