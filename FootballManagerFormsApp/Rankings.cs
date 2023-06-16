using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using BL.Services;
using DL.Model;
using DL;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Drawing.Printing;

namespace FootballManagerFormsApp
{
    public partial class Rankings : Form
    {
        public string? trackerPath, selectedCountry, printAttendence, printPlayers;
        private ResourceManager? resourceManager;
        MatchesServices? matches;
        public Dictionary<string, Control>? controlsRank;

        List<Match>? matchData;
        List<RankAttendence>? rankAttendence;

        public WelcomeForm? WelcomeForm { get; set; }

        private int selectedLanguageCode;
        private int selectedMF;
        public Rankings()
        {
            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
            resourceManager = new ResourceManager(typeof(Rankings));
            matches =  new MatchesServices();
            matchData = new List<Match>();
            rankAttendence = new List<RankAttendence>();
            controlsRank= new Dictionary<string, Control>();
        }

        private async void Rankings_Load(object sender, EventArgs e)
        {
            if (WelcomeForm is not null)
            {
                controlsRank?.Add("flpAllPLayers", flpAllPLayers);
                lvDisplayAttendenceRankings.View = View.Details;

                selectedLanguageCode = WelcomeForm.SelectedLanguageCode;
                selectedMF = WelcomeForm.SelectedMF;
            }
           

            //Grabi iz fajla
            trackerPath = Path.Combine(Application.StartupPath, Constants.SELECTED_REP_TRACKER);

            try
            {
                if (File.Exists(trackerPath))
                {
                    selectedCountry = File.ReadAllText(trackerPath);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No representation is chosen!");
            }


            switch (selectedLanguageCode)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.en_RankingsLocal", typeof(Favorites).Assembly);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.hrv_RankingsLocal", typeof(Favorites).Assembly);
                    break;
                default:
                    break;
            }

            lbAttendenceRanking.Text = resourceManager.GetString("lbAttendenceRanking");
            lbPlayerRankings.Text = resourceManager.GetString("lbPlayerRankings");
            chLocation.Text = resourceManager.GetString("chLocation");
            chAttendence.Text = resourceManager.GetString("chAttendence");
            chHomeTeam.Text = resourceManager.GetString("chHomeTeam");
            chAwayTeam.Text = resourceManager.GetString("chAwayTeam");
            cbOrderRankingBy.Text = resourceManager.GetString("cbOrderRankingBy");

            btnPrintRankings.Text = resourceManager.GetString("btnPrintRankings");

            await LoadAttendenceRankings(selectedCountry);

            if (selectedMF == 0)
            {
                LoadLocalRankings(controlsRank, 'm', 0);
            }
            else if (selectedMF == 1)
            {
                LoadLocalRankings(controlsRank, 'f', 0);
            }
        }

        public async Task LoadAttendenceRankings(string representation) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("GAMES: ");
            sb.Append("\n");

            if (selectedMF == 0)
            {
                matchData = await matches.GetMaleMatches();
            }
            else if (selectedMF == 1) 
            {
                matchData = await matches.GetFemaleMatches();
            }

            foreach (var m in matchData.Where(m => m.HomeTeamCountry == representation || m.AwayTeamCountry == representation))
            {
                rankAttendence.Add(new RankAttendence() 
                    {
                        Location = m.Location,
                        Attendence = m.Attendance,
                        HomeTeamCountry = m.HomeTeamCountry,
                        AwayTeamCountry = m.AwayTeamCountry
                    }
                );

                sb.Append(m.Location);
                sb.Append(", ");
                sb.Append(m.Attendance);
                sb.Append(", ");
                sb.Append(m.HomeTeamCountry);
                sb.Append(", ");
                sb.Append(m.AwayTeamCountry);
                sb.Append("\n");
            }
            rankAttendence.Sort();
            foreach (RankAttendence rank in rankAttendence)
            {
                string? location = rank.Location;
                string? attendence = rank.Attendence.ToString();
                string? HomeTeam = rank.HomeTeamCountry;
                string? AwayTeam = rank.AwayTeamCountry;
                string[] values = { location, attendence, HomeTeam, AwayTeam };
                ListViewItem item = new ListViewItem(values);

                lvDisplayAttendenceRankings.Items.Add(item);
            }

            printAttendence = sb.ToString();
        }

        public void LoadLocalRankings(Dictionary<string, Control> controlDict, char gender,int selectedIndex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("PLAYERS:");
            sb.Append("\n");
            string? pathToProfileFolder = Path.Combine(Application.StartupPath, "ProfilePictures");
            if (!Directory.Exists(pathToProfileFolder))
            {
                Directory.CreateDirectory(pathToProfileFolder);
            }

            string? cPath = null;
            gender.ToString().ToLower();
            if (gender == 'm')
            {
                cPath = Path.Combine(Application.StartupPath, Constants.FAVORITES_FORM_M);
            }
            else if (gender == 'f')
            {
                cPath = Path.Combine(Application.StartupPath, Constants.FAVORITES_FORM_F);
            }

            if (!File.Exists(cPath))
            {
                using (File.Create(cPath)) { };
            }

            if (File.Exists(cPath))
            {
                string? jsonString = File.ReadAllText(cPath);
                var controlDataList = JsonConvert.DeserializeObject<List<JToken>>(jsonString);

                if (controlDataList != null)
                {
                    //int totalItems = controlDataList.Count;
                    //int processedItems = 0;
                    foreach (JToken data in controlDataList)
                    {
                        foreach (KeyValuePair<string, Control> kvp in controlDict)
                        {
                            if (kvp.Value is FlowLayoutPanel)
                            {
                                if (data["LayoutPanelName"] != null && kvp.Value.Name == data["LayoutPanelName"].ToString())
                                {
                                    bool itemExists = false;
                                    foreach (PlayerRankingControl playerControl in ((FlowLayoutPanel)kvp.Value).Controls)
                                    {
                                        if (playerControl.Name == data["PlayerName"].ToString())
                                        {
                                            itemExists = true;
                                            break;
                                        }
                                    }
                                    if (!itemExists)
                                    {
                                        string? playerName = data["PlayerName"].ToString();
                                        string? playerGoals = data["Goals"].ToString();
                                        string? playerYellowCards = data["YellowCards"].ToString();
                                        string? playerAppereances = data["Appearances"].ToString();
                                        Image playerImage = Base64ToImage(data["PlayerImage"].ToString());

                                        sb.Append(playerName);
                                        sb.Append(", ");
                                        sb.Append("Goals: ");
                                        sb.Append(playerGoals);
                                        sb.Append(", ");
                                        sb.Append("Yellow cards: ");
                                        sb.Append(playerYellowCards);
                                        sb.Append(", ");
                                        sb.Append("Appereances: ");
                                        sb.Append(playerAppereances);
                                        sb.Append("\n");

                                        PlayerRankingControl newControl = new PlayerRankingControl();
                                        newControl.Name = $"PlayerRankingControl_{Guid.NewGuid()}";

                                        newControl.PlayerName = playerName;
                                        newControl.Goals = playerGoals;
                                        newControl.YellowCards = playerYellowCards;
                                        newControl.Appereance = playerAppereances;
                                        newControl.ProfilePicture = playerImage;

                                        List<PlayerRankingControl> sortedControls = new List<PlayerRankingControl>();
                                        sortedControls.AddRange(((FlowLayoutPanel)kvp.Value).Controls.OfType<PlayerRankingControl>());
                                        sortedControls.Add(newControl);

                                        ((FlowLayoutPanel)kvp.Value).Controls.Clear();

                                        foreach (PlayerRankingControl sortedControl in sortedControls)
                                        {
                                            ((FlowLayoutPanel)kvp.Value).Controls.Add(sortedControl);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                printPlayers = sb.ToString();
            }
        }

       
        public List<PlayerRankingControl> LoadLocalRankingsList(Dictionary<string, Control> controlDict, char gender)
        {
            StringBuilder sb = new StringBuilder();
            List<PlayerRankingControl> returnControls = new List<PlayerRankingControl>();

            sb.Append("PLAYERS:");
            sb.Append("\n");
            string pathToProfileFolder = Path.Combine(Application.StartupPath, "ProfilePictures");
            if (!Directory.Exists(pathToProfileFolder))
            {
                Directory.CreateDirectory(pathToProfileFolder);
            }

            string? cPath = null;
            gender.ToString().ToLower();
            if (gender == 'm')
            {
                cPath = Path.Combine(Application.StartupPath, Constants.FAVORITES_FORM_M);
            }
            else if (gender == 'f')
            {
                cPath = Path.Combine(Application.StartupPath, Constants.FAVORITES_FORM_F);
            }

            if (!File.Exists(cPath))
            {
                using (File.Create(cPath)) { };
            }

            if (File.Exists(cPath))
            {
                string jsonString = File.ReadAllText(cPath);
                var controlDataList = JsonConvert.DeserializeObject<List<JToken>>(jsonString);

                if (controlDataList != null)
                {
                    //int totalItems = controlDataList.Count;
                    //int processedItems = 0;
                    foreach (JToken data in controlDataList)
                    {
                        foreach (KeyValuePair<string, Control> kvp in controlDict)
                        {
                            if (kvp.Value is FlowLayoutPanel)
                            {
                                if (data["LayoutPanelName"] != null && kvp.Value.Name == data["LayoutPanelName"].ToString())
                                {
                                    bool itemExists = false;
                                    foreach (PlayerRankingControl playerControl in ((FlowLayoutPanel)kvp.Value).Controls)
                                    {
                                        if (playerControl.Name == data["PlayerName"].ToString())
                                        {
                                            itemExists = true;
                                            break;
                                        }
                                    }
                                    if (!itemExists)
                                    {
                                        string? playerName = data["PlayerName"].ToString();
                                        string? playerGoals = data["Goals"].ToString();
                                        string? playerYellowCards = data["YellowCards"].ToString();
                                        string? playerAppereances = data["Appearances"].ToString();
                                        Image playerImage = Base64ToImage(data["PlayerImage"].ToString());

                                        sb.Append(playerName);
                                        sb.Append(", ");
                                        sb.Append("Goals: ");
                                        sb.Append(playerGoals);
                                        sb.Append(", ");
                                        sb.Append("Yellow cards: ");
                                        sb.Append(playerYellowCards);
                                        sb.Append(", ");
                                        sb.Append("Appereances: ");
                                        sb.Append(playerAppereances);
                                        sb.Append("\n");

                                        PlayerRankingControl newControl = new PlayerRankingControl();
                                        newControl.Name = $"PlayerRankingControl_{Guid.NewGuid()}";

                                        newControl.PlayerName = playerName;
                                        newControl.Goals = playerGoals;
                                        newControl.YellowCards = playerYellowCards;
                                        newControl.Appereance = playerAppereances;
                                        newControl.ProfilePicture = playerImage;
                                        returnControls.AddRange(((FlowLayoutPanel)kvp.Value).Controls.OfType<PlayerRankingControl>());
                                        returnControls.Add(newControl);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            printPlayers = sb.ToString();
            return returnControls;
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
        }
        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private void cbOrderRankingBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpAllPLayers.Controls.Clear();

            List<PlayerRankingControl> flpControls = new List<PlayerRankingControl>();
            if (selectedMF == 0)
            {
                flpControls = LoadLocalRankingsList(controlsRank, 'm');
            }
            else if (selectedMF == 1)
            {
                flpControls = LoadLocalRankingsList(controlsRank, 'f');
            }

            switch (cbOrderRankingBy.SelectedIndex)
            {
                case -1:
                case 0:
                    flpControls.Sort((control1, control2) =>
                    {
                        int goals1 = int.Parse(control1.Goals);
                        int goals2 = int.Parse(control2.Goals);
                        return goals2.CompareTo(goals1);
                    });
                    break;
                case 1:
                    flpControls.Sort((control1, control2) =>
                    {
                        int yellowCards1 = int.Parse(control1.YellowCards);
                        int yellowCards2 = int.Parse(control2.YellowCards);
                        return yellowCards2.CompareTo(yellowCards1);
                    });
                    break;
                case 2:
                    flpControls.Sort((control1, control2) =>
                    {
                        int appereances1 = int.Parse(control1.Appereance);
                        int appereances2 = int.Parse(control2.Appereance);
                        return appereances2.CompareTo(appereances1);
                    });
                    break;
                default:
                    break;
            }

            //MessageBox.Show(flpControls.Count.ToString());

            foreach (PlayerRankingControl control in flpControls)
            {
                flpAllPLayers.Controls.Add(control); 
            }

        }

        private void bwOrderRankings_DoWork(object sender, DoWorkEventArgs e)
        {
           //Tuple<int, char> arguments = e.Argument as Tuple<int, char>;
           //int selectedIndex = arguments.Item1;
           //char selectedMF = arguments.Item2;
           //
           //if (selectedMF == 0)
           //{
           //    LoadLocalRankings(controlsRank, selectedMF, selectedIndex);
           //}
           //else if (selectedMF == 1)
           //{
           //    LoadLocalRankings(controlsRank, selectedMF, selectedIndex);
           //}

        }

        private void bwOrderRankings_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // lbProgress.Text = e?.UserState.ToString();
        }

        private void bwOrderRankings_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Error != null)
            //{
            //    MessageBox.Show(e.Error.Message);
            //}
            //else
            //{
            //    HideLoadingLabel();
            //
            //    flpAllPLayers.Controls.Clear();
            //
            //    if (selectedMF == 0)
            //    {
            //        LoadLocalRankings(controlsRank, 'm', cbOrderRankingBy.SelectedIndex);
            //    }
            //    else if (selectedMF == 1)
            //    {
            //        LoadLocalRankings(controlsRank, 'f', cbOrderRankingBy.SelectedIndex);
            //    }
            //}
        }

        private void ShowLoadingLabel()
        {
            lbProgress.Show();
            lbProgress.Text = "Loading...";
        }

        private void HideLoadingLabel()
        {
            lbProgress.Text = "Completed...";
            lbProgress.Hide();
        }

        private void pdPrintRankings_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringBuilder sbPrint = new StringBuilder();
            sbPrint.Append(printAttendence);
            sbPrint.Append("\n\n\n\n");
            sbPrint.Append(printPlayers);
            string content = sbPrint.ToString();
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            RectangleF bounds = e.MarginBounds;

            e.Graphics.DrawString(content, font, brush, bounds);
            e.HasMorePages = false;
        }

        private void btnPrintRankings_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdPrintRankings;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pdPrintRankings.Print();
            }

        }
    }
}
