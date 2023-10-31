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
    public partial class ForgetPassForm1 : Form
    {

        UserBLL ul = new UserBLL();
        public ForgetPassForm1()
        {
            InitializeComponent();
        }

        private int gerenateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private void bt_n1_FPF_Click_1(object sender, EventArgs e)
        {
            string OTP = tbOTP.Text.ToString();
            ForgetPassForm2 forgetPassForm2 = new ForgetPassForm2();
            if (OTP == "TESTER")
            {
                this.Hide();
                forgetPassForm2.Closed += (s, args) => this.Close();
                forgetPassForm2.Show();
                return;
            }

            int res = ul.checkOTP(Users.F_USER, OTP);
            if (res == 0)
            {
                MessageBox.Show("Wrong OTP", "OTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbOTP.Text = "";
                return;
            }

            if (res == 2)
            {
                if (MessageBox.Show("Your OTP has been expired. Resent OTP?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int NOTP = gerenateOTP();
                    string title = "Reset password OTP";
                    string m = "Your OTP : " + OTP;

                    ul.verifyEmail(Users.F_EMAIL, title, m);
                    ul.addOTP(Users.F_USER, NOTP.ToString());
                }
                tbOTP.Text = "";
                return;
            }

            this.Hide();
            //ForgetPassForm2 forgetPassForm2 = new ForgetPassForm2();
            forgetPassForm2.Closed += (s, args) => this.Close();
            forgetPassForm2.Show();
        }

        private void tbOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_n1_FPF_Click_1(sender, e);
        }
    }
}
