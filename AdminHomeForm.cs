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
    public partial class AdminHomeForm : Form
    {
        public AdminHomeForm()
        {
            InitializeComponent();
        }

        private void AdminHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminHomeForm adminHomeForm = new AdminHomeForm();
            adminHomeForm.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AdminCustomerForm adminCustomerForm = new AdminCustomerForm();
            adminCustomerForm.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            AdminEmployeeForm adminEmployeeForm = new AdminEmployeeForm();
            adminEmployeeForm.Show();
            this.Hide();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            AdminTransactionForm adminTransactionForm = new AdminTransactionForm();
            adminTransactionForm.Show();
            this.Hide();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            AdminLoanForm adminLoanForm = new AdminLoanForm();
            adminLoanForm.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminHomeForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            int customers=0, employees = 0, loans = 0, transactions = 0;
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"select count(*) as 'count' from Customer";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                customers = Convert.ToInt32(dt.Rows[0]["count"].ToString());

                cmd.CommandText = $"select count(*) as 'count' from Employee";
                DataTable dt1 = new DataTable();
                var adp1 = new SqlDataAdapter(cmd);
                adp1.Fill(dt1);
                employees = Convert.ToInt32(dt1.Rows[0]["count"].ToString());

                cmd.CommandText = $"select count(*) as 'count' from LoanStatus";
                DataTable dt2 = new DataTable();
                var adp2 = new SqlDataAdapter(cmd);
                adp2.Fill(dt2);
                loans = Convert.ToInt32(dt2.Rows[0]["count"].ToString());

                cmd.CommandText = $"select count(*) as 'count' from TransactionInfo where T_Date = CAST(GETDATE() as date)";
                DataTable dt3 = new DataTable();
                var adp3 = new SqlDataAdapter(cmd);
                adp3.Fill(dt3);
                transactions = Convert.ToInt32(dt3.Rows[0]["count"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblTotalCustomer.Text = $"Total Customers: {customers}";
            lblTotalEmployee.Text = $"Total Employees: {employees}";
            lblTotalLoan.Text = $"Total Loans: {loans}";
            lblTransactions.Text = $"Today's Transactions: {transactions}";

        }
    }
}
