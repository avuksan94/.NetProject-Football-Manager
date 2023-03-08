using Newtonsoft.Json;

namespace RepoStrategy.Model
{
    public partial class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public override string ToString()
        {
            return $"Country: {Country} Code:{Code} Goals:{Goals} Penalties:{Penalties}";
        }
    }
}

