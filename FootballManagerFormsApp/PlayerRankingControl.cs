using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballManagerFormsApp
{
    public partial class PlayerRankingControl : UserControl
    {
        public Image ProfilePicture
        {
            get { return pbDisplayPlayerIcon.Image; }
            set { pbDisplayPlayerIcon.Image = value; }
        }

        public string PlayerName
        {
            get { return lbDisplayName.Text; }
            set { lbDisplayName.Text = value; }
        }

        public string Goals
        {
            get { return lbDisplayPlayerGoals.Text; }
            set { lbDisplayPlayerGoals.Text = value; }
        }

        public string YellowCards
        {
            get { return lbDisplayYellowCards.Text; }
            set { lbDisplayYellowCards.Text = value; }
        }

        public string Appereance
        {
            get { return lbDisplayPlayerAppereances.Text; }
            set { lbDisplayPlayerAppereances.Text = value; }
        }
        public PlayerRankingControl()
        {
            InitializeComponent();
        }

        public void SetPlayerData(Image profilePictuer, string name, string goals, string yellowCards, string appereances)
        {
            pbDisplayPlayerIcon.Image = profilePictuer;
            lbDisplayName.Text = name;
            lbDisplayPlayerGoals.Text = goals;
            lbDisplayYellowCards.Text = yellowCards;
            lbDisplayPlayerAppereances.Text = appereances;
        }

        private void PlayerRankingControl_Load(object sender, EventArgs e)
        {

        }
    }
}
