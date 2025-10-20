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

            this.LoadDashboardData();
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
            this.LoadDashboardData();

        }


        private void LoadDashboardData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.ConnectionPath;
                con.Open();


                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(*) AS TotalCustomer from Customer";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    lblTotalCustomer.Text = "Total Customer: " + dt.Rows[0]["TotalCustomer"].ToString();

                }

                else
                {
                    lblTotalCustomer.Text = "Total Customer:0";
                }


                var cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = "select count(*) AS TotalEmployee from Employee";

                DataTable dt1 = new DataTable();
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                adp1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    lblTotalEmployee.Text = "Total Employee: " + dt1.Rows[0]["TotalEmployee"].ToString();

                }
                else
                {
                    lblTotalEmployee.Text = "Total Employee:0";
                }


                var cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "select count(*) AS TotalLoan from LoanStatus where LS_Status = 'Pending'";

                DataTable dt2 = new DataTable();
                SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                adp2.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {
                    lblTotalLoan.Text = "Pending Loans: " + dt2.Rows[0]["TotalLoan"].ToString();

                }
                else
                {
                    lblTotalLoan.Text = "Pending Loans: 0";
                }


                var cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandText = "select count(*) AS TotalTransaction from TransactionInfo WHERE T_Date = CONVERT(date, GETDATE())";

                DataTable dt3 = new DataTable();
                SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
                adp3.Fill(dt3);

                if (dt3.Rows.Count > 0)
                {
                    lblTransactions.Text = "Today's Transactions: " + dt3.Rows[0]["TotalTransaction"].ToString();

                }

                else
                {
                    lblTransactions.Text = "Today's Transactions:0";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

