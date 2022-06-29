using API.Clients.Places_Cl;
using API.Models.Parametrs;
using API.Models.Places_M;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesInCityController : ControllerBase
    {
        private readonly PlacesCityClient _placesCityClient;


        public PlacesInCityController(PlacesCityClient placesCityClient)
        {
            _placesCityClient = placesCityClient;
        }

        [HttpGet(Name = "GetCityCoordinates")]
        public async Task<CityPlaces> GetHotelsInCity([FromQuery] CityParameters parameters)
        {
            var hotels = await _placesCityClient.GetPlacesInCity(parameters.City);
            return hotels;
        }
    }
}
