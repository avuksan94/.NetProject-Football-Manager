using DL;
using DL.Model;
using DL.Repo;
using DL.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class MatchesServices
    {
        private IDataRetrievalStrategy<Match> getDataMale;
        private IDataRetrievalStrategy<Match> getDataFemale;

        private readonly DataRepo<Match> repoMale;
        private readonly DataRepo<Match> repoFemale;

        public MatchesServices()
        {
            if (!MyWorker.NetworkConnectivityCheck.ServerStatusBy(Constants.API_PING))
            {
                getDataMale = new LocalDataRetrievalStrategy<Match>(Constants.pathToMenMatches);
                getDataFemale = new LocalDataRetrievalStrategy<Match>(Constants.pathToWomenMatches);

                repoMale = new DataRepo<Match>(getDataMale);
                repoFemale = new DataRepo<Match>(getDataFemale);
            }
            else
            {
                getDataMale = new ApiDataRetrievalStrategy<Match>(new HttpClient(), Constants.TEAMS_MATCHES_M);
                getDataFemale = new ApiDataRetrievalStrategy<Match>(new HttpClient(), Constants.TEAMS_MATCHES_W);
                repoMale = new DataRepo<Match>(getDataMale);
                repoFemale = new DataRepo<Match>(getDataFemale);
            }
        }

        public async Task<List<Match>> GetMaleMatches()
        {
            IEnumerable<Match> matches = await repoMale.GetAllAsync();
            List<Match> matchesMale = matches.ToList();
            return matchesMale;
        }

        public async Task<List<Match>> GetFemaleMatches()
        {
            IEnumerable<Match> matches = await repoFemale.GetAllAsync();
            List<Match> matchesFemale = matches.ToList();
            return matchesFemale;
        }

        public SortedDictionary<string, SortedSet<Player>> LoadPlayers(IList<Match> matches)
        {

            SortedDictionary<string, SortedSet<Player>> countryPlayers = new SortedDictionary<string, SortedSet<Player>>();

            foreach (var item in matches.ToList())
            {
                string countryName = item.HomeTeamStatistics.Country;
                SortedSet<Player> players;
                if (!countryPlayers.TryGetValue(countryName, out players))
                {
                    players = new SortedSet<Player>();
                    countryPlayers.Add(countryName, players);
                }

                item.HomeTeamStatistics.StartingEleven
                    .ToList()
                    .ForEach(
                        c => players.Add(new Player
                        {
                            Name = c.Name,
                            Position = c.Position,
                            ShirtNumber = c.ShirtNumber,
                            Captain = c.Captain
                        }
                      )
                    );

                item.HomeTeamStatistics.Substitutes
                    .ToList()
                    .ForEach(
                         c => players.Add(new Player
                         {
                             Name = c.Name,
                             Position = c.Position,
                             ShirtNumber = c.ShirtNumber,
                             Captain = c.Captain
                         }
                       )
                     );
            }
            return countryPlayers;
        }
    }
}
