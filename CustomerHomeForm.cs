using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class CustomerHomeForm : Form
    {
        public CustomerHomeForm()
        {
            InitializeComponent();

            // Parse the login time from string
            //DateTime loginDate = DateTime.Parse(loginTime);

            // Calculate validity = login time + 2 years
            //DateTime validityDate = loginDate.AddYears(2);

            // Show login time
            //lblLoginTime.Text = "Logged in at: " + loginDate.ToString("dd MMM yyyy, hh:mm tt");

            // Show validity in Month + Year (e.g., "Valid until: Sep 2027")
            //lblValidity.Text = "Valid until: " + validityDate.ToString("MMMM yyyy");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginTime_Click(object sender, EventArgs e)
        {

        }

        private void CustomerHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerHomeForm_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}
