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
    public partial class EmployeeSettings2Form : Form
    {
        public EmployeeSettings2Form()
        {
            InitializeComponent();
        }

        private void EmployeeSettings2Form_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            EmployeeSettings2Form employeeSettings2Form = new EmployeeSettings2Form();
            employeeSettings2Form.Show();
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

        private void EmployeeSettings2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            EmployeeSettings1Form employeeSettings1Form1 = new EmployeeSettings1Form();
            employeeSettings1Form1.Show();
            this.Hide();
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
                if (txtOldPassword.Text.ToString() != oldpwd)
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
