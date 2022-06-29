using System.Collections.Generic;

namespace API.Models.Hotel_M
{
    public class CityHotels
    {
        public string Term { get; set; }
        public List<Suggestions> Suggestions { get; set; }
    }
    public class Suggestions
    {
        public string Group { get; set; }
        public List<Entities> Entities { get; set; }
    }
    public class Entities
    {
        public string GeoId { get; set; }
        public string DestinationId { get; set; }
        public string LandmarkCityDestinationId { get; set; }
        public string Type { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
    }
}
