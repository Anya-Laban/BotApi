using System.Collections.Generic;

namespace API.Models.Restoraunt_M
{
    public class CityRestaurants
    {
        public Results results { get; set; }
        public class Results
        {
            public List<Data> data { get; set; }

            public class Data
            {
                public Result_object Result_object { get; set; }
            }
        }
    }
    public class Result_object
    {
        public string Location_id { get; set; }
        public string Name { get; set; }
    }
}
