using FootballManagerWPFApp.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFTestingGround.Model;
using System.Resources;
using WPFTestingGround.ModelView;
using System.Globalization;
using System.Threading;
using WPFTestingGround;
using System.Net.NetworkInformation;
using System.Windows.Media.Animation;

namespace FootballManagerWPFApp.View
{
    public partial class RepInfo : Window
    {
        public string? resPath,langPath, selectedRepPath, selectedMFPath;
        public string? homeCountry, awayCountry = null;
        public const char DELIMITER = '|';

        public int mf;

        public readonly List<TeamResultBL> data;
        public List<TeamResultBL> passedTeamRes;

        ResourceManager? resourceManager;
        public RepInfo(List<TeamResultBL> passRes)
        {
            data = passRes;
            InitializeComponent();
            InitComps();

            Loaded += (sender, e) =>
            {

                LoadWindowData();

                UpdateBindings();

                Visibility = Visibility.Visible;
            };
       
        }

        private void InitComps() 
        {
            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            selectedRepPath = GetFilePath(DL.Constants.SELECTED_REPRESENTATION);
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);
            langPath = GetFilePath(DL.Constants.SELECTED_LANGUAGE);
            DataContext = data;
        }

        private void LoadWindowData()
        {
            switch (LoadSelectedLang())
            {
                case "ENG":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.en_RepInfo_Local", typeof(MainWindow).Assembly);
                    break;
                case "HRV":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.hrv_RepInfo_Local", typeof(MainWindow).Assembly);
                    break;
                default:
                    break;
            }

            if (resourceManager != null)
            {
               lbCountry.Content = resourceManager.GetString("lbCountry");
               btnExit.Content = resourceManager.GetString("btnExit");
            }

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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateBindings()
        {

            RepresentationGrid.ItemsSource = data;
            RepresentationGrid.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();

        }

        private void RepInfoWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private string GetFilePath(string path)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string solutionDirectory = assemblyPath.Substring(0, assemblyPath.IndexOf("OOPDotNetProjAV\\") + "OOPDotNetProjAV\\".Length);
            string formsApp = System.IO.Path.Combine(solutionDirectory, "FootballManagerFormsApp", "bin", "Debug", "net6.0-windows", path);
            return formsApp;
        }

        public void LoadResolution()
        {

            using (StreamReader? streamReader = new StreamReader(resPath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    Width = int.Parse(data[0]);
                    Height = int.Parse(data[1]);
                }
                streamReader.Close();
            }
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
    }

}
