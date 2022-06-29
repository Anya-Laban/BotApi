using API.Models.Places_M;

namespace API.Models.WishList
{
    public class AddPlace
    {
        public string _id { get; set; }
        public string _name { get; set; }
        public string _nameObject { get; set; }
        public string _city { get; set; }
        public string _placeName { get; set; }
        public AddPlace(string id, string name, string nameObject, string city, string placeName)
        {
            _id = id;
            _name = name;
            _city = city;
            _placeName = placeName;
            _nameObject = nameObject;
        }
    }
}
