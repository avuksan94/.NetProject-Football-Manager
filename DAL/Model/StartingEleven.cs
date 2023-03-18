using RepoStrategy.Enums;
using Newtonsoft.Json;

namespace RepoStrategy.Model
{
    public partial class StartingEleven
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("captain", NullValueHandling = NullValueHandling.Ignore)]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number", NullValueHandling = NullValueHandling.Ignore)]
        public long ShirtNumber { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public Position Position { get; set; }
    }
}

