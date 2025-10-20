using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class EmployeeSettings1Form : Form
    {
        public EmployeeSettings1Form()
        {
            InitializeComponent();
        }

        private void EmployeeSettings1Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            EmployeeSettings1Form employeeSettings1Form1 = new EmployeeSettings1Form();
            employeeSettings1Form1.Show();
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

        private void EmployeeSettings1Form_Load(object sender, EventArgs e)
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
                cmd.CommandText = $"select * from UserInfo, Employee where U_Id = E_Id and U_Id = {ApplicationHelper.LoggedInId}";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                txtName.Text = dt.Rows[0]["U_Name"].ToString();
                txtEmail.Text = dt.Rows[0]["E_Email"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update UserInfo set U_Name = '{name}' where U_Id = {ApplicationHelper.LoggedInId}";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"update Employee set E_Email = '{email}' where E_Id = {ApplicationHelper.LoggedInId}";
                cmd.ExecuteNonQuery();
                con.Close();

                ApplicationHelper.LoggedInName = name;
                MessageBox.Show("Profile Updated Successfully!");
                EmployeeSettings1Form employeeSettings1Form = new EmployeeSettings1Form();
                employeeSettings1Form.Show();
                this.Hide();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
