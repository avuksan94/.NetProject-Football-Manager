using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using DL.Model;
using BL.Services;
using MyWorker;
using DL;
using System.Collections.Immutable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using DL.Enums;
using System.Text.RegularExpressions;

namespace FootballManagerFormsApp
{
    public partial class Favorites : Form
    {
        public const char DELIMITER = '|';
        public WelcomeForm? WelcomeForm { get; set; }
        private ResourceManager? resourceManager;
        public Dictionary<string, Control> controlsFav;

        private TeamResultService? teamResultAPI;
        private MatchesServices? matchService;

        public IDictionary<string, SortedSet<Player>> menPlayers;
        public IDictionary<string, SortedSet<Player>> womenPlayers;

        IList<TeamResult>? menSortedAPIList;
        IList<TeamResult>? womenSortedAPIList;

        IList<DL.Model.Match>? menMatches;
        IList<DL.Model.Match>? womenMatches;

        private int selectedLanguageCode;
        private int? selectedMF;

        int counterLoaded = 0;

        public Favorites()
        {
            resourceManager = new ResourceManager(typeof(Favorites));
            controlsFav = new Dictionary<string, Control>();
            matchService = new MatchesServices();

            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
        }

        //Forsanje reloada podataka 
        public async void RefreshForm()
        {
            //sejvaj musku repku 0 == male
            if (selectedMF == 0)
            {
                SaveLocalFavorites(controlsFav, 'm');
            } //sejvaj zensku repku 1 == female
            else if (selectedMF == 1)
            {
                SaveLocalFavorites(controlsFav, 'f');
            }
           
            await LoadCbRepresentations();
            await LoadPlayers();
        }

       

        private async void Favorites_Load(object sender, EventArgs e)
        {
            if (WelcomeForm is not null)
            {
                selectedLanguageCode = WelcomeForm.SelectedLanguageCode;
                selectedMF = WelcomeForm.SelectedMF;
                controlsFav.Add("cbChooseRep", cbChooseRep);
                controlsFav.Add("flpAllPLayers", flpAllPLayers);
                controlsFav.Add("flpFavoritePlayers", flpFavoritePlayers);
            }
            

            await LoadCbRepresentations();
            await LoadPlayers();
            
            switch (selectedLanguageCode)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US"); 
                     resourceManager = new ResourceManager("FootballManagerFormsApp.en_FavoritesLocal", typeof(Favorites).Assembly);
                     break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                     resourceManager = new ResourceManager("FootballManagerFormsApp.hrv_FavoritesLocal", typeof(Favorites).Assembly);
                     break;
                default:
                    break;
            }

            lbChooseRep.Text = resourceManager?.GetString("lbChooseRep");
            lbFavoritePlayers.Text = resourceManager?.GetString("lbFavoritePlayers");

            

        }

        private async void cbChooseRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadPlayers();
            flpFavoritePlayers.Controls.Clear();
        }

        //ovisno o korisnickom odabiru o m/f reprez prikazi repke
        private void LoadTeamResults(List<TeamResult> menSortedList, List<TeamResult> womenSortedList)
        {
            if (selectedMF == 0)
            {
                LoadTeamResultProcedure(menSortedList);
            }
            else if (selectedMF == 1)
            {
                LoadTeamResultProcedure(womenSortedList);
            }
        }

        //Loadanje drzava za prikaz unutar comboBoxa
        private void LoadTeamResultProcedure(List<TeamResult> sortedList)
        {
            cbChooseRep.Items.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (TeamResult item in sortedList)
            {
                sb.Clear();
                sb.Append(item.Country);
                sb.Append(" ");
                sb.Append(item.FifaCode);
                cbChooseRep.Items.Add(sb.ToString());
            }
            cbChooseRep.Refresh();
        }

        public async Task LoadPlayers()
        {
            if (counterLoaded != 1)
            { //kada igrac ima nogometnu loptu sa desne strane znaci da je reprezentacija promijenjena :), podaci koji su lokalno povuceni nemaju lopticu
                IProgress<int> progress = new Progress<int>(value =>
                {
                    progBar1.Value = value;
                });

                for (int i = 0; i <= 100; i++)
                {
                    progress.Report(i);
                }

                matchService = new MatchesServices();

                menMatches = await matchService.GetMaleMatches();
                womenMatches = await matchService.GetFemaleMatches();

                menPlayers = matchService.LoadPlayers(menMatches);
                womenPlayers = matchService.LoadPlayers(womenMatches);
                counterLoaded++;


                if (cbChooseRep.SelectedIndex >= 0)
                {
                    progBar1.Visible = true;
                    flpAllPLayers.Controls.Clear();
                    LoadPlayerControl();
                }
                else
                {
                    progBar1.Visible = true;
                    if (selectedMF == 0)
                    {
                        LoadLocalFavorites(controlsFav, 'm');
                    }
                    else if (selectedMF == 1)
                    {
                        LoadLocalFavorites(controlsFav, 'f');
                    }
                    counterLoaded++;
                }
                    progBar1.Hide();
            }
        }

        public async Task LoadCbRepresentations()
        {

            teamResultAPI = new TeamResultService();

            menSortedAPIList = await teamResultAPI.GetMaleResults();

            womenSortedAPIList = await teamResultAPI.GetFemaleResults();

            LoadTeamResults(menSortedAPIList.ToList(), womenSortedAPIList.ToList());
     
            cbChooseRep.Enabled = true;
        }


        //Ubacivanje player podataka u flpAllPlayers
        private void LoadPlayerControl()
        {
            string? selectedItem = cbChooseRep?.SelectedItem?.ToString();
            string? selectedCountry = selectedItem?.Split(' ')[0];

            //OVO JE ZA RANKING
            string? trackerPath;
            trackerPath = Path.Combine(Application.StartupPath, Constants.SELECTED_REP_TRACKER);
            

            if (!File.Exists(trackerPath))
            {
                using (File.Create(trackerPath)) { };
            }
            
            if (File.Exists(trackerPath))
            {
                File.WriteAllText(trackerPath, string.Empty);
                File.WriteAllText(trackerPath, selectedCountry);
               
            }

            string? defaultFolder = Path.Combine(Constants.pathToImagesFolder);
            string? profileFolder = Path.Combine(Application.StartupPath, "ProfilePictures");

            if (!Directory.Exists(defaultFolder))
            {
                Directory.CreateDirectory(defaultFolder);
            }

            if (!Directory.Exists(profileFolder))
            {
                Directory.CreateDirectory(profileFolder);
            }

            if (selectedMF == 0)
            {
                foreach (KeyValuePair<string, SortedSet<Player>> pair in menPlayers)
                {
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {

                            string? playerName = player.Name;
                            string? playerShirtNum = player.ShirtNumber.ToString();
                            string? playerPosition = player.Position.ToString();
                            string? playerCaptain = player.Captain ? "Yes" : "No";

                            Image? playerImage = null;
                            string? profileImagePath = Path.Combine(profileFolder, $"{playerName}.png");
                            string? imagePath = File.Exists(profileImagePath) ? profileImagePath : Path.Combine(defaultFolder, $"MaleFBPlayer.png");
                            if (File.Exists(imagePath))
                            {
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    playerImage = Image.FromStream(fs);
                                    fs.Close();
                                }
                                playerImage = playerImage.GetThumbnailImage(92, 89, null, IntPtr.Zero);
                            }

                            PlayerControl playerControl = new PlayerControl();
                            playerControl.Name = $"PlayerControl_{Guid.NewGuid()}";
                            playerControl.Favorites = this;
                            playerControl.SetPlayerData(playerImage, playerName, playerPosition, playerShirtNum, playerCaptain);

                            flpAllPLayers.Controls.Add(playerControl);
                        }
                    }
                }
            }
            else if (selectedMF == 1)
            {
                foreach (KeyValuePair<string, SortedSet<Player>> pair in womenPlayers)
                {
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {
                            string? playerName = player.Name;
                            string? playerShirtNum = player.ShirtNumber.ToString();
                            string? playerPosition = player.Position.ToString();
                            string? playerCaptain = player.Captain ? "Yes" : "No";

                            // Load the image for the player
                            Image? playerImage = null;
                            string? profileImagePath = Path.Combine(profileFolder, $"{playerName}.png");
                            string? imagePath = File.Exists(profileImagePath) ? profileImagePath : Path.Combine(defaultFolder, $"FemaleFBPlayer.png");
                            if (File.Exists(imagePath))
                            {
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    playerImage = Image.FromStream(fs);
                                    fs.Close();
                                }
                                playerImage = playerImage.GetThumbnailImage(92, 89, null, IntPtr.Zero);
                            }

                            PlayerControl? playerControl = new PlayerControl();
                            playerControl.Name = $"PlayerControl_{Guid.NewGuid()}";
                            playerControl.Favorites = this;
                            playerControl.SetPlayerData(playerImage, playerName, playerPosition, playerShirtNum, playerCaptain);

                            // Add the control to the container
                            flpAllPLayers.Controls.Add(playerControl);
                        }
                    }
                }
            }
        }

        //SAVE PODATAKA
        public void SaveLocalFavorites(Dictionary<string, Control> controlDict, char gender)
        {
            string? pathToImagesFolder = Path.Combine(Application.StartupPath, "ProfilePictures");
            if (!Directory.Exists(pathToImagesFolder))
            {
                Directory.CreateDirectory(pathToImagesFolder);
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
                ImageList imageList = MyWorker.ImageRetriever.GetImageList();

                List<object> controlData = new List<object>();

                foreach (KeyValuePair<string, Control> kvp in controlDict)
                {
                    //MessageBox.Show(kvp.Value.Controls.Count.ToString());
                    if (kvp.Value is FlowLayoutPanel)
                    {

                        FlowLayoutPanel layoutPanel = (FlowLayoutPanel)kvp.Value;
                        foreach (PlayerControl item in layoutPanel.Controls)
                        {
                            int? counterGoals = 0;
                            int? counterYellowCards = 0;
                            int? counterAppereance = 0;

                            string playerImage = ImageToBase64(item.ProfilePicture, System.Drawing.Imaging.ImageFormat.Png);
                            string playerName = item.PlayerName;
                            string playerShirtNum = item.ShirtNumber;
                            string playerPosition = item.Position;
                            string playerCaptain = item.IsCaptain;

                            if (gender == 'm')
                            {
                                foreach (var m in menMatches)
                                {
                                    List<TeamEvent> eventsHome = m.HomeTeamEvents.ToList();
                                    List<TeamEvent> eventsAway = m.AwayTeamEvents.ToList();

                                    List<StartingEleven> startingHome = m.HomeTeamStatistics.StartingEleven;
                                    List<StartingEleven> substitutesHome = m.HomeTeamStatistics.Substitutes;

                                    List<StartingEleven> startingAway = m.AwayTeamStatistics.StartingEleven;
                                    List<StartingEleven> substitutesAway = m.AwayTeamStatistics.Substitutes;

                                    counterGoals += CountGoals(eventsHome, playerName);
                                    counterGoals += CountGoals(eventsAway, playerName);

                                    counterYellowCards += CountYellowCards(eventsHome, playerName);
                                    counterYellowCards += CountYellowCards(eventsAway, playerName);

                                    counterAppereance += CountApperencesStarting11(startingHome, playerName);
                                    counterAppereance += CountApperencesSubs(substitutesHome,eventsHome, playerName);

                                    counterAppereance += CountApperencesStarting11(startingAway, playerName);
                                    counterAppereance += CountApperencesSubs(substitutesAway,eventsAway, playerName);


                                }
                            }
                            else if (gender == 'f') 
                            {
                                foreach (var m in womenMatches)
                                {
                                    List<TeamEvent> eventsHome = m.HomeTeamEvents.ToList();
                                    List<TeamEvent> eventsAway = m.AwayTeamEvents.ToList();

                                    List<StartingEleven> startingHome = m.HomeTeamStatistics.StartingEleven;
                                    List<StartingEleven> substitutesHome = m.HomeTeamStatistics.Substitutes;

                                    List<StartingEleven> startingAway = m.AwayTeamStatistics.StartingEleven;
                                    List<StartingEleven> substitutesAway = m.AwayTeamStatistics.Substitutes;

                                    counterGoals += CountGoals(eventsHome, playerName);
                                    counterGoals += CountGoals(eventsAway, playerName);

                                    counterYellowCards += CountYellowCards(eventsHome, playerName);
                                    counterYellowCards += CountYellowCards(eventsAway, playerName);

                                    counterAppereance += CountApperencesStarting11(startingHome, playerName);
                                    counterAppereance += CountApperencesSubs(substitutesHome, eventsHome, playerName);

                                    counterAppereance += CountApperencesStarting11(startingAway, playerName);
                                    counterAppereance += CountApperencesSubs(substitutesAway, eventsAway, playerName);
                                }
                            }

                            controlData.Add(new
                            {
                                LayoutPanelName = layoutPanel.Name,
                                PlayerImage = playerImage,
                                PlayerName = playerName,
                                ShirtNumber = playerShirtNum,
                                Position = playerPosition,
                                IsCaptain = playerCaptain,
                                Goals = counterGoals,
                                YellowCards = counterYellowCards,
                                Appearances = counterAppereance
                            });
                        }
                    }
                    else if (kvp.Value is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)kvp.Value;
                        controlData.Add(new
                        {
                            ControlName = kvp.Value.Name,
                            SelectedIndex = comboBox.SelectedIndex
                        });
                    }
                }

                string jsonString = JsonConvert.SerializeObject(controlData, Formatting.Indented);

                File.WriteAllText(cPath, jsonString);
            }
        }

        //LOAD PODATAKA
        //https://www.newtonsoft.com/json/help/html/t_newtonsoft_json_linq_jtoken.htm
        public void LoadLocalFavorites(Dictionary<string, Control> controlDict, char gender)
        {
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
                    foreach (JToken data in controlDataList)
                    {
                        foreach (KeyValuePair<string, Control> kvp in controlDict)
                        {
                            if (kvp.Value is FlowLayoutPanel)
                            {
                                if (data["LayoutPanelName"] != null && kvp.Value.Name == data["LayoutPanelName"].ToString())
                                {
                                    bool itemExists = false;
                                    foreach (PlayerControl playerControl in ((FlowLayoutPanel)kvp.Value).Controls)
                                    {
                                        if (playerControl.Name == data["PlayerName"].ToString())
                                        {
                                            itemExists = true;
                                            break;
                                        }
                                    }
                                    if (!itemExists)
                                    {
                                        string playerName = data["PlayerName"].ToString();
                                        string playerShirtNum = data["ShirtNumber"].ToString();
                                        string playerPosition = data["Position"].ToString();
                                        string playerCaptain = data["IsCaptain"].ToString();
                                        Image playerImage = Base64ToImage(data["PlayerImage"].ToString());

                                        PlayerControl newControl = new PlayerControl();
                                        newControl.Name = $"PlayerControl_{Guid.NewGuid()}";
                                        newControl.Favorites = this;

                                        newControl.PlayerName = playerName;
                                        newControl.ShirtNumber = playerShirtNum;
                                        newControl.Position = playerPosition;
                                        newControl.IsCaptain = playerCaptain;
                                        newControl.ProfilePicture = playerImage;

                                        ((FlowLayoutPanel)kvp.Value).Controls.Add(newControl);
                                    }
                                    break;
                                }
                            }
                            else if (kvp.Value is ComboBox)
                            {
                                if (data["ControlName"] != null && kvp.Value.Name == data["ControlName"].ToString())
                                {
                                    if (data["SelectedIndex"] != null)
                                    {
                                        int selectedInd = int.Parse(data["SelectedIndex"].ToString());
                                        ComboBox comboBox = (ComboBox)kvp.Value;
                                        comboBox.SelectedIndex = selectedInd;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

        }

        private void Favorites_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //sejvaj musku repku 0 == male
            if (selectedMF == 0)
            {
                SaveLocalFavorites(controlsFav, 'm');
            } //sejvaj zensku repku 1 == female
            else if (selectedMF == 1)
            {
                SaveLocalFavorites(controlsFav, 'f');
            }
            flpAllPLayers.Controls.Clear();

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

        private void flpAllPLayers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var name = e.Data.GetData(typeof(string)) as string;
                var control = this.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            PlayerControl control = (PlayerControl)this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                if (((FlowLayoutPanel)sender).Controls.Count >= 3)
                {
                    MessageBox.Show("Cannot add more than three Players!");
                    return;
                }
           
                if (((FlowLayoutPanel)sender).Controls.OfType<PlayerControl>().Any(c => c.PlayerName == control.PlayerName))
                {
                    MessageBox.Show("Player already in Favorites!");
                    return;
                }
                var newControl = new PlayerControl();
                newControl.Name = $"PlayerControl_{Guid.NewGuid()}";
                newControl.PlayerName = control.PlayerName;
                newControl.ShirtNumber = control.ShirtNumber;
                newControl.Position = control.Position;
                newControl.IsCaptain = control.IsCaptain;
                //newControl.IsFavorite = control.IsFavorite;
                newControl.ProfilePicture = control.ProfilePicture;
                ((FlowLayoutPanel)sender).Controls.Add(newControl);
            }
        }

        //COUNTANJE 
        public int CountGoals(List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var ev in events)
            {
                switch (ev.TypeOfEvent)
                {
                    case TypeOfEvent.Goal:
                    case TypeOfEvent.GoalOwn:
                    case TypeOfEvent.GoalPenalty:
                        if (ev.Player == playerName)
                        {
                            counter++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return counter;
        }

        public int CountYellowCards(List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var ev in events)
            {
                switch (ev.TypeOfEvent)
                {
                    case TypeOfEvent.YellowCard:
                    case TypeOfEvent.YellowCardSecond:
                        if (ev.Player == playerName)
                        {
                            counter++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return counter;
        }

        public int CountApperencesStarting11(List<StartingEleven> gamePlayers, string playerName)
        {
            int counter = 0;

            foreach (var player in gamePlayers.Where(pn => pn.Name == playerName))
            {
                counter++;
            }

            return counter;
        }

        public int CountApperencesSubs(List<StartingEleven> gamePlayers, List<TeamEvent> events, string playerName)
        {
            int counter = 0;

            foreach (var player in gamePlayers.Where(pn => pn.Name == playerName))
            {
                counter++;
            }

            return counter;
        }

       
    }
}
