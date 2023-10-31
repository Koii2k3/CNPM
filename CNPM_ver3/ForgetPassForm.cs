using BLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class ForgetPassForm : Form
    {
        string myUser;
        UserBLL ul = new UserBLL();
        public ForgetPassForm()
        {
            InitializeComponent();
            tb_email_form.Text = string.Empty;
        }

        private string verifyValues()
        {
            string email = tb_email_form.Text.ToString();
            string cccd = "1";

            if(cccd.Equals("") || email.Equals(""))
            {
                MessageBox.Show("Please fill your email", "Fill Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            
            myUser = ul.checkForgot(cccd, email);

            if (myUser.Equals(""))
            {
                MessageBox.Show("Can not find your account", "Search Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            return myUser;
        }

        private int gerenateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private void bt_next_forget_Click_1(object sender, EventArgs e)
        {
            myUser = verifyValues();
            if (myUser.Equals("")) return;

            Users.F_USER = myUser;
            Users.F_EMAIL = tb_email_form.Text.ToString();

            int OTP = gerenateOTP();

            string title = "Reset password OTP";

            string m = "Your OTP : " + OTP;

            ul.verifyEmail(Users.F_EMAIL, title, m);

            ul.addOTP(Users.F_USER, OTP.ToString());
            this.Hide();
            ForgetPassForm1 forgetPassForm1 = new ForgetPassForm1();
            forgetPassForm1.Closed += (s, args) => this.Close();
            forgetPassForm1.Show();
        }

        private void tb_email_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_next_forget_Click_1(sender, e);
        }
    }
}
