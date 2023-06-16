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
    public partial class PlayerControl : UserControl
    {
        public Favorites Favorites { get; set; }
        private void ChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.ProfilePicture = new Bitmap(openFileDialog.FileName);
            }
        }

        public PlayerControl()
        {
            InitializeComponent();
        }

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

        public string Position
        {
            get { return lbDisplayPosition.Text; }
            set { lbDisplayPosition.Text = value; }
        }

        public string ShirtNumber
        {
            get { return lbDisplayShirtNumber.Text; }
            set { lbDisplayShirtNumber.Text = value; }
        }

        public string IsCaptain
        {
            get { return lbDisplayTeamCaptain.Text; }
            set { lbDisplayTeamCaptain.Text = value; }
        }

        public string Favorite
        {
            get { return lbFavorite.Text; }
            set { lbFavorite.Text = value; }
        }


        public void SetPlayerData(Image profilePictuer, string name,string position, string shirtNumber, string isCaptain) 
        {
            pbDisplayPlayerIcon.Image = profilePictuer;
            lbDisplayName.Text = name;
            lbDisplayPosition.Text = position;
            lbDisplayShirtNumber.Text = shirtNumber;
            lbDisplayTeamCaptain.Text = isCaptain;
            lbFavorite.Text = "⚽";
        }

        private void PlayerControl_Load(object sender, EventArgs e)
        {

        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenuChangePfP = new ContextMenuStrip();

            if (sender is PlayerControl pcontrol &&
                 pcontrol.Parent is FlowLayoutPanel panel &&
                 panel.Name == "flpFavoritePlayers")
            {
                contextMenuChangePfP.Items.Add("Remove Player from Favorites...", null, RemoveFromFavoritesMenuItem_Click);
            }
            else
            {
                contextMenuChangePfP.Items.Add("Change Profile Picture...", null, ChangeProfilePictureMenuItem_Click);
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuChangePfP.Show(this, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this.Name, DragDropEffects.Copy);
            }
        }

        private void RemoveFromFavoritesMenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem &&
                menuItem.Owner is ContextMenuStrip contextMenu &&
                contextMenu.SourceControl is PlayerControl playerControl &&
                playerControl.Parent is FlowLayoutPanel panel &&
                panel.Name == "flpFavoritePlayers")
            {
                panel.Controls.Remove(playerControl);
                playerControl.Dispose();
            }
        }

        private void ChangeProfilePictureMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // If the image file exists
                if (File.Exists(openFileDialog.FileName))
                {
                    // Save the image with a name from PlayerName property
                    string imageName = $"{this.PlayerName}.png";
                    string imagePath = Path.Combine(Application.StartupPath, "ProfilePictures", imageName);

                    using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        openFileDialog.OpenFile().CopyTo(fs);
                    }

                    // Update the profile picture
                    this.ProfilePicture = Image.FromFile(imagePath);
                    Favorites?.RefreshForm();
                }
                else
                {
                    MessageBox.Show("The selected image file does not exist.");
                }
            }
        }
    }
}
