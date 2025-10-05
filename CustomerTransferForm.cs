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
    public partial class CustomerTransferForm : Form
    {
        public CustomerTransferForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblAccountNo_Click(object sender, EventArgs e)
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

        private void CustomerTransferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
    }

        private void CustomerTransferForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = $"Welcome, {ApplicationHelper.LoggedInName}";
            txtF_Acc_No.Text = Convert.ToString(ApplicationHelper.LoggedInId);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int toA_Id = Convert.ToInt32(txtTo_Acc_No.Text);
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Account WHERE A_Id = {toA_Id}";
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid Receiver Account.");
                    return;
                }
                cmd.CommandText = $"select * FROM Account WHERE A_Id = {ApplicationHelper.LoggedInId}";
                DataTable dt1 = new DataTable();
                var adp1 = new SqlDataAdapter(cmd);
                adp1.Fill(dt1);
                double balance = Convert.ToDouble(dt.Rows[0]["A_Balance"].ToString());
                double amount;
                if (double.TryParse(txtAmount.Text, out amount))
                {
                    if (amount <= 0)
                    {
                        MessageBox.Show("Amount must be greater than 0.");
                        return;
                    }
                    if (amount > balance)
                    {
                        MessageBox.Show("Amount must be less than available balance.");
                        return;
                    }
                    cmd.CommandText = $"update Account set A_Balance = A_Balance -{amount} where A_Id = {ApplicationHelper.LoggedInId}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"update Account set A_Balance = A_Balance +{amount} where A_Id = {toA_Id}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"insert into TransactionInfo (T_Amount,T_Type,T_Date,From_A_Id,To_A_Id,T_Method) values ({amount},'Transfer','{DateTime.Now}',{ApplicationHelper.LoggedInId},{toA_Id},'Transfer')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show($"{amount}Tk transferred to Account No.{toA_Id} successfully!");
                    txtTo_Acc_No.Clear();
                    txtAmount.Clear();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
