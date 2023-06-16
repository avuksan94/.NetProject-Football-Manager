using DL;
using FootballManagerWPFApp.ModelView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFTestingGround;
using System.Resources;
using WPFTestingGround.Model;

namespace FootballManagerWPFApp.View
{
    /// <summary>
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        public string resPath,langPath, selectedRepPath, selectedMFPath;
        public const char DELIMITER = '|';

        public readonly PlayerViewModel? vmPlayer;
        public MatchesBL? SpecificMatch;
        public string? PlayerName;

        public Dictionary<string, Control> controlsPlayerInfoWindow;

        ResourceManager resourceManager;
        public PlayerInfo()
        {
            InitializeComponent();
            vmPlayer = new PlayerViewModel();
            InitComps();
            LoadWindowControls();

            Loaded += (sender, e) =>
            {
                LoadWindowData();
                SetPLayerInfo();

                Visibility = Visibility.Visible;
            };
        }

        public void InitComps() 
        {
            controlsPlayerInfoWindow = new Dictionary<string, Control>();
            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            langPath = GetFilePath(DL.Constants.SELECTED_LANGUAGE);
            selectedRepPath = GetFilePath(DL.Constants.SELECTED_REPRESENTATION);
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);
        }

        private void LoadWindowData()
        {
            switch (LoadSelectedLang())
            {
                case "ENG":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.en_PlayerInfo_Local", typeof(MainWindow).Assembly);
                    break;
                case "HRV":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.hrv_PlayerInfo_Local", typeof(MainWindow).Assembly);
                    break;
                default:
                    break;
            }

            if (resourceManager != null)
            {
                btnClose.Content = resourceManager.GetString("btnClose");

                lbDisplayPlayerName.Content = resourceManager.GetString("lbDisplayPlayerName");
                lbDisplayPlayerShirtNumber.Content = resourceManager.GetString("lbDisplayPlayerShirtNumber");
                lbDisplayPosition.Content = resourceManager.GetString("lbDisplayPosition");
                lbDisplayIsCaptain.Content = resourceManager.GetString("lbDisplayIsCaptain");
                lbDisplayGoals.Content = resourceManager.GetString("lbDisplayGoals");
                lbDisplayYellowCards.Content = resourceManager.GetString("lbDisplayYellowCards");
            }

        }

        private void LoadWindowControls()
        {
            controlsPlayerInfoWindow.Add("btnClose", btnClose);
            controlsPlayerInfoWindow.Add("lbDisplayPlayerName", lbDisplayPlayerName);
            controlsPlayerInfoWindow.Add("lbDisplayPlayerShirtNumber", lbDisplayPlayerShirtNumber);
            controlsPlayerInfoWindow.Add("lbDisplayPosition", lbDisplayPosition);
            controlsPlayerInfoWindow.Add("lbDisplayIsCaptain", lbDisplayIsCaptain);
            controlsPlayerInfoWindow.Add("lbDisplayGoals", lbDisplayGoals);
            controlsPlayerInfoWindow.Add("lbDisplayYellowCards", lbDisplayYellowCards);
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

        public void SetPLayerInfo()
        {
            int mf = LoadSelectedMF();
            List<Image> defaultImages = LoadDefaultPlayerImages();
            List<Image> changedImages = LoadChangedPlayerImages();
            SpecificMatch = DataContext as MatchesBL;

            if (SpecificMatch != null)
            {
                foreach (var player in vmPlayer.GetPlayerStats(SpecificMatch))
                {
                    if (player.Name == PlayerName)
                    {
                        lbPlayerName.Content = player.Name;
                        lbPosition.Content = player.Position;
                        lbShirtNumber.Content = player.ShirtNumber;
                        switch (LoadSelectedLang())
                        {
                            case "HRV":
                                lbIsCaptain.Content = player.Captain ? "Da" : "Ne";
                                break;
                            case "ENG":
                                lbIsCaptain.Content = player.Captain ? "Yes" : "No";
                                break;
                            default:
                                break;
                        }
                        lbGoals.Content = player.Goals;
                        lbYellowCards.Content = player.YellowCards;

                        if (mf == 0)
                        {
                            ImageBrush brush = new ImageBrush();
                            Image? playerImage = changedImages.FirstOrDefault(img => img.Tag.ToString() == player.Name);
                            if (playerImage != null)
                            {
                                brush.ImageSource = playerImage.Source;
                                elPlayerIcon.Fill = brush;
                            }
                            else
                            {
                                brush.ImageSource = defaultImages[4].Source;
                                elPlayerIcon.Fill = brush;
                            }
                        }
                        else if (mf == 1)
                        {
                            ImageBrush brush = new ImageBrush();
                            Image? playerImage = changedImages.FirstOrDefault(img => img.Tag.ToString() == player.Name);
                            if (playerImage != null)
                            {
                                brush.ImageSource = playerImage.Source;
                                elPlayerIcon.Fill = brush;
                            }
                            else
                            {
                                brush.ImageSource = defaultImages[1].Source;
                                elPlayerIcon.Fill = brush;
                            }
                        }
                    }

                }
            }

        }



        private string GetFilePath(string path)
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string otherProjectDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "FootballManagerFormsApp", "bin", "Debug", "net6.0-windows", path);
            return otherProjectDirectory;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        public void LoadResolution()
        {

            using (StreamReader? streamReader = new StreamReader(resPath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split();
                    Width = int.Parse(data[0]);
                    Height = int.Parse(data[1]);
                }
                streamReader.Close();
            }

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
    }
}
