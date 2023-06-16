using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Model;
using WPFTestingGround.Model;

namespace WPFTestingGround.Mapper
{
    public class TeamResultMapper
    {
        public TeamResultBL MapToViewModel(TeamResult playerResult)
        {
            return new TeamResultBL
            {
                AlternateName = playerResult.AlternateName,
                Country = playerResult.Country,
                Draws = playerResult.Draws,
                FifaCode = playerResult.FifaCode,
                GamesPlayed = playerResult.GamesPlayed,
                GoalDifferential = playerResult.GoalDifferential,
                GoalsAgainst = playerResult.GoalsAgainst,
                GoalsFor = playerResult.GoalsFor,
                GroupId = playerResult.GroupId,
                GroupLetter = playerResult.GroupLetter,
                Id = playerResult.Id,
                Losses = playerResult.Losses,
                Points = playerResult.Points,
                Wins = playerResult.Wins
            };
        }
    }
}
