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
using RepoStrategy.Model;
using System.Diagnostics;
using System.Configuration;
using DAL.Model;
using RepoStrategy.Enums;
using System.Numerics;
using System.Reflection;
using MyHelper;

namespace FormsApp
{
    public partial class pnlRepPlayers : Form
    {
        private WelcomeScreenForm Wsf;
        public Dictionary<string, Control> controlsFavorites = new Dictionary<string, Control>();
        //private ImageList imageList;

        public string pathToImagesFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "..", "..", "..", "..", "DAL", "LocalFiles", "images");
        //Slikice:

        public pnlRepPlayers(ResourceManager resourceManager, WelcomeScreenForm wsf)
        {
            InitializeComponent();
            lbChooseRep.Text = resourceManager.GetString("lbChooseRep");
            cbChooseRep.Text = resourceManager.GetString("cbChooseRep");
            this.Wsf = wsf;

            LoadControls();

            List<TeamResult> menSortedList = Wsf.MenRes.ToList();
            menSortedList.Sort();
            List<TeamResult> womenSortedList = Wsf.WomenRes.ToList();
            womenSortedList.Sort();
            LoadTeamResults(menSortedList, womenSortedList);

            lvAllPlayers.View = View.Details;
            lvAllPlayers.Columns.Add("Name");
            lvAllPlayers.Columns.Add("Shirt Number");
            lvAllPlayers.Columns.Add("Position");
            lvAllPlayers.Columns.Add("Captain");

            //DRAG AND DROP
            lvAllPlayers.AllowDrop = true;
            lvAllPlayers.MultiSelect = true;
            lvFavoritePlayers.AllowDrop = true;
            //****************************

            lvAllPlayers.Columns[0].Width = 250;
            lvAllPlayers.Columns[1].Width = 100;
            lvAllPlayers.Columns[2].Width = 80;
            lvAllPlayers.Columns[3].Width = 80;

            lvFavoritePlayers.View = View.Details;
            lvFavoritePlayers.Columns.Add("Name");
            lvFavoritePlayers.Columns.Add("Shirt Number");
            lvFavoritePlayers.Columns.Add("Position");
            lvFavoritePlayers.Columns.Add("Captain");

            lvFavoritePlayers.Columns[0].Width = 250;
            lvFavoritePlayers.Columns[1].Width = 100;
            lvFavoritePlayers.Columns[2].Width = 80;
            lvFavoritePlayers.Columns[3].Width = 80;

        }



        private void LoadTeamResultProcedure(List<TeamResult> sortedList)
        {
            cbChooseRep.Items.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (TeamResult item in sortedList)
            {
                sb.Clear();
                sb.Append(item.Country);
                sb.Append(" ");
                sb.Append(item.FifaCode);
                cbChooseRep.Items.Add(sb.ToString());
            }
            cbChooseRep.Refresh();
        }

        private void LoadTeamResults(List<TeamResult> menSortedList, List<TeamResult> womenSortedList)
        {
            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                LoadTeamResultProcedure(menSortedList);
            }
            else if (Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                LoadTeamResultProcedure(womenSortedList);
            }
        }


        //Loadanje playera i image-a kada se promijeni repka

        //private void LoadPlayersLVProcedure(List<TeamResult> sortedList, int imgIndex) 
        //{
        //    
        //}

        private void LoadPlayersListView()
        {
            ImageList imageList;
            string? selectedItem = cbChooseRep?.SelectedItem?.ToString();
            string? selectedCountry = selectedItem?.Split(' ')[0];

            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                imageList = Helper.GetImageListDefault(pathToImagesFolder);

                foreach (KeyValuePair<string, SortedSet<Player>> pair in Wsf.MenPlayers)
                {
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {
                            string playerName = player.Name;
                            string playerShirtNum = player.ShirtNumber.ToString();
                            string playerPosition = player.Position.ToString();
                            string playerCaptain = player.Captain.ToString();
                            string[] values = { playerName, playerShirtNum, playerPosition, playerCaptain };
                            ListViewItem item = new ListViewItem(values, 3);

                            string imagePath = Path.Combine(Application.StartupPath, "ProfilePictures", $"{playerName}.png");
                            if (File.Exists(imagePath))
                            {
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    Image image = Image.FromStream(fs);
                                    imageList.Images.Add(image);
                                    item.ImageIndex = imageList.Images.Count - 1;
                                    fs.Close();
                                }
                                
                            }

                            lvAllPlayers.Items.Add(item);
                        }
                    }
                }
            }
            else if (Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                imageList = Helper.GetImageListDefault(pathToImagesFolder);

                foreach (KeyValuePair<string, SortedSet<Player>> pair in Wsf.WomenPlayers)
                {
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {
                            string playerName = player.Name;
                            string playerShirtNum = player.ShirtNumber.ToString();
                            string playerPosition = player.Position.ToString();
                            string playerCaptain = player.Captain.ToString();
                            string[] values = { playerName, playerShirtNum, playerPosition, playerCaptain };
                            ListViewItem item = new ListViewItem(values, 0);

                            string imagePath = Path.Combine(Application.StartupPath, "ProfilePictures", $"{playerName}.png");
                            if (File.Exists(imagePath))
                            {
                                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                {
                                    Image image = Image.FromStream(fs);
                                    imageList.Images.Add(image);
                                    item.ImageIndex = imageList.Images.Count - 1;
                                    fs.Close();
                                }
                            }

                            lvAllPlayers.Items.Add(item);
                        }
                    }
                }
            }
            else
            {
                imageList = Helper.GetImageListDefault(pathToImagesFolder);
            }

            lvAllPlayers.SmallImageList = imageList;
            lvAllPlayers.Refresh();

        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                Wsf.dataManager.LoadLocalFavorites(controlsFavorites, 'm');
            }
            else if (Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                Wsf.dataManager.LoadLocalFavorites(controlsFavorites, 'f');
            }
        }

        private async void CbChooseRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvAllPlayers.Items.Clear();
            LoadPlayersListView();
        }


        private void lvAllPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private async void pnlRepPlayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                await Wsf.dataManager.SaveLocalFavorites(controlsFavorites, 'm');
            }
            else if (Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                await Wsf.dataManager.SaveLocalFavorites(controlsFavorites, 'f');
            }

        }

        private void LoadControls()
        {
            if (!controlsFavorites.ContainsKey("cbChooseRep"))
            {
                controlsFavorites.Add("cbChooseRep", cbChooseRep);
            }
            if (!controlsFavorites.ContainsKey("lvAllPlayers"))
            {
                controlsFavorites.Add("lvAllPlayers", lvAllPlayers);
            }
            if (!controlsFavorites.ContainsKey("lvFavoritePlayers"))
            {
                controlsFavorites.Add("lvFavoritePlayers", lvFavoritePlayers);
            }
        }

        private void lvFavoritePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFavoritePlayers.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvFavoritePlayers.SelectedItems[0];
                lvFavoritePlayers.Items.Remove(selected);
            }
        }

        //All players Drag and drop

        private void lvAllPlayers_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvAllPlayers.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        //Favorites Drag and Drop

        private void lvFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            // Get the image list for default images
            ImageList imageListDefault = Helper.GetImageListDefault(pathToImagesFolder);
            
            // Get the image list for changed images
            ImageList imageListChanged = new ImageList();
            string profilePicDirPath = Path.Combine(Application.StartupPath, "ProfilePictures");
            string[] profileImagePaths = Directory.GetFiles(profilePicDirPath);
            if (Directory.Exists(profilePicDirPath))
            {
                imageListChanged = Helper.GetImageList();
            }
            
            // Combine the two image lists
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 50);
            string[] imagePaths = Directory.GetFiles(pathToImagesFolder);

            foreach (string imgPath in imagePaths)
            {
                Image img = Image.FromFile(imgPath);
                string imageName = Path.GetFileNameWithoutExtension(imgPath); // Get the file name without extension
                MessageBox.Show(imageName);
                imageList.Images.Add(imageName, img); // Add the image to the list with the file name as key
            }

            foreach (string imgPath in profileImagePaths)
            {
                Image img = Image.FromFile(imgPath);
                string imageName = Path.GetFileNameWithoutExtension(imgPath); // Get the file name without extension
                MessageBox.Show(imageName);
                imageList.Images.Add(imageName, img); // Add the image to the list with the file name as key
            }



            // Set the image list for the ListView
            lvFavoritePlayers.SmallImageList = imageList;
            
            // Refresh the ListView
            lvFavoritePlayers.Refresh();
            
            // Get the dropped item
            ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            
            // Check if the item is already in the favorites list
            bool itemExists = false;
            if (lvFavoritePlayers.Items.Count < 3)
            {
                foreach (ListViewItem existingItem in lvFavoritePlayers.Items)
                {
                    if (existingItem.Text == item.Text)
                    {
                        itemExists = true;
                        MessageBox.Show("Player already in Favorites!");
                        break;
                    }
                }
            
                if (!itemExists)
                {
                    // Add the item to the favorites list
                    ListViewItem newItem = (ListViewItem)item.Clone();

                    MessageBox.Show(newItem.ImageKey.ToString());
                    MessageBox.Show(imageListDefault.Images.ContainsKey(item.ImageKey).ToString());
                    MessageBox.Show(imageListChanged.Images.ContainsKey(item.ImageKey).ToString());
                    // Set the image index for the item
                    if (imageListDefault.Images.ContainsKey(item.ImageKey))
                    {
                        newItem.ImageKey = item.ImageKey;
                        lvFavoritePlayers.Items.Add(newItem);
                    }
                    else if (imageListChanged.Images.ContainsKey(item.ImageKey))
                    {
                       
                        newItem.ImageIndex = item.ImageIndex + imageListDefault.Images.Count;
                        lvFavoritePlayers.Items.Add(newItem);

                    }

                    //MessageBox.Show(imageListDefault.Images.Count.ToString());
                    //MessageBox.Show(imageListChanged.Images.Count.ToString());


                    // Refresh the ListView
                    lvFavoritePlayers.Refresh();
                }
              
            }
            else
            {
                MessageBox.Show("You can only choose 3 Favorite Players!");
            }
        }
    

        private void btnRankings_Click(object sender, EventArgs e)
        {

        }

        private void lvAllPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenuChangePfP = new ContextMenuStrip();
            contextMenuChangePfP.Items.Add("Change Profile Picture...", null, ChangeProfilePictureMenuItem_Click);
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem clickedItem = lvAllPlayers.GetItemAt(e.X, e.Y);

                if (clickedItem != null)
                {
                    lvAllPlayers.SelectedItems.Clear();
                    clickedItem.Selected = true;

                    contextMenuChangePfP.Show(lvAllPlayers, e.Location);
                }
            }
        }

        private void ChangeProfilePictureMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ListViewItem selectedItem = lvAllPlayers.SelectedItems[0];

                //ako slika postoji
                if (File.Exists(openFileDialog.FileName))
                {
                    // sejvaj sliku sa nazivom od name
                    string imageName = $"{selectedItem.SubItems[0].Text}.png";
                    string imagePath = Path.Combine(Application.StartupPath, "ProfilePictures", imageName);

                    using (FileStream fs = new FileStream(imagePath, FileMode.Create,FileAccess.Write))
                    {
                        openFileDialog.OpenFile().CopyTo(fs);
                        fs.Close();
                    }
                    
                    int newIconIndex = AddImageToImageListAndGetIndex(imagePath, lvAllPlayers.SmallImageList);

                    // Updejtaj index imagea
                    selectedItem.ImageIndex = newIconIndex;
                    selectedItem.Tag = imagePath;

                }
                else
                {
                    MessageBox.Show("The selected image file does not exist.");
                }
            }
        }

        private int AddImageToImageListAndGetIndex(string imagePath, ImageList imageList)
        {
            int index = -1;
            if (File.Exists(imagePath))
            {
                string imageName = Path.GetFileName(imagePath);
                string imageDirPath = Path.Combine(Application.StartupPath, "ProfilePictures");
                string imageFilePath = Path.Combine(imageDirPath, imageName);

                // Copy the image to the profile pictures directory if it doesn't already exist
                if (!File.Exists(imageFilePath))
                {
                    Directory.CreateDirectory(imageDirPath);
                    File.Copy(imagePath, imageFilePath);
                }

                // Load the image from file and add it to the image list
                Image image = Image.FromFile(imageFilePath);
                index = imageList.Images.Count;
                imageList.Images.Add(image);
            }
            return index;
        }
        
    }
}
