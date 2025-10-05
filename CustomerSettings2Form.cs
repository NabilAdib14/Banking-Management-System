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
using System.Xml.Linq;

namespace BankingManagementSystem
{
    public partial class CustomerSettings2Form : Form
    {
        public CustomerSettings2Form()
        {
            InitializeComponent();
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblOldPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblNewPassword_Click(object sender, EventArgs e)
        {

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

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            CustomerSettings1Form customerSettings1Form = new CustomerSettings1Form();
            customerSettings1Form.Show();
            this.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            CustomerSettings2Form customerSettings2Form = new CustomerSettings2Form();
            customerSettings2Form.Show();
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

        private void CustomerSettings2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerSettings2Form_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from UserInfo where U_Id = {ApplicationHelper.LoggedInId}";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                string oldpwd = dt.Rows[0]["U_Password"].ToString();
                if(txtOldPassword.Text.ToString() != oldpwd)
                {
                    MessageBox.Show("Incorrect Current Password");
                    return;
                }
                string newpwd = txtNewPassword.Text.ToString();
                cmd.CommandText = $"update UserInfo set U_Password = {newpwd} where U_Id = {ApplicationHelper.LoggedInId}";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Updated Successfully!");
                txtOldPassword.Clear();
                txtNewPassword.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBox_MouseEnter(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.UseSystemPasswordChar = false;
        }
        private void txtBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.UseSystemPasswordChar = true;
        }

    }
}
