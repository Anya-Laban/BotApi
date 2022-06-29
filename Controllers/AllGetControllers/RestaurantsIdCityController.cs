
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API.Clients.Restoraunt_Cl;
using API.Models.Parametrs;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsIdCityController : ControllerBase
    {
        private readonly RestaurantsIDClient _restaurantsIdClient;
        public static string RestaurantsID = null;
        public RestaurantsIdCityController(RestaurantsIDClient restaurantsIdClient)
        {
            _restaurantsIdClient = restaurantsIdClient;
        }

        [HttpPost(Name = "GetRestaurantsIdByCity")]
        public async Task<string> GetRestaurantsIdByCity([FromQuery] CityParameters parameters)
        {
            var restaurantsId = await _restaurantsIdClient.GetRestaurantsIdByCity(parameters.City);
            return restaurantsId;
        }

    }
}
