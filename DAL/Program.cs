using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RepoStrategy.Model;
using RepoStrategy.Repo;
using RepoStrategy.Strategy.Factory;

namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    class Program
    {
        public static string StartupPath { get; }

        #region CONSTS
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";
        //**********************************
        private const string TEAMS_RESULTS_M_LOCAL = @"men_teams.json";
        


        #endregion

        static async Task Main(string[] args)
        {
            try
            {
                string userChoice = "api";

                IDataRetrievalStrategyFactory factory = new DataRetrievalStrategyFactory();


                if (userChoice == "api")
                {
                    //IDataRetStrat
                    var dataRetrievalStrategyAPI1 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_M);
                    var dataRetrievalStrategyAPI2 = factory.CreateApiDataRetrievalStrategy<TeamResult>(TEAMS_RESULTS_W);
                    var dataRetrievalStrategyAPI3 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_M);
                    var dataRetrievalStrategyAPI4 = factory.CreateApiDataRetrievalStrategy<Match>(TEAMS_MATCHES_W);


                    //Repo IRepo<T>
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
                    data4.ToList().ForEach(Console.WriteLine);
                    

                }
                else
                {
                    string filePath = Path.Combine(Environment.CurrentDirectory, "LocalFiles", "men", TEAMS_RESULTS_M_LOCAL);
                    var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(filePath);
                    //
                    var repo5 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                    //
                    var data5 = await repo5.GetAllAsync();
                    //
                    data5.ToList().ForEach(Console.WriteLine);
                }
            }
            catch (Exception ex)
            {
                // log the exception
                Console.WriteLine("An error occurred while retrieving data", ex.Message);

                // re-throw the exception so it can be caught by the calling code
                throw;
            }
        }
    }
}