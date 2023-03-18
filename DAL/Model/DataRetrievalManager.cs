using RepoStrategy.Model;
using RepoStrategy.Repo;
using RepoStrategy.Strategy.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class DataRetrievalManager
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios

        private readonly IDataRetrievalStrategyFactory factory;
        public DataRetrievalManager() => factory = new DataRetrievalStrategyFactory();

        public const string API_PING = "worldcup-vua.nullbit.hr";
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";


        public List<TeamResult> MenResults { get; private set; }
        public List<TeamLocal> MenTeamLocal { get; private set; }
        public List<Match> MenMatches { get; private set; }
        public List<GroupResult> MenGroupResultLocal { get; private set; }

        public List<TeamResult> WomenResults { get; private set; }
        public List<TeamLocal> WomenTeamLocal { get; private set; }
        public List<Match> WomenMatches { get; private set; }
        public List<GroupResult> WomenGroupResultLocal { get; private set; }

        public static bool ServerStatusBy(string url)
        {
            Ping pingSender = new Ping();
            try
            {
                PingReply reply = pingSender.Send(url);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (PingException)
            {
                // Ping fejla
            }
            return false;
        }

        //LOCAL DATA
        public string pathToMenFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "..", "..", "..", "..", "DAL", "LocalFiles", "men");

        public string pathToWomenFolder = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "..", "..", "..", "..", "DAL", "LocalFiles", "women");

        public async Task LoadDataForProcess() 
        {
            
            if (!ServerStatusBy(API_PING))
            {
                string pathToMenResults = pathToMenFolder + "\\results.json";
                string pathToMenTeams = pathToMenFolder + "\\teams.json";
                string pathToMenMatches = pathToMenFolder + "\\matches.json";
                string pathToMenGroupResults = pathToMenFolder + "\\group_results.json";

                var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToMenResults);
                var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                var data1 = await repo1.GetAllAsync();
                MenResults =  data1.ToList();


                var dataRetrievalStrategyLocal2 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToMenTeams);
                var repo2 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal2);
                var data2 = await repo2.GetAllAsync();
                MenTeamLocal = data2.ToList();

                var dataRetrievalStrategyLocal3 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToMenMatches);
                var repo3 = new DataRepo<Match>(dataRetrievalStrategyLocal3);
                var data3 = await repo3.GetAllAsync();
                MenMatches = data3.ToList();

                var dataRetrievalStrategyLocal4 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToMenGroupResults);
                var repo4 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal4);
                var data4 = await repo4.GetAllAsync();
                MenGroupResultLocal = data4.ToList();
            }
            else
            {
                //API DATA FOR MEN
                var dataRetrievalStrategyAPI1 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_M);
                var dataRetrievalStrategyAPI2 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_M);

                var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyAPI1);
                var repo2 = new DataRepo<Match>(dataRetrievalStrategyAPI2);

                var data1 = await repo1.GetAllAsync();
                var data2 = await repo2.GetAllAsync();

                MenResults = data1.ToList();
                MenMatches = data2.ToList();
            }
            
            if (!ServerStatusBy(API_PING))
            {
                string pathToWomenResults = pathToWomenFolder + "\\results.json";
                string pathToWomenTeams = pathToWomenFolder + "\\teams.json";
                string pathToWomenMatches = pathToWomenFolder + "\\matches.json";
                string pathToWomenGroupResults = pathToWomenFolder + "\\group_results.json";

                var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToWomenResults);
                var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                var data1 = await repo1.GetAllAsync();
                WomenResults = data1.ToList();

                var dataRetrievalStrategyLocal2 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToWomenTeams);
                var repo2 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal2);
                var data2 = await repo2.GetAllAsync();
                WomenTeamLocal = data2.ToList();

                var dataRetrievalStrategyLocal3 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToWomenMatches);
                var repo3 = new DataRepo<Match>(dataRetrievalStrategyLocal3);
                var data3 = await repo3.GetAllAsync();
                WomenMatches = data3.ToList();

                var dataRetrievalStrategyLocal4 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToWomenGroupResults);
                var repo4 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal4);
                var data4 = await repo4.GetAllAsync();
                WomenGroupResultLocal = data4.ToList();
            }
            else
            {
                //API DATA FOR WOMEN
                var dataRetrievalStrategyAPI1 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_W);
                var dataRetrievalStrategyAPI2 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_W);

                var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyAPI1);
                var repo2 = new DataRepo<Match>(dataRetrievalStrategyAPI2);

                var data1 = await repo1.GetAllAsync();
                var data2 = await repo2.GetAllAsync();

                WomenResults = data1.ToList();
                WomenMatches = data2.ToList();
            }
        }
    }
}
