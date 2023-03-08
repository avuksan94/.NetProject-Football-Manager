using RepoStrategy.Converters;
using RepoStrategy.Enums;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Generic;
using System;

namespace RepoStrategy.Model
{
    public partial class Match
    {

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("away_team")]
        public Team AwayTeam { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("fifa_id")]
        public long FifaId { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTimeOffset LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTimeOffset? LastScoreUpdateAt { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("officials")]
        public List<string> Officials { get; set; }

        [JsonProperty("stage_name")]
        public StageName? StageName { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }


    }
}