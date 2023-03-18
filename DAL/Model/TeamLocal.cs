using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Model
{
    public partial class TeamLocal
    {
     [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
     public long Id { get; set; }

     [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
     public string Country { get; set; }

     [JsonProperty("alternate_name", NullValueHandling = NullValueHandling.Ignore)]
     public object AlternateName { get; set; }

     [JsonProperty("fifa_code", NullValueHandling = NullValueHandling.Ignore)]
     public string FifaCode { get; set; }

     [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
     public long GroupId { get; set; }

     [JsonProperty("group_letter", NullValueHandling = NullValueHandling.Ignore)]
     public string GroupLetter { get; set; }

     public override string ToString() => $"{Id}, {Country}, {AlternateName}, {FifaCode},{GroupId}, {GroupLetter}";

     
    }
}
