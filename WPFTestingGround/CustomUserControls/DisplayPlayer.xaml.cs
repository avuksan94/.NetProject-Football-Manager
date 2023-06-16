using FootballManagerWPFApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using WPFTestingGround.Model;

namespace FootballManagerWPFApp.CustomUserControls
{
    /// <summary>
    /// Interaction logic for DisplayPlayer.xaml
    /// </summary>
    public partial class DisplayPlayer : UserControl
    {
        public MatchesBL Match { get; set; }
        public string PlayerName { get; set; }
        public string? SelectedPlayerName { get; set; }
        public DisplayPlayer()
        {
            InitializeComponent();
            SelectedPlayerName= string.Empty;

        }

        private void PlayerCont_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SelectedPlayerName = lbDisplayPlayerName.Content.ToString();
                PlayerInfo pInfo = new PlayerInfo();
                pInfo.DataContext = Match;
                pInfo.PlayerName = SelectedPlayerName;
                pInfo.Topmost = true;
                pInfo.Show();
            }
        }
    }
}
