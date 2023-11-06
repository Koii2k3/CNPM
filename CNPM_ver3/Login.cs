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
using MySql.Data.MySqlClient;

namespace CNPM_ver3
{
    public partial class Login : Form
    {   //UserClass userClass = new UserClass();
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text;
            string password = textBox_password.Text;

            if (username=="" || password == "")
            {   
                if (password == "" && username=="")
                {
                    MessageBox.Show("Empty field is not allowed", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_username.Focus();
                }
                else if (password == "")
                {
                    MessageBox.Show("Password field is empty", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_password.Focus();
                }
                else
                {
                    MessageBox.Show("Username field is empty", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_username.Focus();
                }
            }
            else
            {
                DataTable user = UserClass.loginUser(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login successfully", "Login");
                    this.Hide();

                    UserInformation infoForm = new UserInformation(user.Rows[0]);
                    infoForm.Show();
                }
                else
                {
                    MessageBox.Show("User is not exist", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_username.Clear();
                    textBox_password.Clear();

                    // focus
                    textBox_username.Focus();
                }
            }

        }

        private void button_showPass_Click(object sender, EventArgs e)
        {
            if (textBox_password.UseSystemPasswordChar)
            {
                textBox_password.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_password.UseSystemPasswordChar = true;
            }
        }

 
    }
}
