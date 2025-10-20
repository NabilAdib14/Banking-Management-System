using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class CustomerHomeForm : Form
    {
        public CustomerHomeForm()
        {
            InitializeComponent();

          
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginTime_Click(object sender, EventArgs e)
        {

        }

        private void CustomerHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerHomeForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";

            string conPath = ApplicationHelper.ConnectionPath;
            var con = new SqlConnection();
            con.ConnectionString = conPath;
            con.Open();
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select A_CardNo from Account where A_Id = {ApplicationHelper.LoggedInId}";
            DataTable dt = new DataTable();
            var adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            lblCardno.Text= dt.Rows[0]["A_CardNo"].ToString();

            cmd.CommandText = $"select A_Validity from Account where A_Id = {ApplicationHelper.LoggedInId}";
            DataTable dt1 = new DataTable();
            var adp1 = new SqlDataAdapter(cmd);
            adp1.Fill(dt1);
            con.Close();
            lblValidity.Text = "Validity: "+Convert.ToDateTime(dt1.Rows[0]["A_Validity"]).ToString("MM/dd/yyyy");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void lblCardno_Click(object sender, EventArgs e)
        {

        }
    }
}
