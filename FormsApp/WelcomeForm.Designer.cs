namespace FormsApp
{
    partial class WelcomeScreenForm
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
            this.lbChooseYourLanguage = new System.Windows.Forms.Label();
            this.cbChooseLanguage = new System.Windows.Forms.ComboBox();
            this.lbChooseMF = new System.Windows.Forms.Label();
            this.cbChooseMF = new System.Windows.Forms.ComboBox();
            this.lbOwnerName = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbChooseYourLanguage
            // 
            this.lbChooseYourLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbChooseYourLanguage.AutoSize = true;
            this.lbChooseYourLanguage.Location = new System.Drawing.Point(603, 217);
            this.lbChooseYourLanguage.Name = "lbChooseYourLanguage";
            this.lbChooseYourLanguage.Size = new System.Drawing.Size(203, 20);
            this.lbChooseYourLanguage.TabIndex = 0;
            this.lbChooseYourLanguage.Text = "Please Choose your language";
            // 
            // cbChooseLanguage
            // 
            this.cbChooseLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbChooseLanguage.FormattingEnabled = true;
            this.cbChooseLanguage.Items.AddRange(new object[] {
            "ENG",
            "HRV"});
            this.cbChooseLanguage.Location = new System.Drawing.Point(615, 250);
            this.cbChooseLanguage.Name = "cbChooseLanguage";
            this.cbChooseLanguage.Size = new System.Drawing.Size(191, 28);
            this.cbChooseLanguage.TabIndex = 1;
            this.cbChooseLanguage.Text = "Choose";
            this.cbChooseLanguage.SelectedIndexChanged += new System.EventHandler(this.cbChooseLanguage_SelectedIndexChanged);
            // 
            // lbChooseMF
            // 
            this.lbChooseMF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbChooseMF.AutoSize = true;
            this.lbChooseMF.Location = new System.Drawing.Point(608, 341);
            this.lbChooseMF.Name = "lbChooseMF";
            this.lbChooseMF.Size = new System.Drawing.Size(168, 20);
            this.lbChooseMF.TabIndex = 2;
            this.lbChooseMF.Text = "Choose  Men or Women";
            // 
            // cbChooseMF
            // 
            this.cbChooseMF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbChooseMF.FormattingEnabled = true;
            this.cbChooseMF.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbChooseMF.Location = new System.Drawing.Point(612, 374);
            this.cbChooseMF.Name = "cbChooseMF";
            this.cbChooseMF.Size = new System.Drawing.Size(194, 28);
            this.cbChooseMF.TabIndex = 3;
            this.cbChooseMF.Text = "Choose";
            this.cbChooseMF.SelectedIndexChanged += new System.EventHandler(this.cbChooseMF_SelectedIndexChanged);
            // 
            // lbOwnerName
            // 
            this.lbOwnerName.AutoSize = true;
            this.lbOwnerName.Location = new System.Drawing.Point(19, 21);
            this.lbOwnerName.Name = "lbOwnerName";
            this.lbOwnerName.Size = new System.Drawing.Size(75, 20);
            this.lbOwnerName.TabIndex = 4;
            this.lbOwnerName.Text = "@avuksan";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(615, 469);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(191, 78);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // WelcomeScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 618);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lbOwnerName);
            this.Controls.Add(this.cbChooseMF);
            this.Controls.Add(this.lbChooseMF);
            this.Controls.Add(this.cbChooseLanguage);
            this.Controls.Add(this.lbChooseYourLanguage);
            this.Name = "WelcomeScreenForm";
            this.Text = "Welcome to the Football Manager app!";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbChooseYourLanguage;
        private ComboBox cbChooseLanguage;
        private Label lbChooseMF;
        private ComboBox cbChooseMF;
        private Label lbOwnerName;
        private Button btnNext;
    }
}