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
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        Login _f1;
        public Form1(Login f1_)
        {
            
            InitializeComponent();
            this._f1 = f1_;
            lbl_username.Text = "User: " + this._f1.username;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\University\Year 2\CS2S567 Professional Practice & Employability\Team Work\GUI\OronicoEmployees.accdb;
Persist Security Info=False;";
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult Result1 = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result1 == DialogResult.Yes)
            {
                Hide();
                Login li1 = new Login();
                li1.ShowDialog();
            }
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select JobRole, DepartmentName from Employee where EmployeeID = '"+this._f1.username+"'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_role.Text = "Role: " + reader["JobRole"].ToString();
                lbl_department.Text = "Department: " + reader["DepartmentName"].ToString();
            }

            //Payroll
            if (lbl_department.Text == "Department: Payroll")
            {
                //insert what this department needs access to.
                btnPayroll.Enabled = true;
            }

            //Accounts
            if (lbl_department.Text == "Department: Accounts")
            {
                //Only team that has told us what people that work in thier respective department need access to.
                btnAccounts.Enabled = true;
                btnHoliday.Enabled = true;
                btnDocs.Enabled = true;
                btnCalendar.Enabled = true;
             //   btnBooking.Enabled = true; this will only be accessible if department is "account" and jobRole is "Team manager".
            }

            //Purchasing
            if (lbl_department.Text == "Department: Purchasing")
            {
                //insert what this department needs access to.
                btnPurchasing.Enabled = true;
            }

            //Calendar
            if (lbl_department.Text == "Department: Calendar")
            {
                //insert what this department needs access to.
                btnCalendar.Enabled = true;
            }

            //CRM/Invoicing
            if (lbl_department.Text == "Department: Invoicing")
            {
                //insert what this department needs access to.
                btnInvoicing.Enabled = true;
            }

            //ourBay
            if (lbl_department.Text == "Department: ourBay")
            {
                //insert what this department needs access to.
                btnOurBay.Enabled = true;
            }

            //Holiday
            if (lbl_department.Text == "Department: Holidays")
            {
                //insert what this department needs access to.
                btnHoliday.Enabled = true;
            }

            //Room Booking
            if (lbl_department.Text == "Department: Rooms")
            {
                //insert what this department needs access to.
                btnBooking.Enabled = true;
            }

            //Inventory
            if (lbl_department.Text == "Department: Inventory")
            {
                //insert what this department needs access to.
                btnInventory.Enabled = true;
            }

            //Stock
            if (lbl_department.Text == "Department: Stock")
            {
                //insert what this department needs access to.
                btnStock.Enabled = true;
            }

            //Documents
            if (lbl_department.Text == "Department: Documents")
            {
                //insert what this department needs access to.
                btnDocs.Enabled = true;
            }

            //Internal Comms
            if (lbl_department.Text == "Department: Int. Coms.")
            {
                //insert what this department needs access to.
                
            }

            //Project Management
            if (lbl_department.Text == "Department: Proj. Man.")
            {
                //insert what this department needs access to.
                btnProjManager.Enabled = true;
            }
        }
    }
}
