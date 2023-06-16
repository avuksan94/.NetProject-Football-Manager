using DL.Converters;
using DL.Enums;
using Newtonsoft.Json;

namespace DL.Model
{
    public partial class Weather
    {
        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius", NullValueHandling = NullValueHandling.Ignore)]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit", NullValueHandling = NullValueHandling.Ignore)]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed", NullValueHandling = NullValueHandling.Ignore)]
        public long WindSpeed { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public Description Description { get; set; }
    }

}

