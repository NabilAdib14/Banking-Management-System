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
    public partial class CustomerLoanApplyForm : Form
    {
        public CustomerLoanApplyForm()
        {
            InitializeComponent();
        }

        private void CustomerLoanApplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
