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

namespace PP_GUI
{
    public partial class Login : Form
    {
        public string username { get; private set; }
        private OleDbConnection connection = new OleDbConnection();
        public Login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\University\Year 2\CS2S567 Professional Practice & Employability\Team Work\GUI\OronicoEmployees.accdb;
Persist Security Info=False;";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                lbl_checkDatabaseConnection.Text = "Connection Successful (just for testing)";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Login where Username='"+txtUser.Text+"' and Password='"+txtPass.Text+"'";
            

            //if statements to say if somebody is from a specfic department (read from the database) then hide the buttons they don't have access to.


           OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count++;
            }

            if (count == 1)
            {
                username = txtUser.Text;
                Hide();
                Form1 f1 = new Form1(this);
                f1.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password!");
            }
           else
            {
                MessageBox.Show("Incorrect Password or Username!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            connection.Close(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
