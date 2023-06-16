using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Resources;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Threading;
using WPFTestingGround;
using System.IO;
using System.Reflection;

namespace FootballManagerWPFApp.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const char DELIMITER = '|';
        private string? cbPath, resPath,langPath, selectedMFPath;
        private string? selectedResolution;
        private int selectedMF;


        ResourceManager resourceManager;
        private Dictionary<string, Control>? controlsSettingsWindow;
        public Settings()
        {
            InitializeComponent();

            InitComps();
            CheckIfExists();
            LoadWindowControls();
            LoadLocal(controlsSettingsWindow);
            LoadWindowData();
        }

        private void InitComps() 
        {
            controlsSettingsWindow = new Dictionary<string, Control>();

            cbPath = GetFilePath(DL.Constants.COMBO_BOXES);
            resPath = GetFilePath(DL.Constants.RESOLUTION_FILE);
            langPath = GetFilePath(DL.Constants.SELECTED_LANGUAGE);
            selectedMFPath = GetFilePath(DL.Constants.SELECTED_MF);
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

                btnExit.Content = resourceManager.GetString("btnExit");
            }

        }

        //ZA LOADANJE I SEJVANJE PODATAKA(Mislio sam ovo sve raditi u Data servicu ali postoji problem sa Controls(WinForms vs WFP))
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
            using (StreamWriter resWriter = new StreamWriter(resPath))
            {
                resWriter.Write(selectedResolution);
                resWriter.Close();
            }

        }

        private void SaveLangToFile()
        {
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
        }

        private void LoadWindowControls()
        {
            controlsSettingsWindow.Add("cbChooseLanguage", cbChooseLanguage);
            controlsSettingsWindow.Add("cbChooseMF", cbChooseMF);
            controlsSettingsWindow.Add("cbChooseResolution", cbChooseResolution);
        }

        private void cbChooseResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int item = cbChooseResolution.SelectedIndex;

            switch (item)
            {
                case 0:
                    selectedResolution = "1366|768";
                    break;
                case 1:
                    selectedResolution = "1600|800";
                    break;
                case 2:
                    selectedResolution = "1920|1080";
                    break;
                default:
                    break;
            }
            SaveResolutionToFile();
            LoadWindowData();
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            SaveLocal(controlsSettingsWindow);
            SaveResolutionToFile();
            SaveMFToFile();
            SaveLangToFile();
            Close();
        }
    }
}
