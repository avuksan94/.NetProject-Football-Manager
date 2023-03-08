using RepoStrategy.Model;
using RepoStrategy.Repo;
using RepoStrategy.Strategy.Factory;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    class Program
    {

        #region CONSTS
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";

        #endregion

        static async Task Main(string[] args)
        {
            try
            {
                string userChoice = "local";

                IDataRetrievalStrategyFactory factory = new DataRetrievalStrategyFactory();


                if (userChoice == "api")
                {
                    //IDataRetStrat
                    var dataRetrievalStrategyAPI1 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_M);
                    var dataRetrievalStrategyAPI2 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_W);
                    var dataRetrievalStrategyAPI3 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_M);
                    var dataRetrievalStrategyAPI4 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_W);


                    // IRepo<T>
                    var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyAPI1);
                    var repo2 = new DataRepo<TeamResult>(dataRetrievalStrategyAPI2);
                    var repo3 = new DataRepo<Match>(dataRetrievalStrategyAPI3);
                    var repo4 = new DataRepo<Match>(dataRetrievalStrategyAPI4);

                    //Data su IEnumerables<T>
                    var data1 = await repo1.GetAllAsync();
                    var data2 = await repo2.GetAllAsync();
                    var data3 = await repo3.GetAllAsync();
                    var data4 = await repo4.GetAllAsync();

                    //Print
                    data1.ToList().ForEach(Console.WriteLine);
                    data2.ToList().ForEach(Console.WriteLine);
                    data3.ToList().ForEach(Console.WriteLine);

                    foreach (var item in data4.ToList())
                    {
                        Console.WriteLine(item.WinnerCode);
                    }

                }
                else
                {
                    string pathToMenFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "..", "..", "..", "DAL", "LocalFiles", "men");

                    string pathToWomenFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "..", "..", "..", "DAL", "LocalFiles", "women");

                    string pathToMenResults = pathToMenFolder + "\\results.json";
                    string pathToMenTeams = pathToMenFolder + "\\teams.json";
                    string pathToMenMatches = pathToMenFolder + "\\matches.json";
                    string pathToMenGroupResults = pathToMenFolder + "\\group_results.json";

                    string pathToWomenResults = pathToWomenFolder + "\\results.json";
                    string pathToWomenTeams = pathToWomenFolder + "\\teams.json";
                    string pathToWomenMatches = pathToWomenFolder + "\\matches.json";
                    string pathToWomenGroupResults = pathToWomenFolder + "\\group_results.json";


                    var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToMenResults);
                    var repo5 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                    var data5 = await repo5.GetAllAsync();
                    data5.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal2 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToMenTeams);
                    var repo6 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal2);
                    var data6 = await repo6.GetAllAsync();
                    data6.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal3 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToMenMatches);
                    var repo7 = new DataRepo<Match>(dataRetrievalStrategyLocal3);
                    var data7 = await repo7.GetAllAsync();
                    data7.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal4 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToMenGroupResults);
                    var repo8 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal4);
                    var data8 = await repo8.GetAllAsync();
                    foreach (var item in data8)
                    {
                        Console.WriteLine(item.Letter);
                    }

                    var dataRetrievalStrategyLocal5 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToWomenResults);
                    var repo9 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal5);
                    var data9 = await repo9.GetAllAsync();
                    data9.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal6 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToWomenTeams);
                    var repo10 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal6);
                    var data10 = await repo10.GetAllAsync();
                    data10.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal7 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToWomenMatches);
                    var repo11 = new DataRepo<Match>(dataRetrievalStrategyLocal7);
                    var data11 = await repo11.GetAllAsync();
                    data11.ToList().ForEach(Console.WriteLine);

                    var dataRetrievalStrategyLocal8 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToWomenGroupResults);
                    var repo12 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal8);
                    var data12 = await repo12.GetAllAsync();
                    foreach (var item in data12)
                    {
                        Console.WriteLine(item.Letter);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving data", ex.Message);

                throw;
            }
        }
    }
}