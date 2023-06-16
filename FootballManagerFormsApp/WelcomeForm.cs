using BL.Services;
using System.Globalization;
using System.Resources;

namespace FootballManagerFormsApp
{
    public partial class WelcomeForm : Form
    {
        private DataService? dataService;
        private ResourceManager? resourceManager;
        public Dictionary<string, Control> controlsWf;

        public int SelectedLanguageCode { get; set; }
        public int SelectedMF { get; set; }


        public WelcomeForm()
        {
            dataService = new DataService();
            resourceManager = new ResourceManager(typeof(WelcomeForm));
            controlsWf = new Dictionary<string, Control>();
            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
            this.KeyDown += WelcomeForm_KeyDown;

            EnableButtons();
          
        }

        private void EnableButtons() 
        {
            if (cbChooseMF.SelectedIndex == -1)
            {
                btnFavorites.Enabled = false;
                btnRankings.Enabled = false;
            }
            else
            {
                btnFavorites.Enabled = true;
                btnRankings.Enabled = true;
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            controlsWf.Add("cbChooseLanguage", cbChooseLanguage);
            controlsWf.Add("cbChooseMF", cbChooseMF);

            dataService.LoadLocal(controlsWf);

        }

        private void cbChooseLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbChooseLanguage.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.en_WelcomeScreenLocal", typeof(WelcomeForm).Assembly);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.hrv_WelcomeScreenLocal", typeof(WelcomeForm).Assembly);
                    break;
                default:
                    break;
            }

            lbChooseYourLanguage.Text = resourceManager.GetString("lbChooseYourLanguage");
            cbChooseLanguage.Text = resourceManager.GetString("cbChooseLanguage");

            lbChooseMF.Text = resourceManager.GetString("lbChooseMF");
            cbChooseMF.Text = resourceManager.GetString("cbChooseMF");
            cbChooseMF.Items[0] = resourceManager.GetString("lbChooseMFIndex0");
            cbChooseMF.Items[1] = resourceManager.GetString("lbChooseMFIndex1");

            btnFavorites.Text = resourceManager.GetString("btnFavorites");
            btnRankings.Text = resourceManager.GetString("btnRankings");
            btnSettings.Text = resourceManager.GetString("btnSettings");
            btnExit.Text = resourceManager.GetString("btnExit");

            SelectedLanguageCode = cbChooseLanguage.SelectedIndex;
        }

        private void WelcomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataService.SaveLocal(controlsWf);
        }

        private void btnFavorites_Click(object sender, EventArgs e)
        {
            Favorites favorites = new Favorites();
            favorites.WelcomeForm= this;
            favorites.Show();
        }

        private void cbChooseMF_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedMF = cbChooseMF.SelectedIndex;
            btnRankings.Enabled = true;
            btnFavorites.Enabled = true;
        }

        private void btnRankings_Click(object sender, EventArgs e)
        {
            Rankings rankings = new Rankings();
            rankings.WelcomeForm = this;
            rankings.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.WelcomeForm = this;
            settings.SettingsChanged += Settings_SettingsChanged;
            settings.Show();
        }

        private void Settings_SettingsChanged(object sender, EventArgs e)
        {
            dataService.LoadLocal(controlsWf);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WelcomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}