using Newtonsoft.Json;
using RepoStrategy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Player : IComparable<Player>
    {
        public const char DELIMITER = '|';
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("captain", NullValueHandling = NullValueHandling.Ignore)]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number", NullValueHandling = NullValueHandling.Ignore)]
        public long ShirtNumber { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public Position Position { get; set; }

        public int CompareTo(Player other) => Name.CompareTo(other.Name);

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString() => $"{Name}{DELIMITER.ToString()}" +
                                             $"{ShirtNumber}{DELIMITER.ToString()}" +
                                             $"{Position.ToString()}{DELIMITER.ToString()}" +
                                             $"{Captain}";
    }   
}
