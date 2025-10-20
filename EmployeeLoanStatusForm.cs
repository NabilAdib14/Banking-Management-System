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
    public partial class EmployeeLoanStatusForm : Form
    {
        public EmployeeLoanStatusForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void btnLoan_Click(object sender, EventArgs e)
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

        private void EmployeeLoanStatusForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            this.LoadData();
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
                cmd.CommandText = $"select * from LoanStatus order by LS_Id desc";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                dGVLoanStatus.AutoGenerateColumns = false;
                dGVLoanStatus.DataSource = dt;
                dGVLoanStatus.Refresh();
                dGVLoanStatus.ClearSelection();
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void EmployeeLoanStatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dGVLoanStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLoanId.Text = dGVLoanStatus.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbStatus.Text = dGVLoanStatus.Rows[e.RowIndex].Cells[2].Value.ToString();
            if(cmbStatus.Text == "Pending")
            {
                cmbStatus.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
