using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Model
{
    public class GroupResult
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("letter", NullValueHandling = NullValueHandling.Ignore)]
        public string Letter { get; set; }

        [JsonProperty("ordered_teams", NullValueHandling = NullValueHandling.Ignore)]
        public List<OrderedTeam> OrderedTeams { get; set; }
    }
}
