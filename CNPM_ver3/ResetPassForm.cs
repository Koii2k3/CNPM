using DTOO;
using BLL;
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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btResetPass_Click(object sender, EventArgs e)
        {
            string curr = tCurrPass.Text;
            string new_1 = tNewPass1.Text;
            string new_2 = tNewPass2.Text;

            if (curr.Equals("") || new_1.Equals("") || new_2.Equals(""))
            {
                tCurrPass.Text = "";
                tNewPass1.Text = "";
                tNewPass2.Text = "";
                MessageBox.Show("Please fill everything", "Fill check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!new_1.Equals(new_2))
            {
                tNewPass1.Text = "";
                tNewPass2.Text = "";
                MessageBox.Show("Your new password is not the same of your comfirm", "Comfirm check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!curr.Equals(Users.PASSWORD))
            {
                tCurrPass.Text = "";
                tNewPass1.Text = "";
                tNewPass2.Text = "";
                MessageBox.Show("Wrong password", "Password check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (curr.Equals(new_1))
            {
                tNewPass1.Text = "";
                tNewPass2.Text = "";
                MessageBox.Show("New password must different from current password", "Duplicate check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserBLL myUL = new UserBLL();

            int res = myUL.updatePassword(Users.PK, new_2);

            if (res == 1)
            {
                Users.PASSWORD = new_1;
                tCurrPass.Text = "";
                tNewPass1.Text = "";
                tNewPass2.Text = "";
                MessageBox.Show("Your password has been updated", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}