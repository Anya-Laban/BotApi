using API.Clients.Places_Cl;
using API.Models.Places_M;
using API.Models.WishList;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Wish_list
{
    [ApiController]
    [Route("[controller]")]
    public class GetPlaceController : ControllerBase
    {
        private readonly WishListPlaceClient _getPlaceClient;
        public GetPlaceController(WishListPlaceClient getPlaceClient)
        {
            _getPlaceClient = getPlaceClient;
        }
        [HttpGet(Name = "GetTravelPlace")]
        public async Task<List<AddPlace>> GetTravelPlace(string idClient, string city)
        {
            var places = await _getPlaceClient.GetPlace(idClient, city);
            return places;
        }
    }
}
