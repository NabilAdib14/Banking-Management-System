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
    public partial class CustomerDepositForm : Form
    {

        private bool isProgrammaticClose = false;
        public CustomerDepositForm()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a withdrawal method.");
                return;
            }
            double amount;
            if (double.TryParse(txtAmount.Text, out amount))
            {
                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be greater than 0.");
                    return;
                }
                try
                {
                    string conPath = ApplicationHelper.ConnectionPath;
                    var con = new SqlConnection();
                    con.ConnectionString = conPath;
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"update Account set A_Balance = A_Balance +{amount} where A_Id = {ApplicationHelper.LoggedInId}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"insert into TransactionInfo (T_Amount,T_Type,T_Date,To_A_Id,T_Method) values ({amount},'Deposit','{DateTime.Now}',{ApplicationHelper.LoggedInId},'{cmbMethod.SelectedItem.ToString()}')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show($"{amount}Tk deposited successfully!");
                    isProgrammaticClose = true;
                    CustomerAccountForm customerAccountForm = new CustomerAccountForm();
                    customerAccountForm.Show();
                    this.Close();
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

        private void CustomerDepositForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isProgrammaticClose) return;

            DialogResult dr = MessageBox.Show("Are you sure you want to Cancel?", "Cancel", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                CustomerAccountForm customerAccountForm = new CustomerAccountForm();
                customerAccountForm.Show();
            }
        }
    }
}
