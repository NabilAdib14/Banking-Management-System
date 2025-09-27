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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string dev1 = "Md. Nabil Adibur Rahman - ID: 23-53187-3";
            string dev2 = "Maisha Tahseen - ID: 23-53206-3";
            string dev3 = "Shanjida Ahmed Shema - ID: 23-53378-3";

            string message = dev1 + "\n" + dev2 + "\n" + dev3;


            MessageBox.Show(message, "Developers Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "customer" && txtPass.Text == "customer")
            {
                string loginTimestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                CustomerHomeForm hf = new CustomerHomeForm();
                hf.Show();
                this.Hide();
            }
            else if (txtUserId.Text == "employee" && txtPass.Text == "employee")
            {
                EmployeeHomeForm hf = new EmployeeHomeForm();
                hf.Show();
                this.Hide();
            }
            else if (txtUserId.Text == "admin" && txtPass.Text == "admin")
            {
                AdminHomeForm hf = new AdminHomeForm();
                hf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm form = new SignUpForm();
            form.Show();
            this.Hide();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
