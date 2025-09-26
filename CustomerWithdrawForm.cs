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
    public partial class CustomerWithdrawForm : Form
    {
        public CustomerWithdrawForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerWithdrawForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
