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
    public partial class CustomerLoanForm : Form
    {
        public CustomerLoanForm()
        {
            InitializeComponent();
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

        private void CustomerLoanForm_Load(object sender, EventArgs e)
        {
        
        }

        private void CustomerLoanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLoanApply_Click(object sender, EventArgs e)
        {
            CustomerLoanApplyForm customerLoanApplyForm = new CustomerLoanApplyForm();
            customerLoanApplyForm.Show();
            this.Hide();
        }
    }
}
