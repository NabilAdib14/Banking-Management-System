using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class AdminLoanForm : Form
    {
        public AdminLoanForm()
        {
            InitializeComponent();
        }

        private void AdminLoanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void AdminLoanForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from LoanStatus";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    dGVLoan.DataSource = null;
                    dGVLoan.Rows.Clear();
                    MessageBox.Show("No Available Loans Status!");
                    return;
                }
                dGVLoan.AutoGenerateColumns = false;
                dGVLoan.DataSource = dt;
                dGVLoan.Refresh();
                dGVLoan.ClearSelection();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                if (cmbStatus.SelectedItem.ToString() == "All") 
                {
                    cmd.CommandText = $"select * from LoanStatus";
                }
                else if (cmbStatus.SelectedItem.ToString() == "Approved")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Approved' ";
                }
                else if (cmbStatus.SelectedItem.ToString() == "Pending")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Pending' ";
                }
                DataTable dt1 = new DataTable();
                var adp1 = new SqlDataAdapter(cmd);
                adp1.Fill(dt1);
                if (dt1.Rows.Count < 1)
                {
                    dGVLoan.DataSource = null;
                    dGVLoan.Rows.Clear();
                    MessageBox.Show("No Available Loans Status!");
                    return;
                }
                dGVLoan.AutoGenerateColumns = false;
                dGVLoan.DataSource = dt1;
                dGVLoan.Refresh();
                dGVLoan.ClearSelection();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
