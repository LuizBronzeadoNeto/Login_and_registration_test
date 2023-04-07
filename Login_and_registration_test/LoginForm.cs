using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Login_and_registration_test
{
    public partial class LoginForm : Form
    {
        public static LoginForm instance; // with this I can access variables from this form  in other forms
        public TextBox TbUser;
        public LoginForm()
        {
            InitializeComponent();
        }
        

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb"); //initializing database
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpter = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open(); //Opening connection to fetch information from database
            string login = "SELECT * FROM UserTable WHERE username= '" + TxtUsername.Text + "' and password= '" + TxtPassword.Text + "'";
            cmd = new OleDbCommand(login, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                dashboard form = new dashboard(); //username welcome label 
                form.user = TxtUsername.Text;
                form.ShowDialog();
                new dashboard().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid username and/or password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUsername.Text = "";
                TxtPassword.Text = "";
                TxtUsername.Focus();
                conn.Close(); //closing connection so it may be restarted
            }
        }

        private void button2_Click(object sender, EventArgs e) // clear text
        {
            TxtUsername.Text = "";
            TxtPassword.Text = "";
            TxtUsername.Focus();
        }

        private void label5_Click(object sender, EventArgs e) // Open sign up form
        {
            new frmRegister().Show();
            this.Close();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e) //Hide password
        {
            if (checkBxShowPass.Checked)
            {
                TxtPassword.PasswordChar = '\0';
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
