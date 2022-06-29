using Microsoft.AspNetCore.Mvc;
using API.Clients.Hotel_Cl;
using System.Threading.Tasks;
using API.Models.Hotel_M;
using Newtonsoft.Json;
using API.Models.Parametrs;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsIdCityController : ControllerBase
    {
        private readonly HotelsCityIdClient _hotelCityClient;

        public HotelsIdCityController(HotelsCityIdClient hotelCityClient)
        {
            _hotelCityClient = hotelCityClient;
        }

        [HttpGet(Name = "HotelsIdCity")]
        public async Task<string> GetHotelsByCity([FromQuery] CityParameters parameters)
        {
            var hotelsId = await _hotelCityClient.GetHotelsByCity(parameters.City);
            return hotelsId;
        }

    }
}
