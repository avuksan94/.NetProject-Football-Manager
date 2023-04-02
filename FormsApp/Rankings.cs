using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Rankings : Form
    {
        private WelcomeScreenForm Wsf;
        public Dictionary<string, Control> controlsRankings = new Dictionary<string, Control>();
        public Rankings()
        {
            InitializeComponent();
        }

        private void Rankings_Load(object sender, EventArgs e)
        {

        }
    }
}
