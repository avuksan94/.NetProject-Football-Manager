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
            this.lboxRepAllPlayers = new System.Windows.Forms.ListBox();
            this.lboxRepFavorites = new System.Windows.Forms.ListBox();
            this.lbFavorites = new System.Windows.Forms.Label();
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
            // lboxRepAllPlayers
            // 
            this.lboxRepAllPlayers.AllowDrop = true;
            this.lboxRepAllPlayers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lboxRepAllPlayers.FormattingEnabled = true;
            this.lboxRepAllPlayers.ItemHeight = 20;
            this.lboxRepAllPlayers.Location = new System.Drawing.Point(11, 107);
            this.lboxRepAllPlayers.Name = "lboxRepAllPlayers";
            this.lboxRepAllPlayers.Size = new System.Drawing.Size(331, 484);
            this.lboxRepAllPlayers.TabIndex = 2;
            this.lboxRepAllPlayers.SelectedIndexChanged += new System.EventHandler(this.lboxRepAllPlayers_SelectedIndexChanged);
            // 
            // lboxRepFavorites
            // 
            this.lboxRepFavorites.AllowDrop = true;
            this.lboxRepFavorites.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lboxRepFavorites.FormattingEnabled = true;
            this.lboxRepFavorites.ItemHeight = 20;
            this.lboxRepFavorites.Location = new System.Drawing.Point(370, 107);
            this.lboxRepFavorites.Name = "lboxRepFavorites";
            this.lboxRepFavorites.Size = new System.Drawing.Size(861, 484);
            this.lboxRepFavorites.TabIndex = 3;
            this.lboxRepFavorites.SelectedIndexChanged += new System.EventHandler(this.lboxRepFavorites_SelectedIndexChanged);
            this.lboxRepFavorites.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lboxRepFavorites_Format);
            // 
            // lbFavorites
            // 
            this.lbFavorites.AutoSize = true;
            this.lbFavorites.Location = new System.Drawing.Point(370, 84);
            this.lbFavorites.Name = "lbFavorites";
            this.lbFavorites.Size = new System.Drawing.Size(112, 20);
            this.lbFavorites.TabIndex = 4;
            this.lbFavorites.Text = "Favorite players";
            // 
            // pnlRepPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 618);
            this.Controls.Add(this.lbFavorites);
            this.Controls.Add(this.lboxRepFavorites);
            this.Controls.Add(this.lboxRepAllPlayers);
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
        private ListBox lboxRepAllPlayers;
        private ListBox lboxRepFavorites;
        private Label lbFavorites;
    }
}