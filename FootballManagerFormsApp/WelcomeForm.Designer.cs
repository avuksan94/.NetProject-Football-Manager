namespace FootballManagerFormsApp
{
    partial class WelcomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRankings = new System.Windows.Forms.Button();
            this.btnFavorites = new System.Windows.Forms.Button();
            this.lbFootballManager = new System.Windows.Forms.Label();
            this.cbChooseLanguage = new System.Windows.Forms.ComboBox();
            this.lbChooseYourLanguage = new System.Windows.Forms.Label();
            this.lbChooseMF = new System.Windows.Forms.Label();
            this.cbChooseMF = new System.Windows.Forms.ComboBox();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Controls.Add(this.lbAuthor);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnRankings);
            this.pnlMenu.Controls.Add(this.btnFavorites);
            this.pnlMenu.Controls.Add(this.lbFootballManager);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(299, 753);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(12, 609);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(276, 70);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbAuthor.Location = new System.Drawing.Point(12, 707);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(138, 37);
            this.lbAuthor.TabIndex = 4;
            this.lbAuthor.Text = "@avuksan";
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.Location = new System.Drawing.Point(11, 341);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(276, 70);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRankings
            // 
            this.btnRankings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRankings.Location = new System.Drawing.Point(12, 240);
            this.btnRankings.Name = "btnRankings";
            this.btnRankings.Size = new System.Drawing.Size(276, 70);
            this.btnRankings.TabIndex = 2;
            this.btnRankings.Text = "Rankings";
            this.btnRankings.UseVisualStyleBackColor = true;
            this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);
            // 
            // btnFavorites
            // 
            this.btnFavorites.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFavorites.Location = new System.Drawing.Point(12, 145);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Size = new System.Drawing.Size(276, 70);
            this.btnFavorites.TabIndex = 1;
            this.btnFavorites.Text = "Favorites";
            this.btnFavorites.UseVisualStyleBackColor = true;
            this.btnFavorites.Click += new System.EventHandler(this.btnFavorites_Click);
            // 
            // lbFootballManager
            // 
            this.lbFootballManager.AutoSize = true;
            this.lbFootballManager.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFootballManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbFootballManager.Location = new System.Drawing.Point(31, 9);
            this.lbFootballManager.Name = "lbFootballManager";
            this.lbFootballManager.Size = new System.Drawing.Size(228, 37);
            this.lbFootballManager.TabIndex = 0;
            this.lbFootballManager.Text = "Football Manager";
            // 
            // cbChooseLanguage
            // 
            this.cbChooseLanguage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbChooseLanguage.FormattingEnabled = true;
            this.cbChooseLanguage.Items.AddRange(new object[] {
            "ENG",
            "HRV"});
            this.cbChooseLanguage.Location = new System.Drawing.Point(690, 240);
            this.cbChooseLanguage.Name = "cbChooseLanguage";
            this.cbChooseLanguage.Size = new System.Drawing.Size(189, 45);
            this.cbChooseLanguage.TabIndex = 4;
            this.cbChooseLanguage.Text = "Choose";
            this.cbChooseLanguage.SelectedIndexChanged += new System.EventHandler(this.cbChooseLanguage_SelectedIndexChanged);
            // 
            // lbChooseYourLanguage
            // 
            this.lbChooseYourLanguage.AutoSize = true;
            this.lbChooseYourLanguage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChooseYourLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbChooseYourLanguage.Location = new System.Drawing.Point(644, 178);
            this.lbChooseYourLanguage.Name = "lbChooseYourLanguage";
            this.lbChooseYourLanguage.Size = new System.Drawing.Size(284, 37);
            this.lbChooseYourLanguage.TabIndex = 2;
            this.lbChooseYourLanguage.Text = "Choose your language";
            // 
            // lbChooseMF
            // 
            this.lbChooseMF.AutoSize = true;
            this.lbChooseMF.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChooseMF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbChooseMF.Location = new System.Drawing.Point(644, 352);
            this.lbChooseMF.Name = "lbChooseMF";
            this.lbChooseMF.Size = new System.Drawing.Size(295, 37);
            this.lbChooseMF.TabIndex = 3;
            this.lbChooseMF.Text = "Choose Male of Female";
            // 
            // cbChooseMF
            // 
            this.cbChooseMF.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbChooseMF.FormattingEnabled = true;
            this.cbChooseMF.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbChooseMF.Location = new System.Drawing.Point(690, 415);
            this.cbChooseMF.Name = "cbChooseMF";
            this.cbChooseMF.Size = new System.Drawing.Size(189, 45);
            this.cbChooseMF.TabIndex = 4;
            this.cbChooseMF.Text = "Choose";
            this.cbChooseMF.SelectedIndexChanged += new System.EventHandler(this.cbChooseMF_SelectedIndexChanged);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.cbChooseMF);
            this.Controls.Add(this.lbChooseMF);
            this.Controls.Add(this.lbChooseYourLanguage);
            this.Controls.Add(this.cbChooseLanguage);
            this.Controls.Add(this.pnlMenu);
            this.KeyPreview = true;
            this.Name = "WelcomeForm";
            this.Text = "Football Manager App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WelcomeForm_FormClosing);
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WelcomeForm_KeyDown);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlMenu;
        private Button btnSettings;
        private Button btnRankings;
        private Button btnFavorites;
        private Label lbFootballManager;
        private ComboBox cbChooseLanguage;
        private Label lbChooseYourLanguage;
        private Label lbAuthor;
        private Label lbChooseMF;
        private ComboBox cbChooseMF;
        private Button btnExit;
    }
}