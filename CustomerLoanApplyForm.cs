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
    public partial class CustomerLoanApplyForm : Form
    {
        private bool isProgrammaticClose = false;
        public CustomerLoanApplyForm()
        {
            InitializeComponent();
        }

        private void CustomerLoanApplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isProgrammaticClose) return;

            DialogResult dr = MessageBox.Show("Are you sure you want to Cancel?", "Cancel", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                e.Cancel = true; 
            }
            else
            {
                CustomerLoanForm customerLoanForm = new CustomerLoanForm();
                customerLoanForm.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           if(cmbType.SelectedIndex != -1)
           {
                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"select L_MaximumAmount from Loan where L_Id = {cmbType.SelectedValue}";
                    DataTable dt = new DataTable();
                    var adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    int max = Convert.ToInt32(dt.Rows[0]["L_MaximumAmount"].ToString());
                    int amount;
                    if(int.TryParse(txtAmount.Text,out amount) && amount>0)
                    {
                        cmd.CommandText = $"select * from LoanStatus where A_Id = {ApplicationHelper.LoggedInId} and L_Id = {cmbType.SelectedValue} and (LS_Status = 'Approved' or LS_Status = 'Pending')";
                        DataTable dt1 = new DataTable();
                        var adp1 = new SqlDataAdapter(cmd);
                        adp1.Fill(dt1);
                        if(dt1.Rows.Count > 0)
                        {
                            MessageBox.Show($" A {cmbType.Text} is already in processing.");
                            return;
                        }
                        if (amount <= max)
                        {
                            cmd.CommandText = $"insert into LoanStatus (L_Id,LS_Status,A_Id,LS_Amount,LS_AppliedDate) values ({cmbType.SelectedValue},'Pending', {ApplicationHelper.LoggedInId}, {amount}, GETDATE())";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Applied for {cmbType.Text} worth {amount}BDT");
                        }
                        else
                        {
                            MessageBox.Show($"The maximum limit of {cmbType.Text} is {max}");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid amount");
                        return;
                    }
                    con.Close();
                    this.isProgrammaticClose = true;
                    CustomerLoanForm customerLoanForm = new CustomerLoanForm();
                    customerLoanForm.Show();
                    this.Close();                    
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           }
        }
        private void CustomerLoanApplyForm_Load(object sender, EventArgs e)
        {
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Loan";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                cmbType.DataSource = dt;
                cmbType.ValueMember = "L_Id";
                cmbType.DisplayMember = "L_Type";
                cmbType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
