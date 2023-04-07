using System.Data.OleDb;
namespace Login_and_registration_test
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }


        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb"); //initializing database
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adpter = new OleDbDataAdapter();


        private void frmRegister_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // should the inputs be left empty:
            if(String.IsNullOrEmpty(TxtUsername.Text) && String.IsNullOrEmpty(TxtComPassword.Text) && String.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("Username and Password fields are empty!", "Cannot sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //check if passwords match
            else if (TxtPassword.Text == TxtComPassword.Text)
            {
                conn.Open(); // opening connection with database

                string Register = "INSERT INTO UserTable VALUES ('" + TxtUsername.Text + "', '" + TxtPassword.Text + "')"; // inserting the user input into UserTable
                cmd = new OleDbCommand(Register, conn);
                cmd.ExecuteNonQuery();

                conn.Close(); //closing connection
                
                MessageBox.Show("Account successfully created", "Sign up successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TxtUsername.Text = "";
                TxtPassword.Text = "";
                TxtComPassword.Text = "";

                new LoginForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Passwords do not match, please re-enter", "Cannot sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Text = "";
                TxtComPassword.Text = "";
                TxtPassword.Focus();
            }
        }


        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                TxtPassword.PasswordChar = '\0';
                TxtComPassword.PasswordChar = '\0';
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
                TxtComPassword.UseSystemPasswordChar= true;

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TxtUsername.Text = "";
            TxtPassword.Text = "";
            TxtComPassword.Text = "";
        }

        private void label5_Click(object sender, EventArgs e) //Switching to login form
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}