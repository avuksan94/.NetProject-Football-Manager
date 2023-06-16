using DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingGround.Model;

namespace WPFTestingGround.Mapper
{
    public class MatchesMapper
    {
        public MatchesBL MapToViewModel(Match match)
        {
            return new MatchesBL
            {
                Attendance = match.Attendance,
                AwayTeam = match.AwayTeam,
                AwayTeamCountry = match.AwayTeamCountry,
                AwayTeamEvents = match.AwayTeamEvents,
                AwayTeamStatistics = match.AwayTeamStatistics,
                Datetime = match.Datetime,
                FifaId = match.FifaId,
                HomeTeam = match.HomeTeam,
                HomeTeamCountry = match.HomeTeamCountry,
                HomeTeamEvents = match.HomeTeamEvents,
                HomeTeamStatistics = match.HomeTeamStatistics,
                LastEventUpdateAt = match.LastEventUpdateAt,
                LastScoreUpdateAt = match.LastScoreUpdateAt,
                Location = match.Location,
                Officials = match.Officials,
                StageName = match.StageName,
                Status = match.Status,
                Time = match.Time,
                Venue = match.Venue,
                Weather = match.Weather,
                Winner = match.Winner,
                WinnerCode = match.WinnerCode
            };
        }
    }
}
