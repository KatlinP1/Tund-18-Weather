using Newtonsoft.Json;

namespace OpenWeatherMapAPI
{
    public class Weather
    {
        public string Name { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public WeatherMain Main { get; set; }
        
        
    }

    public class WeatherMain
    {
        public string Temp { get; set; }
        [JsonProperty("feels_like")]public string FeelsLike { get; set; }
        [JsonProperty("temp_min")] public string TempMin { get; set; }
        [JsonProperty("temp_max")]public string TempMax { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
    }
    
    public class Sys
    {
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
    
}