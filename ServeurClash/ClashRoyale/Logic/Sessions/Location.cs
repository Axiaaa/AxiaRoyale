using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpRaven.Data;

namespace ClashRoyale.Logic.Sessions
{
    public class Location
    {
        [JsonProperty("countryName")] public string CountryName { get; set; } 
        [JsonProperty("countryCode")] public string CountryCode { get; set; }
        [JsonProperty("cityName")] public string City { get; set; }

        public static async Task<Location> GetByIpAsync(string ip)
        {
            try
            {
                if (ip == "127.0.0.1" || ip.StartsWith("192")) return null;

                using (var client = new HttpClient())
                {
                    var IP = await client.GetStringAsync("https://freeipapi.com/api/json/" + ip);
                    //Console.WriteLine("Location correctly loaded"); To test
                    return JsonConvert.DeserializeObject<Location>(IP);
                }
            }
            catch (Exception)
            {
                Logger.Log($"Couldn't track location of {ip}", null, ErrorLevel.Error);
                return null;
            }

        }
    }
}