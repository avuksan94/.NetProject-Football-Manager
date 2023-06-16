using BL.Services;
using DL;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFTestingGround.ModelView;
using DL.Model;
using System.Reflection;
using FootballManagerFormsApp;
using System.Globalization;
using System.Threading;
using System.Resources;
using FootballManagerWPFApp.View;

namespace WPFTestingGround
{
    public partial class MainWindow : Window
    {
        public const char DELIMITER = '|';
        public string? cbPath, resPath,langPath, selectedMFPath, selectedRepPath;
        public string? selectedResolution;
        public string? message;
        public int? selectedMF;


        ResourceManager? resourceManager;
        public Dictionary<string, Control>? controlsWelcomeWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.Topmost= true;
            controlsWelcomeWindow = new Dictionary<string, Control>();
           
            cbPath = GetFilePath(DL.Constants.COMBO_BOXES);
            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);
            selectedRepPath = GetFilePath(DL.Constants.SELECTED_REPRESENTATION);
            CheckIfExists();
            LoadWindowControls();
            LoadLocal(controlsWelcomeWindow);
            LoadWindowData();
            SaveMFToFile();
            SaveLanguageToFile();
        }

        private void LoadWindowData() 
        {
            switch (cbChooseLanguage.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.en_MW_Local", typeof(MainWindow).Assembly);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerWPFApp.Resources.hrv_MW_Local", typeof(MainWindow).Assembly);
                    break;
                default:
                    break;
            }

            if (resourceManager != null)
            {
                lbChooseResolution.Content = resourceManager.GetString("lbChooseResolution");
                lbChooseLanguage.Content = resourceManager.GetString("lbChooseLanguage");
                lbChooseRepMF.Content = resourceManager.GetString("lbChooseRepMF");


                btnFavorites.Content = resourceManager.GetString("btnFavorites");
                btnExit.Content = resourceManager.GetString("btnExit");
                message = resourceManager.GetString("MessageExit");
            }

        }

        private void cbChooseResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int item = cbChooseResolution.SelectedIndex;

            switch (item)
            {
                case 0:
                    Width = 1366;
                    Height= 768;
                    selectedResolution = "1366|768";
                    break;
                case 1:
                    Width = 1600;
                    Height = 800;
                    selectedResolution = "1600|800";
                    break;
                case 2:
                    Width = 1920;
                    Height = 1080;
                    selectedResolution = "1920|1080";
                    break;
                default:
                    break;
            }
            WindowState = WindowState.Normal;
            SaveResolutionToFile();
            LoadWindowData();
        }

        private void LoadWindowControls()
        {
            controlsWelcomeWindow.Add("cbChooseLanguage", cbChooseLanguage);
            controlsWelcomeWindow.Add("cbChooseMF", cbChooseMF);
            controlsWelcomeWindow.Add("cbChooseResolution", cbChooseResolution);
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            SaveLocal(controlsWelcomeWindow);
            SaveResolutionToFile();
            SaveMFToFile();
            Close();
        }

        private string GetFilePath(string path)
        {
            string currentProjectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo solutionDirectory = Directory.GetParent(currentProjectDirectory).Parent.Parent.Parent.Parent;
            string otherProjectDirectory = System.IO.Path.Combine(solutionDirectory.FullName, "FootballManagerFormsApp", "bin", "Debug", "net6.0-windows", path);
            return otherProjectDirectory;
        }

        public void LoadLocal(Dictionary<string, Control> controlDict)
        {

            using (StreamReader comboBoxReader = new StreamReader(cbPath))
            {
                string line;
                while ((line = comboBoxReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
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

        public void SaveLocal(Dictionary<string, Control> controlDict)
        {
            using (StreamWriter comboBoxWriter = new StreamWriter(cbPath))
            {
                foreach (KeyValuePair<string, Control> kvp in controlDict)
                {
                    if (kvp.Value is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)kvp.Value;
                        comboBoxWriter.Write($"{kvp.Key}|{comboBox.SelectedIndex.ToString()}{Environment.NewLine}");
                    }
                }
                comboBoxWriter.Close();
            }
           
        }

        private void SaveResolutionToFile() 
        {
            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            using (StreamWriter resWriter = new StreamWriter(resPath))
            {
                resWriter.Write(selectedResolution);
                resWriter.Close();
            }
            
        }

        private void SaveLanguageToFile()
        {
            langPath = GetFilePath(DL.Constants.SELECTED_LANGUAGE);
            using (StreamWriter resWriter = new StreamWriter(langPath))
            {
                resWriter.Write(cbChooseLanguage.Text);
                resWriter.Close();
            }

        }

        private void SaveMFToFile()
        {
            selectedMF = cbChooseMF.SelectedIndex;
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);
            using (StreamWriter mfWriter = new StreamWriter(selectedMFPath))
            {
                mfWriter.Write(selectedMF);
                mfWriter.Close();
            }

        }

        public void CheckIfExists()
        {
            if (!File.Exists(cbPath))
            {
                File.Create(cbPath).Close();
            }
            if (!File.Exists(resPath))
            {
                File.Create(resPath).Close();
            }
            if (!File.Exists(selectedMFPath))
            {
                File.Create(selectedMFPath).Close();
            }
            if (!File.Exists(selectedRepPath))
            {
                File.Create(selectedRepPath).Close();
            }
        }

        private void btnFavorites_Click(object sender, RoutedEventArgs e)
        {
            SaveLocal(controlsWelcomeWindow);
            SaveResolutionToFile();
            SaveLanguageToFile();
            SaveMFToFile();

            WPF_Favorites favorites = new WPF_Favorites();

            favorites.Show();
            Close();


        }

        private void MainWindow1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult result = MessageBox.Show(message,"Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveLocal(controlsWelcomeWindow);
                    SaveResolutionToFile();
                    SaveMFToFile();
                    Close();
                }
                else if(result == MessageBoxResult.No)
                {
                    Close();
                }
                else
                {
                    // Nemoj Zatvarati
                }
            }
        }

        private void MainWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void cbChooseLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadWindowData();
        }

        private void cbChooseMF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadWindowData();
            SaveMFToFile();
        }
    }
}
