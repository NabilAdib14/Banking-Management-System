using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class EmployeeHomeForm : Form
    {
        public EmployeeHomeForm()
        {
            InitializeComponent();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            employeeHomeForm.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            EmployeeCustomerForm employeeCustomerForm = new EmployeeCustomerForm();
            employeeCustomerForm.Show();
            this.Hide();
        }

        private void btnLoan_Click_1(object sender, EventArgs e)
        {
            EmployeeLoanForm employeeLoanForm = new EmployeeLoanForm(); 
            employeeLoanForm.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            EmployeeSettings1Form employeeSettings1Form = new EmployeeSettings1Form();
            employeeSettings1Form.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void EmployeeHomeForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.ConnectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select COUNT(*) as total from UserInfo where U_Role = 'Customer'";

                DataTable dt = new DataTable();
                var adp =new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if(dt.Rows.Count == 0)
                {
                    lblTotalCustomer.Text = "Total Customer: 0";
                }
                else
                {
                    lblTotalCustomer.Text = $"Total Customer: {dt.Rows[0]["total"].ToString()}";
                }

                var con2 = new SqlConnection();
                con2.ConnectionString = ApplicationHelper.ConnectionPath;
                con2.Open();

                var cmd2 = new SqlCommand();
                cmd2.Connection = con2;
                cmd2.CommandText = "select COUNT(*) as total from LoanStatus where LS_Status = 'Pending'";

                DataTable dt2 = new DataTable();
                var adp2 = new SqlDataAdapter(cmd2);
                adp2.Fill(dt2);

                if (dt2.Rows.Count == 0)
                {
                    lblPendingLoan.Text = "Pending Loan Applications: 0";
                }
                else
                {
                    lblPendingLoan.Text = $"Pending Loan Applications: {dt2.Rows[0]["total"].ToString()}";
                }

                var con3 = new SqlConnection();
                con3.ConnectionString = ApplicationHelper.ConnectionPath;
                con3.Open();

                var cmd3 = new SqlCommand();
                cmd3.Connection = con3;
                cmd3.CommandText = "select COUNT(*) as total from TransactionInfo where T_Date = CONVERT(date, GETDATE())";

                DataTable dt3 = new DataTable();
                var adp3 = new SqlDataAdapter(cmd3);
                adp3.Fill(dt3);

                if (dt3.Rows.Count == 0)
                {
                    lblTransactions.Text = "Today's Transactions: 0";
                }
                else
                {
                    lblTransactions.Text = $"Today's Transactions: {dt3.Rows[0]["total"].ToString()}";
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
