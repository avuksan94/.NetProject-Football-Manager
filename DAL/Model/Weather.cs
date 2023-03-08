using RepoStrategy.Converters;
using RepoStrategy.Enums;
using Newtonsoft.Json;

namespace RepoStrategy.Model
{
    public partial class Weather
    {
        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

}

