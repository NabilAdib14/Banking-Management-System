using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankingManagementSystem
{
    public partial class CustomerLoanForm : Form
    {
        public CustomerLoanForm()
        {
            InitializeComponent();
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            CustomerSettings1Form customerSettings1Form = new CustomerSettings1Form();
            customerSettings1Form.Show();
            this.Hide();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            CustomerLoanForm customerLoanForm = new CustomerLoanForm();
            customerLoanForm.Show();
            this.Hide();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            CustomerTransferForm customerTransferForm = new CustomerTransferForm();
            customerTransferForm.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            CustomerHistoryForm customerHistoryForm = new CustomerHistoryForm();
            customerHistoryForm.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            CustomerAccountForm customerAccountForm = new CustomerAccountForm();
            customerAccountForm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            CustomerHomeForm customerHomeForm = new CustomerHomeForm();
            customerHomeForm.Show();
            this.Hide();
        }

        private void CustomerLoanForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            lblLoanStatus.Text = "";
            lblAmount.Text = "";
            lblAppliedDate.Text = "";
            lblApprovedDate.Text = "";
            btnRepay.Enabled = false;
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Loan L, LoanStatus LS where LS.A_Id = {ApplicationHelper.LoggedInId} and LS.L_Id = L.L_Id and (LS_Status = 'Approved' or LS_Status = 'Pending')";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                cmbLoan.DataSource = dt;
                cmbLoan.ValueMember = "LS_Id";
                cmbLoan.DisplayMember = "L_Type";
                cmbLoan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void CustomerLoanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLoanApply_Click(object sender, EventArgs e)
        {
            CustomerLoanApplyForm customerLoanApplyForm = new CustomerLoanApplyForm();
            customerLoanApplyForm.Show();
            this.Hide();
        }

        private void btnRepay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to repay the loan?", "Confirm Repayment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"select A_Balance from Account where A_Id = {ApplicationHelper.LoggedInId}";
                    DataTable dt = new DataTable();
                    var adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    double balance = Convert.ToDouble(dt.Rows[0]["A_Balance"].ToString());
                    cmd.CommandText = $"select * from LoanStatus LS,Loan L where L.L_Id = LS.L_Id and (LS.A_Id = {ApplicationHelper.LoggedInId} and LS.LS_Status = 'Approved')";
                    DataTable dt1 = new DataTable();
                    var adp1 = new SqlDataAdapter(cmd);
                    adp1.Fill(dt1);
                    double amount = Convert.ToDouble(dt1.Rows[0]["LS_Amount"].ToString());
                    if (amount > balance)
                    {
                        MessageBox.Show("Not enough balance in your account to repay the loan");
                        return;
                    }
                    int lsid = Convert.ToInt32(dt1.Rows[0]["LS_Id"]);
                    cmd.CommandText = $"update Account set A_Balance = A_Balance - {amount} where A_Id = {ApplicationHelper.LoggedInId}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"update LoanStatus set LS_Status = 'Repaid' where LS_Id = {lsid}";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Loan Repaid Successfully");
                    con.Close();
                    btnViewDetails_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbLoan.Text))
            {
                MessageBox.Show("No Loan Selected");
                return;
            }
            int lsid = Convert.ToInt32(cmbLoan.SelectedValue);
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Loan L, LoanStatus LS where LS_Id = {lsid} and L.L_Id=LS.L_id";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string status = dt.Rows[0]["LS_Status"].ToString();
                    string amount = dt.Rows[0]["LS_Amount"].ToString();
                    string approveddate = "";
                    string applieddate = Convert.ToDateTime(dt.Rows[0]["LS_AppliedDate"]).ToString("dd/MM/yyyy");
                    if (dt.Rows[0]["LS_DisbursementDate"] != DBNull.Value)
                    {
                        approveddate = Convert.ToDateTime(dt.Rows[0]["LS_DisbursementDate"]).ToString("dd/MM/yyyy");
                    }
                    lblLoanStatus.Text = status;
                    lblAmount.Text = amount;
                    lblAppliedDate.Text = applieddate;
                    lblApprovedDate.Text = approveddate;

                    if (status == "Approved")
                    {
                        btnRepay.Enabled = true;
                    }
                    else
                    {
                        btnRepay.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
