using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Room_Management
{
    public partial class frmDatabase : Form
    {
        private DataTable dataTable = new DataTable();
        public frmDatabase()
        {
            InitializeComponent();
        }

        private void rowChange(object sender, EventArgs e)
        {
            if (sender == btnBack)
            {

            }
            else if (sender == btnNext)
            {

            }

        }

        private void frmDatabase_Load_1(object sender, EventArgs e)
        {
            //connection string
            string connectionString = 
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\RoomBooking.mdb;Persist Security Info = False;";
            //array of textboxes
            TextBox[] frmBoxes = { txtRoom, txtDate, txtTime, txtTeam }; 
            //create connection
            OleDbConnection sqlConnection1 = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM RESERVATIONS", sqlConnection1);
            //open connection
            sqlConnection1.Open();

            //making an adapter that fills a datatable i made
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dataTable);
            //safely close connection
            sqlConnection1.Close();
            da.Dispose();

            //fill form with database data
            int collumnCount = dataTable.Columns.Count;

            for (int i = 0; i < (collumnCount-1); i++)
            {
                frmBoxes[i].Text = (string)dataTable.Rows[0][i];

            }

            rtxtDescription.Text = (string)dataTable.Rows[0][4];
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
