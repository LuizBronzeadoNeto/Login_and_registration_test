using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_and_registration_test
{
    public partial class dashboard : Form
    {
        public string user { get; set; }
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/luiz-bronzeado-neto-64218126b/");
        }

        private void GitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LuizBronzeadoNeto");
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = $"Welcome, {user}!";
        }
    }
}
