using RepoStrategy.Enums;
using RepoStrategy.Model;
using RepoStrategy.Repo;
using RepoStrategy.Strategy.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Model
{
    public class DataRetrievalManager
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios

        private readonly IDataRetrievalStrategyFactory factory;
        public DataRetrievalManager() => factory = new DataRetrievalStrategyFactory();

        //SAVE Lokalnih fajlova
    
        public const string COMBO_BOXES = @"ComboBoxChoices.txt";
        public const string LIST_BOXES = @"ListBoxItems.txt";

        public const string COMBO_BOXES_FAVORITES = @"ComboBoxChoicesFavorites.txt";
        public const string LIST_BOXES_FAVORITES = @"ListBoxItemsFavorites.txt";

        public const string API_PING = "worldcup-vua.nullbit.hr";
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";

        public const char DELIMITER = '|';
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

        public async Task SaveLocal(Dictionary<string, Control> controlDict)
        {
            string cbPath = Path.Combine(Application.StartupPath, COMBO_BOXES);
            string lbPath = Path.Combine(Application.StartupPath, LIST_BOXES);

            if (!File.Exists(cbPath))
            {
                File.Create(cbPath);
            }
            if (!File.Exists(lbPath))
            {
                File.Create(lbPath);
            }

            StreamWriter comboBoxWriter = new StreamWriter(cbPath);
            StreamWriter listBoxWriter = new StreamWriter(lbPath);

            foreach (KeyValuePair<string, Control> kvp in controlDict)
            {
                if (kvp.Value is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)kvp.Value;
                    await comboBoxWriter.WriteAsync($"{kvp.Key}|{comboBox.SelectedIndex.ToString()}{Environment.NewLine}");
                }
                else if (kvp.Value is ListBox)
                {
                    ListBox listBox = (ListBox)kvp.Value;
                    foreach (var item in listBox.Items)
                    {
                        await listBoxWriter.WriteAsync($"{kvp.Key}|{item.ToString()}{Environment.NewLine}");
                    }
                }
            }
            await comboBoxWriter.FlushAsync();
            await listBoxWriter.FlushAsync();

            comboBoxWriter.Close();
            listBoxWriter.Close();
        }

        public async Task SaveLocalFavorites(Dictionary<string, Control> controlDict)
        {
            string cbPath = Path.Combine(Application.StartupPath, COMBO_BOXES_FAVORITES);
            string lbPath = Path.Combine(Application.StartupPath, LIST_BOXES_FAVORITES);

            if (!File.Exists(cbPath))
            {
                File.Create(cbPath);
            }
            else if(File.Exists(cbPath))
            {
                File.WriteAllText(cbPath, string.Empty);
            }

            if (!File.Exists(lbPath))
            {
                File.Create(lbPath);
            }
            else if (File.Exists(lbPath))
            {
                File.WriteAllText(lbPath, string.Empty);
            }

            StreamWriter comboBoxWriter = new StreamWriter(cbPath);
            StreamWriter listBoxWriter = new StreamWriter(lbPath);

            foreach (KeyValuePair<string, Control> kvp in controlDict)
            {
                if (kvp.Value is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)kvp.Value;
                    await comboBoxWriter.WriteAsync($"{kvp.Key}|{comboBox.SelectedIndex.ToString()}{Environment.NewLine}");
                }
                else if (kvp.Value is ListBox)
                {
                    ListBox listBox = (ListBox)kvp.Value;
                    foreach (var item in listBox.Items)
                    {
                        await listBoxWriter.WriteAsync($"{kvp.Key}|{item.ToString()}{Environment.NewLine}");
                    }
                }
            }
            await comboBoxWriter.FlushAsync();
            await listBoxWriter.FlushAsync();

            comboBoxWriter.Close();
            listBoxWriter.Close();
        }

        //Separitati sve za loadanje pojedinih elemenata u zasebne klase koje primaju 
        //Controle kao parametar i onda se implemetira sve u LoadLocal

        public void LoadLocal(Dictionary<string, Control> controlDict)
        {
            string cbPath = Path.Combine(Application.StartupPath, COMBO_BOXES);
            string lbPath = Path.Combine(Application.StartupPath, LIST_BOXES);

            if (!File.Exists(cbPath))
            {
                File.Create(cbPath);
            }
            if (!File.Exists(lbPath))
            {
                File.Create(lbPath);
            }

            using (StreamReader comboBoxReader = new StreamReader(cbPath))
            {
                string line;
                while ((line = comboBoxReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    //MessageBox.Show(data[1]);
                    foreach (KeyValuePair<string, Control> kvp in controlDict)
                    {
                        if (kvp.Value is ComboBox)
                        {
                            if (kvp.Value.Name == data[0])
                            {
                                int selectedInd = int.Parse(data[1]);
                                ComboBox comboBox = (ComboBox)kvp.Value;
                                comboBox.SelectedIndex = selectedInd;
                            }
                        }
                    }
                }
                comboBoxReader.Close();
            }

            using (StreamReader listBoxReader = new StreamReader(lbPath))
            {
                string line;
                while ((line = listBoxReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    foreach (KeyValuePair<string, Control> kvp in controlDict)
                    {
                        if (kvp.Value is ListBox)
                        {
                            if (kvp.Value.Name == data[0])
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(data[1]);
                                sb.Append(" ");
                                sb.Append(data[2]);
                                sb.Append(" ");
                                sb.Append(data[3]);
                                sb.Append(" ");
                                sb.Append(data[4]);
                                string text = sb.ToString();
                                ListBox listBox = (ListBox)kvp.Value;
                                listBox.Items.Add(text);

                            }
                        }
                    }
                }
                listBoxReader.Close();
            }
        }

        public void LoadLocalFavorites(Dictionary<string, Control> controlDict)
        {
            string cbPath = Path.Combine(Application.StartupPath, COMBO_BOXES_FAVORITES);
            string lbPath = Path.Combine(Application.StartupPath, LIST_BOXES_FAVORITES);

            if (!File.Exists(cbPath))
            {
                File.Create(cbPath);
            }
            if (!File.Exists(lbPath))
            {
                File.Create(lbPath);
            }
            else if (File.Exists(lbPath))
            {
                using (StreamReader listBoxReader = new StreamReader(lbPath))
                {
                    string line;
                    while ((line = listBoxReader.ReadLine()) != null)
                    {
                        string[] data = line.Split(DELIMITER);
                        foreach (KeyValuePair<string, Control> kvp in controlDict)
                        {
                            if (kvp.Value is ListBox)
                            {
                                if (kvp.Value.Name == data[0])
                                {
                                    Player p = new Player()
                                    {
                                        Name = data[1],
                                        ShirtNumber = int.Parse(data[2]),
                                        Position = (Position)Enum.Parse(typeof(Position), data[3]),
                                        Captain = bool.Parse(data[4])

                                    };
                                    ListBox listBox = (ListBox)kvp.Value;
                                    listBox.Items.Add(p);
                                    break;

                                }
                            }
                        }
                    }
                    listBoxReader.Close();
                }
            }

            using (StreamReader comboBoxReader = new StreamReader(cbPath))
            {
                string line;
                while ((line = comboBoxReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    //MessageBox.Show(data[1]);
                    foreach (KeyValuePair<string, Control> kvp in controlDict)
                    {
                        if (kvp.Value is ComboBox)
                        {
                            if (kvp.Value.Name == data[0])
                            {
                                int selectedInd = int.Parse(data[1]);
                                ComboBox comboBox = (ComboBox)kvp.Value;
                                comboBox.SelectedIndex = selectedInd;
                            }
                        }
                    }
                }
                comboBoxReader.Close();
            }

           
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
                           }));
              }
              
          
            return countryPlayers;
        }
    }
}
