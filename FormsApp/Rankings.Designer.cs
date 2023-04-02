namespace FormsApp
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
            this.lbPlayerRanking = new System.Windows.Forms.Label();
            this.lbGameRanking = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbPlayerRanking
            // 
            this.lbPlayerRanking.AutoSize = true;
            this.lbPlayerRanking.Location = new System.Drawing.Point(156, 33);
            this.lbPlayerRanking.Name = "lbPlayerRanking";
            this.lbPlayerRanking.Size = new System.Drawing.Size(106, 20);
            this.lbPlayerRanking.TabIndex = 0;
            this.lbPlayerRanking.Text = "Player Ranking";
            // 
            // lbGameRanking
            // 
            this.lbGameRanking.AutoSize = true;
            this.lbGameRanking.Location = new System.Drawing.Point(775, 33);
            this.lbGameRanking.Name = "lbGameRanking";
            this.lbGameRanking.Size = new System.Drawing.Size(105, 20);
            this.lbGameRanking.TabIndex = 1;
            this.lbGameRanking.Text = "Game Ranking";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(25, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(408, 439);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(599, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(408, 444);
            this.listBox1.TabIndex = 3;
            // 
            // Rankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 523);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbGameRanking);
            this.Controls.Add(this.lbPlayerRanking);
            this.Name = "Rankings";
            this.Text = "Rankings";
            this.Load += new System.EventHandler(this.Rankings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbPlayerRanking;
        private Label lbGameRanking;
        private ListView listView1;
        private ListBox listBox1;
    }
}