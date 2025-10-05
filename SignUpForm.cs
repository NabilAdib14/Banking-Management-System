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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string dev1 = "Md. Nabil Adibur Rahman - ID: 23-53187-3";
            string dev2 = "Maisha Tahseen - ID: 23-53206-3";
            string dev3 = "Shanjida Ahmed Shema - ID: 23-53378-3";

            string message = dev1 + "\n" + dev2 + "\n" + dev3;


            MessageBox.Show(message, "Developers Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SignUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPass.Text;
            string address = txtAddress.Text;
            string mail = txtEmail.Text;
            DateTime dob = dtp_DOB.Value;
            DateTime openingDate = DateTime.Now;
            DateTime validTill = openingDate.AddYears(5);
            int U_Id=0;
            try
            {
                string conPath = ApplicationHelper.ConnectionPath;
                var con = new SqlConnection();
                con.ConnectionString = conPath;
                con.Open();
                var cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = $"INSERT INTO UserInfo (U_Name, U_Password, U_Role) OUTPUT INSERTED.U_ID VALUES ('{name}', '{pwd}', 'Customer')";
                U_Id = Convert.ToInt32(cmd1.ExecuteScalar());
                var cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = $"INSERT INTO Customer (C_ID, C_Email, C_Address, C_Dob, C_Age) VALUES ({U_Id}, '{mail}', '{address}', '{dob:yyyy-MM-dd}',DATEDIFF(YEAR, '{dob:yyyy-MM-dd}', GETDATE()))";
                cmd2.ExecuteNonQuery();
                var cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandText = $"INSERT INTO Account (A_ID, A_OpeningDate, A_Validity) VALUES ({U_Id}, '{openingDate:yyyy-MM-dd}', '{validTill:yyyy-MM-dd}')";
                cmd3.ExecuteNonQuery();
                con.Close();

                MessageBox.Show($"Your User ID is: {U_Id}\nYour Password is: {pwd}", "Sign Up Successful", MessageBoxButtons.OK);
                LoginForm lf = new LoginForm();
                lf.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
