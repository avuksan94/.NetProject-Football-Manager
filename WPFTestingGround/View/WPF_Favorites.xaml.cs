using DL;
using DL.Enums;
using DL.Model;
using FootballManagerWPFApp.CustomUserControls;
using FootballManagerWPFApp.Model;
using FootballManagerWPFApp.ModelView;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFTestingGround;
using WPFTestingGround.Model;
using WPFTestingGround.ModelView;
using Xceed.Wpf.Toolkit;

namespace FootballManagerWPFApp.View
{
    public partial class WPF_Favorites : Window
    {
        public string? resPath,langPath, selectedRepPath, selectedMFPath;
        public const char DELIMITER = '|';

        public string? selectedHome, selectedAway;
        public long? selectedFifaCode;

        public MatchesBL? selectedMatch;
        IList<TeamResultBL>? teamResSelected;

        public readonly PlayerViewModel? vmPlayers;
        public readonly CompositeViewModel? cvModel;


        public Dictionary<string, Control>? controlsFavoritesWindow;

        ResourceManager? resourceManager;

        //ne ide drugacije
        public IList<TeamResultBL>? CustomResults { get; set; }
        public WPF_Favorites()
        {
            InitializeComponent();
            cvModel = new CompositeViewModel();
            vmPlayers = new PlayerViewModel();

            InitComps();
           
            LoadWindowData();

            LoadResolution();
            //LoadSelectedRep();
           
            
            UpdateBindings();

            Visibility = Visibility.Visible;

        }

        public void InitComps() 
        {
            CustomResults = new List<TeamResultBL>();

            selectedMatch = new MatchesBL();
            teamResSelected = new List<TeamResultBL>();

            controlsFavoritesWindow = new Dictionary<string, Control>();
          
            DataContext = cvModel;
            resPath = "";


            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            langPath = GetFilePath(DL.Constants.SELECTED_LANGUAGE);
            selectedRepPath = GetFilePath(DL.Constants.SELECTED_REPRESENTATION);
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);


            LoadWindowControls();

            SetFootballField();
        }

        public void CheckIfExists()
        {
            if (!File.Exists(resPath))
            {
                File.Create(resPath).Close();
            }
        }

        private void LoadWindowData()
        {
            switch (LoadSelectedLang())
            {
                case "ENG":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.en_Favorites_Local", typeof(MainWindow).Assembly);
                    break;
                case "HRV":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.hrv_Favorites_Local", typeof(MainWindow).Assembly);
                    break;
                default:
                    break;
            }
        
            if (resourceManager != null)
            {
                
                lbDisplayScore.Content = resourceManager.GetString("lbDisplayScore");
                btnSettings.Content = resourceManager.GetString("btnSettings");
                btnClose.Content = resourceManager.GetString("btnClose");
            }
        
        }

        private void LoadWindowControls()
        {
            controlsFavoritesWindow?.Add("cbChooseRep", cbChooseRep);
            controlsFavoritesWindow?.Add("lbDisplayScore", lbDisplayScore);
            controlsFavoritesWindow?.Add("btnSettings", btnSettings);
            controlsFavoritesWindow?.Add("btnClose", btnClose);
        }

        public void LoadResolution()
        {
            if (resPath is not null)
            {
                using (StreamReader? streamReader = new StreamReader(resPath))
                {

                    if (streamReader is not null)
                    {
                        string? line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] data = line.Split(DELIMITER);
                            Width = int.Parse(data[0]);
                            Height = int.Parse(data[1]);
                        }
                        streamReader.Close();
                    }

                }
            }
            
               
        }

        public void SetFootballField() 
        {
            string fbFieldPath = GetImagesPath() + "\\football-field2.png";
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(fbFieldPath, UriKind.Relative)));

            gridSoccerField.Background= imageBrush;
        }

        public void LoadSelectedRep()
        {

            using (StreamReader? streamReader = new StreamReader(selectedRepPath))
            {
                string? line, country;
                string[] data;
                while ((line = streamReader.ReadLine()) != null)
                {
                   data = line.Split(DELIMITER);
                   country = data[0];

                    foreach (var item in cbChooseRep.Items)
                    {
                        string? itemCountryName = item.ToString();
                        if (itemCountryName == country)
                        {
                            cbChooseRep.SelectedItem = item;
                            break;
                        }
                    }
                }

                streamReader.Close();
            }

        }

        private string GetFolder(string path)
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string targetDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "DL", "LocalFiles", path);
            return targetDirectory;
        }

        private string GetProfileFolder(string path)
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string targetDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "FootballManagerFormsApp", "bin", "Debug", "net6.0-windows", path);
            return targetDirectory;
        }

        private string GetFilePath(string path)
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string otherProjectDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "FootballManagerFormsApp", "bin", "Debug", "net6.0-windows", path);
            return otherProjectDirectory;
        }

        private string GetImagesPath()
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string targetDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "WPFTestingGround", "images");
            return targetDirectory;
        }

        public int LoadSelectedMF()
        {
            int selectedMF = 0;
            using (StreamReader reader = new StreamReader(selectedMFPath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    int selectedInd = int.Parse(data[0]);
                    selectedMF = selectedInd;
                }
                reader.Close();

            }
            return selectedMF;
        }

        public string LoadSelectedLang()
        {
            string selectedLang = "";
            using (StreamReader reader = new StreamReader(langPath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    string selected = data[0];
                    selectedLang = selected;
                }
                reader.Close();

            }
            return selectedLang;
        }


        private void UpdateBindings()
        {
            int mf = LoadSelectedMF();

            if (cvModel is not null)
            {
                if (mf == 0)
                {
                    RepresentationGrid.ItemsSource = cvModel.VMMatch.MatchesMale;
                    cbChooseRep.ItemsSource = cvModel.VMTeamRes.TeamResultMale;
                }
                else if (mf == 1)
                {
                    RepresentationGrid.ItemsSource = cvModel.VMMatch.MatchesFemale;
                    cbChooseRep.ItemsSource = cvModel.VMTeamRes.TeamResultFemale;
                }
            }
            

            cbChooseRep.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            RepresentationGrid.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();

            LoadSelectedRep();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowFavs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void cbChooseRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbChooseRep.SelectedItem != null)
            {
                TeamResultBL? cbi = (TeamResultBL)cbChooseRep.SelectedItem;
                string? selectedText = cbi.Country;

                RepresentationGrid.Items.Filter = item =>
                {
                    MatchesBL? match = item as MatchesBL;
                    string? homeTeamCountry = match?.HomeTeamCountry;
                    string? awayTeamCountry = match?.AwayTeamCountry;

                    if (selectedText is not null)
                    {
                        bool homeTeamMatches = homeTeamCountry?.IndexOf(selectedText, StringComparison.OrdinalIgnoreCase) >= 0;
                        bool awayTeamMatches = awayTeamCountry?.IndexOf(selectedText, StringComparison.OrdinalIgnoreCase) >= 0;
                        return homeTeamMatches || awayTeamMatches;
                    }
                   
                    return false;
                    
                };
            };

        }

        private void RepresentationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridSoccerField.Children.Clear();
            if (RepresentationGrid.SelectedItem != null)
            {
                StringBuilder sb = new StringBuilder();
                string? homeGoals, awayGoals;

                MatchesBL? match = (MatchesBL)RepresentationGrid.SelectedItem;
                selectedMatch = match;


                homeGoals = match?.HomeTeam?.Goals.ToString();
                sb.Append(homeGoals);
                sb.Append(" : ");
                awayGoals = match?.AwayTeam?.Goals.ToString();
                sb.Append(awayGoals);

                selectedHome = match?.HomeTeamCountry;
                selectedAway = match?.AwayTeamCountry;
                selectedFifaCode = match?.FifaId;


                CustomResults?.Clear();
                if (LoadSelectedMF() == 0)
                {
                    foreach (var result in cvModel.VMTeamRes.TeamResultMale)
                    {
                        if (result.Country == selectedHome || result.Country == selectedAway)
                        {
                            CustomResults.Add(result);
                        }
                    }
                }
                else if (LoadSelectedMF() == 1)
                {
                    foreach (var result in cvModel.VMTeamRes.TeamResultFemale)
                    {
                        if (result.Country == selectedHome || result.Country == selectedAway)
                        {
                            CustomResults.Add(result);
                        }
                    }
                }

                string finalScore = sb.ToString();

                IList<PlayerBL> goaliesHome = new List<PlayerBL>();
                IList<PlayerBL> defenderHome = new List<PlayerBL>();
                IList<PlayerBL> midfieldHome = new List<PlayerBL>();
                IList<PlayerBL> forwardHome = new List<PlayerBL>();

                IList<PlayerBL> goaliesAway = new List<PlayerBL>();
                IList<PlayerBL> defenderAway = new List<PlayerBL>();
                IList<PlayerBL> midfieldAway = new List<PlayerBL>();
                IList<PlayerBL> forwardAway = new List<PlayerBL>();

                foreach (var player in vmPlayers.GetHomePlayers(match))
                {
                    switch (player.Position)
                    {
                        case Position.Goalie:
                            goaliesHome.Add(player);
                            break;
                        case Position.Defender:
                            defenderHome.Add(player);
                            break;
                        case Position.Midfield:
                            midfieldHome.Add(player);
                            break;
                        case Position.Forward:
                            forwardHome.Add(player);
                            break;
                        default:
                            break;
                    }
                }

                foreach (var player in vmPlayers.GetAwayPlayers(match))
                {
                    switch (player.Position)
                    {
                        case Position.Goalie:
                            goaliesAway.Add(player);
                            break;
                        case Position.Defender:
                            defenderAway.Add(player);
                            break;
                        case Position.Midfield:
                            midfieldAway.Add(player);
                            break;
                        case Position.Forward:
                            forwardAway.Add(player);
                            break;
                        default:
                            break;
                    }
                }

                LoadPosition(goaliesHome, 0);
                LoadPosition(defenderHome, 1);
                LoadPosition(midfieldHome, 2);
                LoadPosition(forwardHome, 3);

                LoadPosition(goaliesAway, 7);
                LoadPosition(defenderAway, 6);
                LoadPosition(midfieldAway, 5);
                LoadPosition(forwardAway, 4);

                lbScore.Content = finalScore;
            }
            else
                lbScore.Content = "";

            gridSoccerField.DataContext = vmPlayers;
        }

        //Loadaj ikonice i ostalo na teren

        public void LoadPosition(IList<PlayerBL> position, int row)
        {
            List<Image> defaultImages = LoadDefaultPlayerImages();
            List<Image> changedImages = LoadChangedPlayerImages();

            int mf = LoadSelectedMF();

            int j = 0;
            for (int i = 0; i < position.Count; i++)
            {
                var player = position[i];
                var displayPlayerControl = new DisplayPlayer();
                displayPlayerControl.lbDisplayPlayerName.Content = player.Name;
                displayPlayerControl.lbDisplayShirtNumber.Content = player.ShirtNumber;
                displayPlayerControl.Match = selectedMatch;

                if (mf == 0)
                {
                    ImageBrush brush = new ImageBrush();
                    Image? playerImage = changedImages.FirstOrDefault(img => img.Tag.ToString() == player.Name);
                    if (playerImage != null)
                    {
                        brush.ImageSource = playerImage.Source;
                        displayPlayerControl.elPlayerIcon.Fill = brush;
                    }
                    else 
                    {
                        brush.ImageSource = defaultImages[4].Source;
                        displayPlayerControl.elPlayerIcon.Fill = brush;
                    }
                }
                else if (mf == 1) 
                {
                    ImageBrush brush = new ImageBrush();
                    Image? playerImage = changedImages.FirstOrDefault(img => img.Tag.ToString() == player.Name);
                    if (playerImage != null)
                    {
                        brush.ImageSource = playerImage.Source;
                        displayPlayerControl.elPlayerIcon.Fill = brush;
                    }
                    else
                    {
                        brush.ImageSource = defaultImages[1].Source;
                        displayPlayerControl.elPlayerIcon.Fill = brush;
                    }
                }


                switch (position.Count)
                {
                    case 6:
                        if (j == 3)
                        {
                            j++;
                        }
                        break;
                    case 5:
                        if (j == 2)
                        {
                            j++;
                        }
                        else if (j == 4)
                        {
                            j++;
                        }
                        break;
                    case 4:
                        if (j == 0 || j ==3)
                        {
                            j += 1;
                        }
                        break;
                    case 3:
                        if (j == 0)
                        {
                            j += 2;
                        }
                        break;
                    case 2:
                        if (j == 0)
                        {
                            j += 2;
                        }
                        else if (j == 3)
                        {
                            j ++;
                        }
                        break;
                    case 1:
                        if (j == 0)
                        {
                            j += 3;
                        }
                        break;
                    default:
                        break;
                }

                Grid.SetRow(displayPlayerControl, row);
                Grid.SetColumn(displayPlayerControl, j);
                j++;

                gridSoccerField.Children.Add(displayPlayerControl);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Closed += Settings_Closed;
            settings.Show();
        }

        private void Settings_Closed(object sender, EventArgs e)
        {
            CustomResults?.Clear();
            RefreshData();
        }

        private void RefreshData()
        {
            CustomResults?.Clear();
            LoadWindowData();
            LoadResolution();
            
            UpdateBindings();

        }

        public List<Image> LoadDefaultPlayerImages() 
        {
            string folderPath = GetFolder("images");
            string[] files = Directory.GetFiles(folderPath, "*.png");

            List<Image> images = new List<Image>();

            foreach (string file in files)
            {
                Image image = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                string relativePath = file.Substring(file.IndexOf(folderPath));
                bitmapImage.UriSource = new Uri(relativePath, UriKind.Relative);
                bitmapImage.EndInit();


                image.Source = bitmapImage;
                images.Add(image);
            }

            return images;
        }

        public List<Image> LoadChangedPlayerImages()
        {
            string folderPath = GetProfileFolder("ProfilePictures");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string[] files = Directory.GetFiles(folderPath, "*.png");

            List<Image> images = new List<Image>();

            foreach (string file in files)
            {
                Image image = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                string relativePath = file.Substring(file.IndexOf(folderPath));
                bitmapImage.UriSource = new Uri(relativePath, UriKind.Relative);
                bitmapImage.EndInit();

                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);

                image.Tag = fileNameWithoutExtension.ToString();
                image.Source = bitmapImage;
                images.Add(image);
            }

            return images;
        }

        public void PrepareResultsInfoDisplay(List<TeamResultBL> results, MatchesBL match)
        {
            string? homeTeamCountry = match?.HomeTeamCountry;
            string? awayTeamCountry = match?.AwayTeamCountry;

            foreach (var result in results)
            {
                if (result.Country == homeTeamCountry || result.Country == awayTeamCountry)
                {
                    teamResSelected?.Add(result);
                }
            }

            
        }



    }
}
