using Newtonsoft.Json;

namespace RepoStrategy.Model
{
    public partial class Team
    {
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("goals", NullValueHandling = NullValueHandling.Ignore)]
        public long Goals { get; set; }

        [JsonProperty("penalties", NullValueHandling = NullValueHandling.Ignore)]
        public long Penalties { get; set; }

        public override string ToString()
        {
            return $"Country: {Country} Code:{Code} Goals:{Goals} Penalties:{Penalties}";
        }
    }
}

