using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankingManagementSystem
{
    public partial class AdminEmployeeForm : Form
    {
        public AdminEmployeeForm()
        {
            InitializeComponent();
        }

        private void AdminEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void AdminEmployeeForm_Load(object sender, EventArgs e)
        {
            this.LoadData();

        }

        private void LoadData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.ConnectionPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " select * from UserInfo,Employee where U_Id = E_Id";
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                dGVEmployee.AutoGenerateColumns = false;
                dGVEmployee.DataSource = dt;
                dGVEmployee.Refresh();
                dGVEmployee.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dGVEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dGVEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPass.Text = dGVEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dGVEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSalary.Text = dGVEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
        private void NewData()
        {
            txtId.Text = "Auto Generated";
            txtName.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
            dGVEmployee.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           this.LoadData();
           this.NewData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "Auto Generated")
            {
                MessageBox.Show("No Data Selected");
                return;
            }
            string id = txtId.Text;
            DialogResult dr = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                dGVEmployee.ClearSelection();
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.ConnectionPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Employee where E_Id={id}";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $" delete from UserInfo where U_Id = {id}";
                cmd.ExecuteNonQuery();
                con.Close();
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text;
            string password = txtPass.Text;
            string email = txtEmail.Text;
            int salary;
            if(int.TryParse(txtSalary.Text, out salary))
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter the required details");
                    return;
                }
                try
                {
                    var con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.ConnectionPath;
                    con.Open();
                    if (txtId.Text == "Auto Generated")
                    {
                        var cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = $"INSERT INTO UserInfo (U_Role,U_Name, U_Password) OUTPUT INSERTED.U_Id VALUES ('Employee','{name}', '{password}')";
                        int U_Id = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = $"INSERT INTO Employee (E_Id,E_Email, E_Salary) VALUES ({U_Id},'{email}',{salary})";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Added Successfully");
                    }
                    else
                    {
                        var cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = $"update UserInfo set U_Name = '{name}', U_Password = '{password}' WHERE U_Id = {id};update  Employee set E_Email = '{email}',E_Salary = {salary} WHERE E_Id = {id}";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Information Updated Successfully");
                    }
                    con.Close();
                    this.LoadData();
                    this.NewData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid salary.");
            }

                   
        }


    }
}


