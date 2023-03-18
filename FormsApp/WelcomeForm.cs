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
using DAL.Model;

namespace FormsApp
{
    public partial class WelcomeScreenForm : Form
    {
        private ResourceManager resourceManager = new ResourceManager(typeof(WelcomeScreenForm));
        public DataRetrievalManager dataManager = new DataRetrievalManager();

        //ovo mi je za simuliranje loadanja
        public async Task LoadDataSimulator(IProgress<int> progress)
        {
            for (int i = 0; i <= 35; i++)
            {
                progress.Report(i);
                await Task.Delay(15);
            }
        }

        SortedDictionary<string, SortedSet<Player>> LoadPlayers(IList<Match> matches)
        {
            
            SortedDictionary<string, SortedSet<Player>>? countryPlayers = new SortedDictionary<string, SortedSet<Player>>();
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

        public string? SelectedComboBoxValue
        {
            get
            {
                return cbChooseMF?.SelectedItem?.ToString(); 
            }
        }

        public IList<TeamResult> MenRes
        {
            get
            {
                return  dataManager.MenResults;
            }
        }

        public IList<TeamResult> WomenRes
        {
            get
            {
              return dataManager.WomenResults;
            }
        }

        public  IDictionary<string, SortedSet<Player>>  MenPlayers
        {
            get 
            { 
                return LoadPlayers(dataManager.MenMatches);
            }
        }

        public IDictionary<string, SortedSet<Player>> WomenPlayers
        {
            get
            {
                return LoadPlayers(dataManager.WomenMatches);
            }


        }

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
            IProgress<int> progress = new Progress<int>(value =>
            {
                loadingDataBar.Value = value;
            });
            loadingDataBar.Visible = true;

            await Task.Run(async () =>
            {
                await dataManager.LoadDataForProcess();  //loadam podatke
                await LoadDataSimulator(progress); //simuliram progress,treba mu preko API da slozi oko 1-2 sek

                //sakrij moj loading bar
                loadingDataBar.Visible = false;
            });
            //IMPORTANT
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                pnlRepPlayers favoritesForm = new pnlRepPlayers(resourceManager, this);
                favoritesForm.Show();
        }



    }
}