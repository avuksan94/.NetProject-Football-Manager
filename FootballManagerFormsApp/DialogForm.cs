using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballManagerFormsApp
{
    public partial class DialogForm : Form
    {
        public ResourceManager? resourceManager;
        public Settings? Settings;

        public int selectedLanguage;
        
        public DialogForm()
        {
            InitializeComponent();
            resourceManager = new ResourceManager(typeof(DialogForm));
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += DialogForm_KeyDown;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Settings settingsForm = this.Owner as Settings;
            if (settingsForm != null)
            {
                settingsForm.SaveChanges(); 
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter) 
            {
                btnSaveChanges.PerformClick();
            }
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
             selectedLanguage = Settings.SelectedLanguageIndex;
            switch (selectedLanguage)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.en_DialogFormLocal", typeof(DialogForm).Assembly);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("FootballManagerFormsApp.hrv_DialogFormLocal", typeof(DialogForm).Assembly);
                    break;
                default:
                    break;
            }

            lbMakeChanges.Text = resourceManager.GetString("lbMakeChanges");
            btnSaveChanges.Text = resourceManager.GetString("btnSaveChanges");
            btnCancel.Text = resourceManager.GetString("btnCancel");
        }

    }
}
