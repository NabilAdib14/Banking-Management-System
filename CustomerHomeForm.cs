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
        public CustomerHomeForm(string loginTime)
        {
            InitializeComponent();

            // Parse the login time from string
            DateTime loginDate = DateTime.Parse(loginTime);

            // Calculate validity = login time + 2 years
            DateTime validityDate = loginDate.AddYears(2);

            // Show login time
            lblLoginTime.Text = "Logged in at: " + loginDate.ToString("dd MMM yyyy, hh:mm tt");

            // Show validity in Month + Year (e.g., "Valid until: Sep 2027")
            lblValidity.Text = "Valid until: " + validityDate.ToString("MMMM yyyy");
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
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
