using Newtonsoft.Json;

namespace Kairos
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("weather")]
        public Kairos[] Kairos { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }
    }


    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }


    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

    public class Sys
    {
        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

    public class Kairos
    {
        [JsonProperty("main")]
        public string Visibility { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
