using RepoStrategy.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RepoStrategy.Model
{
    public partial class TeamStatistics
    {
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("attempts_on_goal", NullValueHandling = NullValueHandling.Ignore)]
        public long AttemptsOnGoal { get; set; }

        [JsonProperty("on_target", NullValueHandling = NullValueHandling.Ignore)]
        public long OnTarget { get; set; }

        [JsonProperty("off_target", NullValueHandling = NullValueHandling.Ignore)]
        public long OffTarget { get; set; }

        [JsonProperty("blocked", NullValueHandling = NullValueHandling.Ignore)]
        public long Blocked { get; set; }

        [JsonProperty("woodwork", NullValueHandling = NullValueHandling.Ignore)]
        public long Woodwork { get; set; }

        [JsonProperty("corners", NullValueHandling = NullValueHandling.Ignore)]
        public long Corners { get; set; }

        [JsonProperty("offsides", NullValueHandling = NullValueHandling.Ignore)]
        public long Offsides { get; set; }

        [JsonProperty("ball_possession", NullValueHandling = NullValueHandling.Ignore)]
        public long BallPossession { get; set; }

        [JsonProperty("pass_accuracy", NullValueHandling = NullValueHandling.Ignore)]
        public long PassAccuracy { get; set; }

        [JsonProperty("num_passes", NullValueHandling = NullValueHandling.Ignore)]
        public long NumPasses { get; set; }

        [JsonProperty("passes_completed", NullValueHandling = NullValueHandling.Ignore)]
        public long PassesCompleted { get; set; }

        [JsonProperty("distance_covered", NullValueHandling = NullValueHandling.Ignore)]
        public long DistanceCovered { get; set; }

        [JsonProperty("balls_recovered", NullValueHandling = NullValueHandling.Ignore)]
        public long BallsRecovered { get; set; }

        [JsonProperty("tackles", NullValueHandling = NullValueHandling.Ignore)]
        public long Tackles { get; set; }

        [JsonProperty("clearances", NullValueHandling = NullValueHandling.Ignore)]
        public long? Clearances { get; set; }

        [JsonProperty("yellow_cards", NullValueHandling = NullValueHandling.Ignore)]
        public long? YellowCards { get; set; }

        [JsonProperty("red_cards", NullValueHandling = NullValueHandling.Ignore)]
        public long RedCards { get; set; }

        [JsonProperty("fouls_committed", NullValueHandling = NullValueHandling.Ignore)]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics", NullValueHandling = NullValueHandling.Ignore)]
        public Tactics Tactics { get; set; }

        [JsonProperty("starting_eleven", NullValueHandling = NullValueHandling.Ignore)]
        public List<StartingEleven> StartingEleven { get; set; }

        [JsonProperty("substitutes", NullValueHandling = NullValueHandling.Ignore)]
        public List<StartingEleven> Substitutes { get; set; }

        public override string ToString()
        {
            return $"Country : {Country}, {StartingEleven}";
        }
    }
}

