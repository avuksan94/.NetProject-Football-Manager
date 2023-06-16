namespace FootballManagerFormsApp
{
    partial class Rankings
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
            this.lbAttendenceRanking = new System.Windows.Forms.Label();
            this.lvDisplayAttendenceRankings = new System.Windows.Forms.ListView();
            this.chLocation = new System.Windows.Forms.ColumnHeader();
            this.chAttendence = new System.Windows.Forms.ColumnHeader();
            this.chHomeTeam = new System.Windows.Forms.ColumnHeader();
            this.chAwayTeam = new System.Windows.Forms.ColumnHeader();
            this.lbPlayerRankings = new System.Windows.Forms.Label();
            this.flpAllPLayers = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOrderRankingBy = new System.Windows.Forms.ComboBox();
            this.bwOrderRankings = new System.ComponentModel.BackgroundWorker();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btnPrintRankings = new System.Windows.Forms.Button();
            this.pdPrintRankings = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // lbAttendenceRanking
            // 
            this.lbAttendenceRanking.AutoSize = true;
            this.lbAttendenceRanking.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbAttendenceRanking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbAttendenceRanking.Location = new System.Drawing.Point(84, 18);
            this.lbAttendenceRanking.Name = "lbAttendenceRanking";
            this.lbAttendenceRanking.Size = new System.Drawing.Size(312, 37);
            this.lbAttendenceRanking.TabIndex = 1;
            this.lbAttendenceRanking.Text = "Rankings per Attendence";
            // 
            // lvDisplayAttendenceRankings
            // 
            this.lvDisplayAttendenceRankings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLocation,
            this.chAttendence,
            this.chHomeTeam,
            this.chAwayTeam});
            this.lvDisplayAttendenceRankings.Location = new System.Drawing.Point(21, 70);
            this.lvDisplayAttendenceRankings.Name = "lvDisplayAttendenceRankings";
            this.lvDisplayAttendenceRankings.Size = new System.Drawing.Size(598, 419);
            this.lvDisplayAttendenceRankings.TabIndex = 2;
            this.lvDisplayAttendenceRankings.UseCompatibleStateImageBehavior = false;
            // 
            // chLocation
            // 
            this.chLocation.Text = "Location";
            this.chLocation.Width = 200;
            // 
            // chAttendence
            // 
            this.chAttendence.Text = "Attendence";
            this.chAttendence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAttendence.Width = 120;
            // 
            // chHomeTeam
            // 
            this.chHomeTeam.Text = "Home Team";
            this.chHomeTeam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHomeTeam.Width = 120;
            // 
            // chAwayTeam
            // 
            this.chAwayTeam.Text = "Away Team";
            this.chAwayTeam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAwayTeam.Width = 120;
            // 
            // lbPlayerRankings
            // 
            this.lbPlayerRankings.AutoSize = true;
            this.lbPlayerRankings.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPlayerRankings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbPlayerRankings.Location = new System.Drawing.Point(677, 18);
            this.lbPlayerRankings.Name = "lbPlayerRankings";
            this.lbPlayerRankings.Size = new System.Drawing.Size(203, 37);
            this.lbPlayerRankings.TabIndex = 7;
            this.lbPlayerRankings.Text = "Player Rankings";
            // 
            // flpAllPLayers
            // 
            this.flpAllPLayers.AutoScroll = true;
            this.flpAllPLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.flpAllPLayers.Location = new System.Drawing.Point(677, 70);
            this.flpAllPLayers.Name = "flpAllPLayers";
            this.flpAllPLayers.Size = new System.Drawing.Size(701, 602);
            this.flpAllPLayers.TabIndex = 8;
            // 
            // cbOrderRankingBy
            // 
            this.cbOrderRankingBy.FormattingEnabled = true;
            this.cbOrderRankingBy.Items.AddRange(new object[] {
            "Goals - (Golovi)",
            "Yellow Cards - (Zuti kartoni)",
            "Appereances - (Pojavljivanja)"});
            this.cbOrderRankingBy.Location = new System.Drawing.Point(919, 27);
            this.cbOrderRankingBy.Name = "cbOrderRankingBy";
            this.cbOrderRankingBy.Size = new System.Drawing.Size(248, 28);
            this.cbOrderRankingBy.TabIndex = 9;
            this.cbOrderRankingBy.SelectedIndexChanged += new System.EventHandler(this.cbOrderRankingBy_SelectedIndexChanged);
            // 
            // bwOrderRankings
            // 
            this.bwOrderRankings.WorkerReportsProgress = true;
            this.bwOrderRankings.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwOrderRankings_DoWork);
            this.bwOrderRankings.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwOrderRankings_ProgressChanged);
            this.bwOrderRankings.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwOrderRankings_RunWorkerCompleted);
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lbProgress.Location = new System.Drawing.Point(1149, 18);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 37);
            this.lbProgress.TabIndex = 10;
            // 
            // btnPrintRankings
            // 
            this.btnPrintRankings.Location = new System.Drawing.Point(239, 526);
            this.btnPrintRankings.Name = "btnPrintRankings";
            this.btnPrintRankings.Size = new System.Drawing.Size(157, 62);
            this.btnPrintRankings.TabIndex = 11;
            this.btnPrintRankings.Text = "Print Rankings";
            this.btnPrintRankings.UseVisualStyleBackColor = true;
            this.btnPrintRankings.Click += new System.EventHandler(this.btnPrintRankings_Click);
            // 
            // pdPrintRankings
            // 
            this.pdPrintRankings.DocumentName = "Rankings";
            this.pdPrintRankings.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPrintRankings_PrintPage);
            // 
            // Rankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.btnPrintRankings);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.cbOrderRankingBy);
            this.Controls.Add(this.flpAllPLayers);
            this.Controls.Add(this.lbPlayerRankings);
            this.Controls.Add(this.lvDisplayAttendenceRankings);
            this.Controls.Add(this.lbAttendenceRanking);
            this.Name = "Rankings";
            this.Text = "Rankings";
            this.Load += new System.EventHandler(this.Rankings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbAttendenceRanking;
        private ListView lvDisplayAttendenceRankings;
        private ColumnHeader chLocation;
        private ColumnHeader chAttendence;
        private ColumnHeader chHomeTeam;
        private ColumnHeader chAwayTeam;
        private Label lbPlayerRankings;
        private FlowLayoutPanel flpAllPLayers;
        private ComboBox cbOrderRankingBy;
        private System.ComponentModel.BackgroundWorker bwOrderRankings;
        private Label lbProgress;
        private Button btnPrintRankings;
        private System.Drawing.Printing.PrintDocument pdPrintRankings;
    }
}