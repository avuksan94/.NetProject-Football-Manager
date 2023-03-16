﻿using System;
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
using static System.Formats.Asn1.AsnWriter;

namespace FormsApp
{
    public partial class pnlRepPlayers : Form
    {
        private WelcomeScreenForm Wsf;
        //private SortedSet<Player> allPlayers;

        public pnlRepPlayers(ResourceManager resourceManager,WelcomeScreenForm wsf)
        {
            InitializeComponent();
            lbChooseRep.Text = resourceManager.GetString("lbChooseRep");
            cbChooseRep.Text = resourceManager.GetString("cbChooseRep");
            this.Wsf= wsf;

            List<TeamResult> menSortedList = Wsf.MenRes.ToList();
            menSortedList.Sort();
            List<TeamResult> womenSortedList = Wsf.WomenRes.ToList();
            womenSortedList.Sort();

            LoadTeamResults(menSortedList, womenSortedList);
        }

        private void LoadTeamResults(List<TeamResult> menSortedList, List<TeamResult> womenSortedList)
        {
            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                cbChooseRep.Items.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (TeamResult item in menSortedList)
                {
                    sb.Clear();
                    sb.Append(item.Country);
                    sb.Append(" ");
                    sb.Append(item.FifaCode);
                    cbChooseRep.Items.Add(sb.ToString());
                }
                cbChooseRep.Refresh();
            }
            else if (Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                cbChooseRep.Items.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (TeamResult item in womenSortedList)
                {
                    sb.Clear();
                    sb.Append(item.Country);
                    sb.Append(" ");
                    sb.Append(item.FifaCode);
                    cbChooseRep.Items.Add(sb.ToString());
                }
                cbChooseRep.Refresh();
            }
        }

        private void LoadPlayers() 
        {
            lboxRepAllPlayers.Refresh();
            string selectedItem = cbChooseRep.SelectedItem.ToString();
            string selectedCountry = selectedItem.Split(' ')[0];

        
            if (Wsf.SelectedComboBoxValue == "Male" || Wsf.SelectedComboBoxValue == "Muški")
            {
                foreach (KeyValuePair<string, SortedSet<Player>> pair in Wsf.MenPlayers)
                {
        
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {
                            lboxRepAllPlayers.Items.Add(player);
                        }
                    }
                }
            }
            else if(Wsf.SelectedComboBoxValue == "Female" || Wsf.SelectedComboBoxValue == "Ženski")
            {
                foreach (KeyValuePair<string, SortedSet<Player>> pair in Wsf.WomenPlayers)
                {
        
                    if (pair.Key.Contains(selectedCountry))
                    {
                        foreach (Player player in pair.Value)
                        {
                            lboxRepAllPlayers.Items.Add(player);
                            
                        }
                    }
                }
            }
           
        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void CbChooseRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxRepAllPlayers.DisplayMember = "Name";
            lboxRepAllPlayers.Items.Clear();
            LoadPlayers();
        }

        private void lboxRepAllPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selectedPlayer = lboxRepAllPlayers.SelectedItem as Player;
          
             if (!lboxRepFavorites.Items.Contains(selectedPlayer))
             {
                 lboxRepFavorites.Items.Add(selectedPlayer);
             }
             else
             {
                 MessageBox.Show("Player is already in Favorites!!");
             }
        }

        private void lboxRepFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = lboxRepFavorites.SelectedItem;
            lboxRepFavorites.Items.Remove(selectedItem);
        }

        private void lboxRepFavorites_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((Player)e.ListItem).Name.ToString();
            string shirtNum = ((Player)e.ListItem).ShirtNumber.ToString();
            string position = ((Player)e.ListItem).Position.ToString();
            string captain = ((Player)e.ListItem).Captain ? "Yes" : "No";

            StringBuilder sb = new StringBuilder();
            sb.Append(name + "    ");
            sb.Append(shirtNum + "    ");
            sb.Append(position + "    ");
            sb.Append(captain + "    ");

            string text = sb.ToString();

            e.Value = text;
        }
    }
}
