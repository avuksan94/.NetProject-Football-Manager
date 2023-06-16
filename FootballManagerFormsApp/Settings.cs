using BL.Services;
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

namespace FootballManagerFormsApp
{
    public partial class Settings : Form
    {
        public delegate void SettingsChangedEventHandler(object sender, EventArgs e);
        public event SettingsChangedEventHandler SettingsChanged;
        public WelcomeForm WelcomeForm { get; set; }
        public int SelectedLanguageIndex { get; set; }

        int languageChanged = 0;
        int repChanged = 0;

        DataService dataService;
        private ResourceManager resourceManager;
        public Dictionary<string, Control> controlsSettings;

        public Settings()
        {
            InitializeComponent();
            dataService = new DataService();
            resourceManager = new ResourceManager(typeof(Settings));
            controlsSettings = new Dictionary<string, Control>();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnClose.Enabled= false;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            controlsSettings.Add("cbChooseLanguage", cbChooseLanguage);
            controlsSettings.Add("cbChooseMF", cbChooseMF);

            dataService.LoadLocal(controlsSettings);
        }

        private void cbChooseLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            languageChanged++;
            switch (cbChooseLanguage.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.en_WelcomeScreenLocal", typeof(Settings).Assembly);
                    
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.hrv_WelcomeScreenLocal", typeof(Settings).Assembly);
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

            //btnClose.Text = resourceManager.GetString("btnClose");
            //btnExit.Text = resourceManager.GetString("btnExit");

            SelectedLanguageIndex = cbChooseLanguage.SelectedIndex;
            if (languageChanged > 1 || repChanged > 1)
            {
                btnClose.Enabled = true;
            }
        }

        private void cbChooseMF_SelectedIndexChanged(object sender, EventArgs e)
        {
            repChanged++;
            if (languageChanged > 1 || repChanged > 1)
            {
                btnClose.Enabled = true;
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //inicijalna promjena kod loada,ako nije bilo izmjena onda mora biti 1 za oba cb
            if (languageChanged > 1 || repChanged > 1)
            {
                DialogForm dForm = new DialogForm();
                dForm.Settings = this;
                dForm.Owner= this;
                dForm.Show();
            }
            else this.Close();
        }

        //poziva se u dialogu
        public void SaveChanges() 
        {
            dataService.SaveLocal(controlsSettings);
            SettingsChanged?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
