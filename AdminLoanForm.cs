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
            this.LoadData();
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
                if (cmbStatusView.SelectedItem.ToString() == "All") 
                {
                    cmd.CommandText = $"select * from LoanStatus";
                }
                else if (cmbStatusView.SelectedItem.ToString() == "Approved")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Approved' ";
                }
                else if (cmbStatusView.SelectedItem.ToString() == "Pending")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Pending' ";
                }
                else if (cmbStatusView.SelectedItem.ToString() == "Repaid")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Repaid' ";
                }
                else if (cmbStatusView.SelectedItem.ToString() == "Rejected")
                {
                    cmd.CommandText = $"select * from LoanStatus where LS_Status = 'Rejected' ";
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
                txtLoanId.Text = "";
                cmbStatus.Text = "";
                cmbStatus.SelectedIndex = -1;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminLoanForm_Shown(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            this.LoadData();
            cmbStatusView.SelectedIndex = 0;
        }
        private void LoadData()
        {
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from LoanStatus order by LS_Id desc ";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoanId.Text))
            {
                MessageBox.Show("No Loan Status Selected");
                return;
            }

            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection(conPath);
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"select LS_Status from LoanStatus where LS_Id = {txtLoanId.Text}";
                string currentStatus = cmd.ExecuteScalar().ToString();
                if (currentStatus == "Approved" || currentStatus == "Rejected" || currentStatus == "Repaid")
                {
                    MessageBox.Show($"Loan is already {currentStatus}.");
                    con.Close();
                    return;
                }

                cmd.CommandText = $"update LoanStatus set LS_Status = '{cmbStatus.Text}', EM_Id = {ApplicationHelper.LoggedInId} where LS_Id ={txtLoanId.Text}";
                cmd.ExecuteNonQuery();


                if (cmbStatus.Text == "Approved")
                {
                    cmd.CommandText = $"update LoanStatus set LS_DisbursementDate = GETDATE() where LS_Id = {txtLoanId.Text}";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"select A_Id,LS_Amount from LoanStatus LS, Loan L where LS.LS_Id = {txtLoanId.Text} and L.L_Id = LS.L_Id";
                    DataTable dt = new DataTable();
                    var adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                    int aid = Convert.ToInt32(dt.Rows[0]["A_Id"]);
                    double amount = Convert.ToDouble(dt.Rows[0]["LS_Amount"]);

                    cmd.CommandText = $"update Account set A_Balance = A_Balance + {amount} where A_Id = {aid}";
                    cmd.ExecuteNonQuery();
                }
                txtLoanId.Text = "";
                cmbStatus.Text = "";
                this.LoadData();
                cmbStatusView.SelectedIndex = 0;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dGVLoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtLoanId.Text = dGVLoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbStatus.Text = dGVLoan.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (cmbStatus.Text == "Pending")
            {
                cmbStatus.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
