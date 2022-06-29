
using API.Clients.Places_Cl;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Wish_list
{
    [ApiController]
    [Route("[controller]")]
    public class DeletePlaceController : ControllerBase
    {

        private readonly WishListPlaceClient _deletePlaceClient;
        public DeletePlaceController(WishListPlaceClient deletePlaceClient)
        {
            _deletePlaceClient = deletePlaceClient;
        }
        [HttpDelete("{idClient:long}")]
        public async Task<string> DeletePlace(long idClient, string city, string name)
        {
            var result = await _deletePlaceClient.DeletePlace(idClient.ToString(), city, name);
            return result ;
        }


    }
}
