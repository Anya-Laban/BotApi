using API.Clients.Places_Cl;
using API.Models.Parameters;
using API.Models.Places_M;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlacesClient _placesClient;

        public PlacesController(PlacesClient placesClient)
        {
            _placesClient = placesClient;
        }

        [HttpGet(Name = "GetTravelPlaces")]
        public async Task<Places> GetHotelsInCity([FromQuery] PlacesParameters parameters)
        {
            var hotels = await _placesClient.GetPlaces(parameters.Max_Radius, parameters.Lon, parameters.Lat, parameters.Rating, parameters.Limit);
            return hotels;
        }
    }
}
