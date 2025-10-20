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
    public partial class CustomerAccountForm : Form
    {
        public CustomerAccountForm()
        {
            InitializeComponent();
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            CustomerDepositForm customerDepositForm = new CustomerDepositForm();
            customerDepositForm.Show();
            this.Hide();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            CustomerWithdrawForm customerWithdrawForm = new CustomerWithdrawForm();
            customerWithdrawForm.Show();
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

        private void CustomerAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerAccountForm_Load(object sender, EventArgs e)
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
                cmd.CommandText = $"select * from Account, UserInfo where U_Id = {ApplicationHelper.LoggedInId} and A_Id = U_Id ; ";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                string name = dt.Rows[0]["U_Name"].ToString();
                string accno = dt.Rows[0]["A_Id"].ToString();
                string cardno = dt.Rows[0]["A_CardNo"].ToString();
                string balance = dt.Rows[0]["A_Balance"].ToString();
                lblAccName.Text = name;
                lblAccNo.Text = $"Account No. {accno}";
                lblCardNo.Text = cardno;
                lblBalance.Text = $"Balance: {balance} BDT";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
