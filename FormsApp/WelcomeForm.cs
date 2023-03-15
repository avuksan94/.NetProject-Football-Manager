using System.Threading;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Net.NetworkInformation;
using RepoStrategy.Model;
using RepoStrategy.Repo;
using RepoStrategy.Strategy.Factory;

namespace FormsApp
{
    public partial class WelcomeScreenForm : Form
    {
        private ResourceManager resourceManager = new ResourceManager(typeof(WelcomeScreenForm));
        public bool apiAvailability = ServerStatusBy(API_PING);

        SortedDictionary<string, SortedSet<string>> LoadPlayers(IList<Match> matches, IList<Match> matchesLocal)
        {
            SortedDictionary<string, SortedSet<string>> countryPlayers = new SortedDictionary<string, SortedSet<string>>();
            if (apiAvailability)
            {
                foreach (var item in matches.ToList())
                {

                    string countryName = item.HomeTeamStatistics.Country;
                    SortedSet<string> players;
                    if (!countryPlayers.TryGetValue(countryName, out players))
                    {
                        players = new SortedSet<string>();
                        countryPlayers.Add(countryName, players);
                    }

                    item.HomeTeamStatistics.StartingEleven
                        .ToList()
                        .ForEach(c => players.Add(c.Name));

                    item.HomeTeamStatistics.Substitutes
                        .ToList()
                        .ForEach(c => players.Add(c.Name));
                }
                return countryPlayers;
            }
            else if (!apiAvailability)
            {
                foreach (var item in matchesLocal.ToList())
                {

                    string countryName = item.HomeTeamStatistics.Country;
                    SortedSet<string> players;
                    if (!countryPlayers.TryGetValue(countryName, out players))
                    {
                        players = new SortedSet<string>();
                        countryPlayers.Add(countryName, players);
                    }

                    item.HomeTeamStatistics.StartingEleven
                        .ToList()
                        .ForEach(c => players.Add(c.Name));

                    item.HomeTeamStatistics.Substitutes
                        .ToList()
                        .ForEach(c => players.Add(c.Name));

                }
                return countryPlayers;
            }
            return new SortedDictionary<string, SortedSet<string>>();
        }

        public string SelectedComboBoxValue
        {
            get
            {
                return cbChooseMF.SelectedItem.ToString(); // assuming your ComboBox is named "comboBox1"
            }
        }

        public IList<TeamResult> MenRes
        {
            get
            {
                if(cbChooseMF.SelectedIndex == 0 && apiAvailability == true)
                {
                    return menResults;
                    
                }
                return menResultsLocal;
            }
        }

        public IList<TeamResult> WomenRes
        {
            get
            {
                if (cbChooseMF.SelectedIndex == 1 && apiAvailability == true)
                {
                    return womenResults;

                }
                return womenResultsLocal;
            }
        }

        public IDictionary<string, SortedSet<string>>  MenPlayers
        {
            get 
            { 
                return LoadPlayers(menMatches, menMatchLocal);
            }
        }

        public IDictionary<string, SortedSet<string>> WomenPlayers
        {
            get
            {
                return LoadPlayers(womenMatches, womenMatchLocal);
            }


        }

        //Liste za API podatke
        public IList<TeamResult> menResults = new List<TeamResult>();
        public IList<Match> menMatches = new List<Match>();
        public IList<TeamResult> womenResults = new List<TeamResult>();
        public IList<Match> womenMatches = new List<Match>();

        //Liste za lokalne podatke
        public IList<TeamResult> menResultsLocal = new List<TeamResult>();
        public IList<TeamLocal> menTeamLocal = new List<TeamLocal>();
        public IList<Match> menMatchLocal = new List<Match>();
        public IList<GroupResult> menGroupResultLocal = new List<GroupResult>();

        public IList<TeamResult> womenResultsLocal = new List<TeamResult>();
        public IList<TeamLocal> womenTeamLocal = new List<TeamLocal>();
        public IList<Match> womenMatchLocal = new List<Match>();
        public IList<GroupResult> womenGroupResultLocal = new List<GroupResult>();

        //CONSTS
        public const string API_PING = "worldcup-vua.nullbit.hr";
        public const string TEAMS_RESULTS_M = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string TEAMS_RESULTS_W = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string TEAMS_MATCHES_M = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string TEAMS_MATCHES_W = "https://worldcup-vua.nullbit.hr/women/matches";

        //LOCAL DATA
        public string pathToMenFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "..", "..", "..", "..", "DAL", "LocalFiles", "men");

        public string pathToWomenFolder = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "..", "..", "..", "..", "DAL", "LocalFiles", "women");


        public WelcomeScreenForm()
        {
            InitializeComponent();
            
            
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void cbChooseLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbChooseLanguage.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FormsApp.en_local", typeof(WelcomeScreenForm).Assembly);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FormsApp.hrv_local", typeof(WelcomeScreenForm).Assembly);
                    break;
                default:
                    break;
            }

            lbChooseYourLanguage.Text = resourceManager.GetString("lbChooseYourLanguage");
            lbChooseMF.Text = resourceManager.GetString("lbChooseMF");
            cbChooseLanguage.Text = resourceManager.GetString("cbChooseLanguage");

            cbChooseMF.Text = resourceManager.GetString("cbChooseMF");
            cbChooseMF.Items[0] = resourceManager.GetString("lbChooseMFIndex0");
            cbChooseMF.Items[1] = resourceManager.GetString("lbChooseMFIndex1");

            btnNext.Text = resourceManager.GetString("btnNext");

        }

        private async void cbChooseMF_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataRetrievalStrategyFactory factory = new DataRetrievalStrategyFactory();
            switch (cbChooseMF.SelectedIndex)
            {
                case 0:
                    if (!ServerStatusBy("worldcup-vua.nullbit.hr"))
                    {
                        string pathToMenResults = pathToMenFolder + "\\results.json";
                        string pathToMenTeams = pathToMenFolder + "\\teams.json";
                        string pathToMenMatches = pathToMenFolder + "\\matches.json";
                        string pathToMenGroupResults = pathToMenFolder + "\\group_results.json";

                        var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToMenResults);
                        var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                        var data1 = await repo1.GetAllAsync();
                        menResultsLocal = data1.ToList();
                        

                        var dataRetrievalStrategyLocal2 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToMenTeams);
                        var repo2 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal2);
                        var data2 = await repo2.GetAllAsync();
                        menTeamLocal = data2.ToList();

                        var dataRetrievalStrategyLocal3 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToMenMatches);
                        var repo3 = new DataRepo<Match>(dataRetrievalStrategyLocal3);
                        var data3 = await repo3.GetAllAsync();
                        menMatchLocal= data3.ToList();

                        var dataRetrievalStrategyLocal4 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToMenGroupResults);
                        var repo4 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal4);
                        var data4 = await repo4.GetAllAsync();
                        menGroupResultLocal= data4.ToList();
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

                        menResults = data1.ToList();
                        menMatches = data2.ToList();
                    }
                    break;
                case 1:
                    if (!ServerStatusBy("worldcup-vua.nullbit.hr"))
                    {
                        string pathToWomenResults = pathToWomenFolder + "\\results.json";
                        string pathToWomenTeams = pathToWomenFolder + "\\teams.json";
                        string pathToWomenMatches = pathToWomenFolder + "\\matches.json";
                        string pathToWomenGroupResults = pathToWomenFolder + "\\group_results.json";

                        var dataRetrievalStrategyLocal1 = factory.CreateLocalDataRetrievalStrategy<TeamResult>(pathToWomenResults);
                        var repo1 = new DataRepo<TeamResult>(dataRetrievalStrategyLocal1);
                        var data1 = await repo1.GetAllAsync();
                        womenResultsLocal = data1.ToList();

                        var dataRetrievalStrategyLocal2 = factory.CreateLocalDataRetrievalStrategy<TeamLocal>(pathToWomenTeams);
                        var repo2 = new DataRepo<TeamLocal>(dataRetrievalStrategyLocal2);
                        var data2 = await repo2.GetAllAsync();
                        womenTeamLocal = data2.ToList();

                        var dataRetrievalStrategyLocal3 = factory.CreateLocalDataRetrievalStrategy<Match>(pathToWomenMatches);
                        var repo3 = new DataRepo<Match>(dataRetrievalStrategyLocal3);
                        var data3 = await repo3.GetAllAsync();
                        womenMatchLocal = data3.ToList();

                        var dataRetrievalStrategyLocal4 = factory.CreateLocalDataRetrievalStrategy<GroupResult>(pathToWomenGroupResults);
                        var repo4 = new DataRepo<GroupResult>(dataRetrievalStrategyLocal4);
                        var data4 = await repo4.GetAllAsync();
                        womenGroupResultLocal = data4.ToList();
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

                        womenResults = data1.ToList();
                        womenMatches = data2.ToList();
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlRepPlayers favoritesForm = new pnlRepPlayers(resourceManager,this);
            favoritesForm.Show();
        }

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

    }
}