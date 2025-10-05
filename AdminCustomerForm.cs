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
    public partial class AdminCustomerForm : Form
    {
        public AdminCustomerForm()
        {
            InitializeComponent();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminCustomerForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            this.LoadData();
        }

        private void AdminCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
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
                cmd.CommandText = $"select * from UserInfo, Customer where U_Id = C_Id";
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

        private void NewData()
        {
            txtId.Text = "Auto Generated";
            txtId.ReadOnly = true;
            txtName.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            dGVCustomer.ClearSelection();
            dtp_DOB.Value = DateTime.Now;
            dtp_DOB.Enabled = true;


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
        private void dGVCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtId.Text = dGVCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPass.Text = dGVCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dGVCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dGVCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtp_DOB.Value = Convert.ToDateTime(dGVCustomer.Rows[e.RowIndex].Cells[6].Value.ToString());
            dtp_DOB.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "Auto Generated")
            {
                MessageBox.Show("No data selected to delete");
                return;
            }
            DialogResult dr = MessageBox.Show("Do you want to delete?", "Logout", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(txtId.Text.ToString());
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"delete from Account where A_Id = {id}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"delete from Customer where C_Id = {id}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"delete from UserInfo where U_Id = {id}";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Deleted SUccessfully");
                    this.LoadData();
                    this.NewData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dGVCustomer.ClearSelection();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPass.Text == "" || txtEmail.Text == "" || txtAddress.Text == ""){
                MessageBox.Show("Insert all the required details");
                return;
            }
            if(txtId.Text == "Auto Generated")
            {
                string name = txtName.Text.ToString();
                string pwd = txtPass.Text.ToString();
                string mail = txtEmail.Text.ToString();
                string address = txtAddress.Text.ToString();
                DateTime dob = dtp_DOB.Value;
                DateTime openingDate = DateTime.Now;
                DateTime validTill = openingDate.AddYears(5);
                int U_Id = 0;
                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = $"INSERT INTO UserInfo (U_Name, U_Password, U_Role) OUTPUT INSERTED.U_ID VALUES ('{name}', '{pwd}', 'Customer')";
                    U_Id = Convert.ToInt32(cmd1.ExecuteScalar());
                    var cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandText = $"INSERT INTO Customer (C_ID, C_Email, C_Address, C_Dob, C_Age) VALUES ({U_Id}, '{mail}', '{address}', '{dob:yyyy-MM-dd}',DATEDIFF(YEAR, '{dob:yyyy-MM-dd}', GETDATE()))";
                    cmd2.ExecuteNonQuery();
                    var cmd3 = new SqlCommand();
                    cmd3.Connection = con;
                    cmd3.CommandText = $"INSERT INTO Account (A_ID, A_OpeningDate, A_Validity) VALUES ({U_Id}, '{openingDate:yyyy-MM-dd}', '{validTill:yyyy-MM-dd}')";
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show($"The new User ID is: {U_Id}\n Password is: {pwd}", "New Customer Details Entered Successfully", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                int id = Convert.ToInt32(txtId.Text.ToString());
                string name = txtName.Text.ToString();
                string pwd = txtPass.Text.ToString();
                string mail = txtEmail.Text.ToString();
                string address = txtAddress.Text.ToString();

                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"update UserInfo set U_Name = '{name}', U_Password = '{pwd}' where U_Id = {id}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"update Customer set C_Address = '{address}', C_Email = '{mail}' where C_Id = {id}";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Profile Updated Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.NewData();
            this.LoadData();
        }
    }
}
