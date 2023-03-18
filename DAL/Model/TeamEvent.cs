using RepoStrategy.Enums;
using Newtonsoft.Json;

namespace RepoStrategy.Model
{
    public partial class TeamEvent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("type_of_event", NullValueHandling = NullValueHandling.Ignore)]
        public TypeOfEvent TypeOfEvent { get; set; }

        [JsonProperty("player", NullValueHandling = NullValueHandling.Ignore)]
        public string Player { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public string Time { get; set; }

    }
}

