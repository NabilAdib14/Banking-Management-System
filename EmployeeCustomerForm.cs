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
    public partial class EmployeeCustomerForm : Form
    {
        public EmployeeCustomerForm()
        {
            InitializeComponent();
        }

        private void EmployeeCustomerForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            this.LoadData();

        }

        private void EmployeeCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
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
                cmd.CommandText = $"select * from UserInfo, Customer where U_Id = C_Id and C_Active = 1";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                dGVCustomer.AutoGenerateColumns = false;
                dGVCustomer.DataSource = dt;
                dGVCustomer.Refresh();
                dGVCustomer.ClearSelection();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
