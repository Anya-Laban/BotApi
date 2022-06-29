
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API.Clients.Hotel_Cl;
using API.Models.Hotel_M;
using API.Models.Restoraunt_M;
using API.Models.Parametrs;

namespace API.Controllers.AllControllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelsClient _hotelClient;

        public HotelsController(HotelsClient hotelClient)
        {
            _hotelClient = hotelClient;
        }

        [HttpGet(Name = "GetHotelsInCity")]
        public async Task<Hotels> GetHotelsInCity([FromQuery] CityIdParameters cityId, [FromQuery] HotelParameters parametrs)
        {
            var hotels = await _hotelClient.GetHotels(cityId.Id, parametrs.Checkin_date, parametrs.Checkout_date, parametrs.Adults_number, parametrs.SortOrder);
            return hotels;
        }
    }
}
