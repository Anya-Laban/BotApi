using API.Clients.Weather_Cl;
using API.Models.Parametrs;
using API.Models.Weather_M;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetWeatherController : ControllerBase
    {
        private readonly WeatherClient _weatherClient;
        public GetWeatherController(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet(Name = "GetWeatherInCity")]
        public async Task<WeatherByCity> GetWeatherByCity([FromQuery] CityParameters parameters)
        {
            var weather = await _weatherClient.GetWeatherByCity(parameters.City);
            return weather;
        }
    }
}
