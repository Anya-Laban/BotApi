using API.Clients.Places_Cl;
using API.Models.Places_M;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PostPlaceController : ControllerBase
    {
        private readonly WishListPlaceClient _postPlaceClient;
        public PostPlaceController(WishListPlaceClient postPlaceClient)
        {
            _postPlaceClient = postPlaceClient;
        }
        [HttpPost(Name = "PostTravelPlace")]
        public async Task PostTravelPlace(string idClient, string name,string nameObject, string city, [FromBody] string placeAdd)
        {
            await _postPlaceClient.PostPlace(idClient, name, nameObject, city, placeAdd);
            return;
        }
    }
}
