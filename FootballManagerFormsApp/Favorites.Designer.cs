namespace FootballManagerFormsApp
{
    partial class Favorites
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
            this.lbChooseRep = new System.Windows.Forms.Label();
            this.cbChooseRep = new System.Windows.Forms.ComboBox();
            this.flpAllPLayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.lbFavoritePlayers = new System.Windows.Forms.Label();
            this.progBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbChooseRep
            // 
            this.lbChooseRep.AutoSize = true;
            this.lbChooseRep.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChooseRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbChooseRep.Location = new System.Drawing.Point(12, 23);
            this.lbChooseRep.Name = "lbChooseRep";
            this.lbChooseRep.Size = new System.Drawing.Size(345, 37);
            this.lbChooseRep.TabIndex = 3;
            this.lbChooseRep.Text = "Choose your representation";
            // 
            // cbChooseRep
            // 
            this.cbChooseRep.Enabled = false;
            this.cbChooseRep.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbChooseRep.FormattingEnabled = true;
            this.cbChooseRep.Location = new System.Drawing.Point(12, 77);
            this.cbChooseRep.Name = "cbChooseRep";
            this.cbChooseRep.Size = new System.Drawing.Size(189, 31);
            this.cbChooseRep.TabIndex = 4;
            this.cbChooseRep.Text = "Choose";
            this.cbChooseRep.SelectedIndexChanged += new System.EventHandler(this.cbChooseRep_SelectedIndexChanged);
            // 
            // flpAllPLayers
            // 
            this.flpAllPLayers.AllowDrop = true;
            this.flpAllPLayers.AutoScroll = true;
            this.flpAllPLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.flpAllPLayers.Location = new System.Drawing.Point(12, 139);
            this.flpAllPLayers.Name = "flpAllPLayers";
            this.flpAllPLayers.Size = new System.Drawing.Size(599, 602);
            this.flpAllPLayers.TabIndex = 5;
            this.flpAllPLayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpAllPLayers_DragDrop);
            // 
            // flpFavoritePlayers
            // 
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.AutoScroll = true;
            this.flpFavoritePlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.flpFavoritePlayers.Location = new System.Drawing.Point(654, 139);
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.Size = new System.Drawing.Size(599, 347);
            this.flpFavoritePlayers.TabIndex = 6;
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            // 
            // lbFavoritePlayers
            // 
            this.lbFavoritePlayers.AutoSize = true;
            this.lbFavoritePlayers.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFavoritePlayers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbFavoritePlayers.Location = new System.Drawing.Point(654, 87);
            this.lbFavoritePlayers.Name = "lbFavoritePlayers";
            this.lbFavoritePlayers.Size = new System.Drawing.Size(182, 37);
            this.lbFavoritePlayers.TabIndex = 7;
            this.lbFavoritePlayers.Text = "Your Favorites";
            // 
            // progBar1
            // 
            this.progBar1.Location = new System.Drawing.Point(511, 77);
            this.progBar1.Name = "progBar1";
            this.progBar1.Size = new System.Drawing.Size(100, 29);
            this.progBar1.TabIndex = 8;
            // 
            // Favorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.progBar1);
            this.Controls.Add(this.lbFavoritePlayers);
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpAllPLayers);
            this.Controls.Add(this.cbChooseRep);
            this.Controls.Add(this.lbChooseRep);
            this.Name = "Favorites";
            this.Text = "Favorites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Favorites_FormClosing);
            this.Load += new System.EventHandler(this.Favorites_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbChooseRep;
        private ComboBox cbChooseRep;
        private FlowLayoutPanel flpAllPLayers;
        private FlowLayoutPanel flpFavoritePlayers;
        private Label lbFavoritePlayers;
        private ProgressBar progBar1;
    }
}