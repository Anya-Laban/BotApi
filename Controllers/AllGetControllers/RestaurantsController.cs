using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using API.Clients.Restoraunt_Cl;
using API.Models.Restoraunt_M;
using API.Models.Parametrs;
using API.Models.Parameters;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsClient _restaurantsClient;
        public RestaurantsController(RestaurantsClient restaurantsClient)
        {
            _restaurantsClient = restaurantsClient;
        }

        [HttpPost(Name = "GetRestaurantsByCityId")]
        public async Task<Restaurants> GetRestaurantsByCityId([FromQuery] CityIdParameters cityId, [FromQuery] RestaurantsParameters parameters)
        {
            var restaurants = await _restaurantsClient.GetRestaurantsByCityId(cityId.Id, parameters.Limit);
            return restaurants;
        }
    }
}
