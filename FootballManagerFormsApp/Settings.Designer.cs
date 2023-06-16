namespace FootballManagerFormsApp
{
    partial class Settings
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
            this.cbChooseMF = new System.Windows.Forms.ComboBox();
            this.lbChooseMF = new System.Windows.Forms.Label();
            this.lbChooseYourLanguage = new System.Windows.Forms.Label();
            this.cbChooseLanguage = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbChooseMF
            // 
            this.cbChooseMF.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbChooseMF.FormattingEnabled = true;
            this.cbChooseMF.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbChooseMF.Location = new System.Drawing.Point(297, 261);
            this.cbChooseMF.Name = "cbChooseMF";
            this.cbChooseMF.Size = new System.Drawing.Size(189, 45);
            this.cbChooseMF.TabIndex = 8;
            this.cbChooseMF.Text = "Choose";
            this.cbChooseMF.SelectedIndexChanged += new System.EventHandler(this.cbChooseMF_SelectedIndexChanged);
            // 
            // lbChooseMF
            // 
            this.lbChooseMF.AutoSize = true;
            this.lbChooseMF.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChooseMF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbChooseMF.Location = new System.Drawing.Point(251, 198);
            this.lbChooseMF.Name = "lbChooseMF";
            this.lbChooseMF.Size = new System.Drawing.Size(298, 37);
            this.lbChooseMF.TabIndex = 7;
            this.lbChooseMF.Text = "Change Male or Female";
            // 
            // lbChooseYourLanguage
            // 
            this.lbChooseYourLanguage.AutoSize = true;
            this.lbChooseYourLanguage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChooseYourLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbChooseYourLanguage.Location = new System.Drawing.Point(282, 24);
            this.lbChooseYourLanguage.Name = "lbChooseYourLanguage";
            this.lbChooseYourLanguage.Size = new System.Drawing.Size(232, 37);
            this.lbChooseYourLanguage.TabIndex = 6;
            this.lbChooseYourLanguage.Text = "Change Language";
            // 
            // cbChooseLanguage
            // 
            this.cbChooseLanguage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbChooseLanguage.FormattingEnabled = true;
            this.cbChooseLanguage.Items.AddRange(new object[] {
            "ENG",
            "HRV"});
            this.cbChooseLanguage.Location = new System.Drawing.Point(297, 86);
            this.cbChooseLanguage.Name = "cbChooseLanguage";
            this.cbChooseLanguage.Size = new System.Drawing.Size(189, 45);
            this.cbChooseLanguage.TabIndex = 5;
            this.cbChooseLanguage.Text = "Choose";
            this.cbChooseLanguage.SelectedIndexChanged += new System.EventHandler(this.cbChooseLanguage_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(89, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(276, 70);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Save";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(436, 353);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(276, 70);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbChooseMF);
            this.Controls.Add(this.lbChooseMF);
            this.Controls.Add(this.lbChooseYourLanguage);
            this.Controls.Add(this.cbChooseLanguage);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbChooseMF;
        private Label lbChooseMF;
        private Label lbChooseYourLanguage;
        private ComboBox cbChooseLanguage;
        private Button btnClose;
        private Button btnExit;
    }
}