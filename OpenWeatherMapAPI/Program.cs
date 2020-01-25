using System;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "85b8af26a19beb103d3fcf1a6abdfd0a";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Tallinn&APPID="+key;

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var ResponseReader= new StreamReader(webStream))
            {
                var response = ResponseReader.ReadToEnd();
                var weather = JsonConvert.DeserializeObject<Weather>(response);
                Console.WriteLine(weather.Name);
                Console.WriteLine(TimestampToString(weather.Dt));
                Console.WriteLine($"Country: {weather.Sys.Country}");
                Console.WriteLine($"Temp: {weather.Main.Temp}");
                Console.WriteLine($"Feels: {weather.Main.FeelsLike}");
                Console.WriteLine($"Humidity: {weather.Main.Humidity}");
                Console.WriteLine($"Pressure: {weather.Main.Pressure}");
                Console.WriteLine($"Sunrise:{TimestampToString(weather.Sys.Sunrise)}");
                Console.WriteLine($"Sunset:{TimestampToString(weather.Sys.Sunset)}");
            }
            
        }
        public static string TimestampToString(int timestamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddSeconds(timestamp);
            return dt.ToString();
        }
    }
}