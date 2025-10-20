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
    public partial class EmployeeLoanForm : Form
    {
        public EmployeeLoanForm()
        {
            InitializeComponent();
        }

        private void EmployeeLoanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void btnLoanStatus_Click(object sender, EventArgs e)
        {
            EmployeeLoanStatusForm employeeLoanStatusForm = new EmployeeLoanStatusForm();
            employeeLoanStatusForm.Show();
            this.Hide();
        }

        private void EmployeeLoanForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            this.LoadData();
            this.NewData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = txtType.Text.ToString();
            int amount;
            if(int.TryParse(txtPrincipalAmount.Text, out amount))
            {
                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    if (string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Please enter the required details");
                        return;
                    }
                    if (txtId.Text == "Auto Generated")
                    {
                        cmd.CommandText = $"insert into Loan (L_Type, L_MaximumAmount) values ('{type}',{amount})";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Loan Added");

                    }
                    else
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        cmd.CommandText = $"update Loan set L_Type = '{type}', L_MaximumAmount = {amount} where L_Id = {id}";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Loan Details Updated Successfully");
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
                MessageBox.Show("Please enter a valid amount.");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "Auto Generated")
            {
                MessageBox.Show("No Data Selected");
                return;
            }
            
            DialogResult dr = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo);
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
                    cmd.CommandText = $"delete from Loan where L_Id = {id}";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Loan Details Deleted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loan Cannot be Deleted \n \n"+ ex.Message);
                }
            }
            else
            {
                dGVLoan.ClearSelection();
            }
                this.LoadData();
            this.NewData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
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
                cmd.CommandText = $"select * from Loan";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                dGVLoan.AutoGenerateColumns = false;
                dGVLoan.DataSource = dt;
                dGVLoan.Refresh();
                dGVLoan.ClearSelection();
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
            txtType.Text = "";
            txtPrincipalAmount.Text = "";
            dGVLoan.ClearSelection();
        }

        private void dGVLoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dGVLoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtType.Text = dGVLoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrincipalAmount.Text = dGVLoan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
