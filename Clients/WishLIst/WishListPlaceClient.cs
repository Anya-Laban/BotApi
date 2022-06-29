using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using API.Models.WishList;
using System.Text.RegularExpressions;
using System;

namespace API.Clients.Places_Cl
{
    public class WishListPlaceClient
    {
        // private static string path = @"C:\Users\Anna\Desktop\Навчання КПІ\Програмування\Курсова\Data\Places\Place.txt";


        private string path;
        string fileName = @"Place.txt";
        public  async Task<string> GetPath()
        {
            string fullPathOnly = Path.GetFullPath(@"Place.txt");
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            return fullPathOnly;
        }


        public async Task PostPlace(string idClient, string name, string nameObject, string city, string data)
        {
            path = GetPath().Result;
            AddPlace addPlace = new AddPlace(idClient, name, nameObject, city, data);

            string placeAdd = JsonConvert.SerializeObject(addPlace);

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(placeAdd);
            }

        }
        public async Task<List<AddPlace>> GetPlace(string idClient, string city)
        {
            path = GetPath().Result;
            List<AddPlace> wishList = new List<AddPlace>();
            using (StreamReader sr = new StreamReader(path))
            {
                string st = await sr.ReadToEndAsync();
                Regex regex = new Regex("({)(\"_id\")((S|.)+)(\")(})", RegexOptions.Multiline);
                MatchCollection matches = regex.Matches(st);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        AddPlace result = JsonConvert.DeserializeObject<AddPlace>(match.Value);
                        if (result._id == idClient && result._city == city)
                        {
                            wishList.Add(result);
                        }
                    }
                    return wishList;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<string> DeletePlace(string idClient, string city, string nameObject)
        {
            path = GetPath().Result;
            List<AddPlace> wishList = new List<AddPlace>();
            string resultString = "There isn't place with this name in the list";
            using (StreamReader sr = new StreamReader(path))
            {
                string st = await sr.ReadToEndAsync();
                Regex regex = new Regex("({)(\"_id\")((S|.)+)(\")(})", RegexOptions.Multiline);
                MatchCollection matches = regex.Matches(st);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        AddPlace result = JsonConvert.DeserializeObject<AddPlace>(match.Value);
                        if (result._id == idClient && result._city == city && result._nameObject == nameObject)
                        {
                            resultString = "successfully deleted";
                            continue;
                        }
                        else
                        {
                            wishList.Add(result);
                        }
                    }
                }
                else
                {
                    wishList = null;
                }
            }
            if (wishList == null)
            {
                resultString = "You haven't wishlist in this city";
            }
            else
            {
                File.WriteAllText(path, string.Empty);
                for (int i = 0; i < wishList.Count; i++)
                {
                    string placeAdd = JsonConvert.SerializeObject(wishList[i]);

                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(placeAdd);
                    }
                }
            }
            return resultString;
        }
    }
}
