namespace FormsApp
{
    partial class pnlRepPlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbChooseRep = new System.Windows.Forms.ComboBox();
            this.lbChooseRep = new System.Windows.Forms.Label();
            this.lbFavorites = new System.Windows.Forms.Label();
            this.lbAllPlayers = new System.Windows.Forms.Label();
            this.lvAllPlayers = new System.Windows.Forms.ListView();
            this.lvFavoritePlayers = new System.Windows.Forms.ListView();
            this.btnRankings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbChooseRep
            // 
            this.cbChooseRep.FormattingEnabled = true;
            this.cbChooseRep.Location = new System.Drawing.Point(12, 57);
            this.cbChooseRep.Name = "cbChooseRep";
            this.cbChooseRep.Size = new System.Drawing.Size(231, 28);
            this.cbChooseRep.TabIndex = 0;
            this.cbChooseRep.Text = "Choose";
            this.cbChooseRep.SelectedIndexChanged += new System.EventHandler(this.CbChooseRep_SelectedIndexChanged);
            // 
            // lbChooseRep
            // 
            this.lbChooseRep.AutoSize = true;
            this.lbChooseRep.Location = new System.Drawing.Point(12, 24);
            this.lbChooseRep.Name = "lbChooseRep";
            this.lbChooseRep.Size = new System.Drawing.Size(195, 20);
            this.lbChooseRep.TabIndex = 1;
            this.lbChooseRep.Text = "Choose your Representation";
            // 
            // lbFavorites
            // 
            this.lbFavorites.AutoSize = true;
            this.lbFavorites.Location = new System.Drawing.Point(758, 117);
            this.lbFavorites.Name = "lbFavorites";
            this.lbFavorites.Size = new System.Drawing.Size(112, 20);
            this.lbFavorites.TabIndex = 4;
            this.lbFavorites.Text = "Favorite players";
            // 
            // lbAllPlayers
            // 
            this.lbAllPlayers.AutoSize = true;
            this.lbAllPlayers.Location = new System.Drawing.Point(223, 117);
            this.lbAllPlayers.Name = "lbAllPlayers";
            this.lbAllPlayers.Size = new System.Drawing.Size(78, 20);
            this.lbAllPlayers.TabIndex = 5;
            this.lbAllPlayers.Text = "All players";
            // 
            // lvAllPlayers
            // 
            this.lvAllPlayers.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lvAllPlayers.Location = new System.Drawing.Point(12, 140);
            this.lvAllPlayers.Name = "lvAllPlayers";
            this.lvAllPlayers.Size = new System.Drawing.Size(518, 466);
            this.lvAllPlayers.TabIndex = 6;
            this.lvAllPlayers.UseCompatibleStateImageBehavior = false;
            this.lvAllPlayers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvAllPlayers_ItemDrag);
            this.lvAllPlayers.SelectedIndexChanged += new System.EventHandler(this.lvAllPlayers_SelectedIndexChanged);
            this.lvAllPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvAllPlayers_MouseDown);
            // 
            // lvFavoritePlayers
            // 
            this.lvFavoritePlayers.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lvFavoritePlayers.Location = new System.Drawing.Point(554, 140);
            this.lvFavoritePlayers.Name = "lvFavoritePlayers";
            this.lvFavoritePlayers.Size = new System.Drawing.Size(518, 235);
            this.lvFavoritePlayers.TabIndex = 7;
            this.lvFavoritePlayers.UseCompatibleStateImageBehavior = false;
            this.lvFavoritePlayers.SelectedIndexChanged += new System.EventHandler(this.lvFavoritePlayers_SelectedIndexChanged);
            this.lvFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFavoritePlayers_DragDrop);
            this.lvFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFavoritePlayers_DragEnter);
            // 
            // btnRankings
            // 
            this.btnRankings.Location = new System.Drawing.Point(554, 403);
            this.btnRankings.Name = "btnRankings";
            this.btnRankings.Size = new System.Drawing.Size(146, 64);
            this.btnRankings.TabIndex = 8;
            this.btnRankings.Text = "See Rankings";
            this.btnRankings.UseVisualStyleBackColor = true;
            this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);
            // 
            // pnlRepPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 618);
            this.Controls.Add(this.btnRankings);
            this.Controls.Add(this.lvFavoritePlayers);
            this.Controls.Add(this.lvAllPlayers);
            this.Controls.Add(this.lbAllPlayers);
            this.Controls.Add(this.lbFavorites);
            this.Controls.Add(this.lbChooseRep);
            this.Controls.Add(this.cbChooseRep);
            this.Name = "pnlRepPlayers";
            this.Text = "Favorites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pnlRepPlayers_FormClosing);
            this.Load += new System.EventHandler(this.Favorites_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbChooseRep;
        private Label lbChooseRep;
        private Label lbFavorites;
        private Label lbAllPlayers;
        private ListView lvAllPlayers;
        private ListView lvFavoritePlayers;
        private Button btnRankings;
    }
}