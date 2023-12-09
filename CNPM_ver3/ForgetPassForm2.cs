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
    public partial class ForgetPassForm2 : Form
    {

        string np1, np2;
        UserBLL ul = new UserBLL();

        public ForgetPassForm2()
        {
            InitializeComponent();
            tbNPass.Text = string.Empty;
            tbNPass2.Text = string.Empty;
            button_show1.FlatAppearance.MouseOverBackColor = Color.White;
            button_show1.FlatAppearance.MouseDownBackColor = Color.White; 
            button_show2.FlatAppearance.MouseOverBackColor = Color.White;
            button_show2.FlatAppearance.MouseDownBackColor = Color.White;
        }

        private void tbNPass_TextChanged(object sender, EventArgs e)
        {
            if (tbNPass.Text == String.Empty)
            {
                tbNPass.PasswordChar = '\0';
            }
            else
            {
                tbNPass.PasswordChar = '*';
            }
        }

        bool control_show1 = true;
        private void button_show_Click(object sender, EventArgs e)
        {
            if (tbNPass.Text != String.Empty)
            {
                if (control_show1)
                {
                    button_show1.Image = Properties.Resources.hide4;
                    control_show1 = false;
                    tbNPass.PasswordChar = '\0';
                }
                else
                {
                    button_show1.Image = Properties.Resources.view2;
                    control_show1 = true;
                    tbNPass.PasswordChar = '*';
                }
            }
        }

        bool control_show2 = true;
        private void button_show2_Click(object sender, EventArgs e)
        {
            if (tbNPass.Text != String.Empty)
            {
                if (control_show2)
                {
                    button_show2.Image = Properties.Resources.hide4;
                    control_show2 = false;
                    tbNPass2.PasswordChar = '\0';
                }
                else
                {
                    button_show2.Image = Properties.Resources.view2;
                    control_show2 = true;
                    tbNPass2.PasswordChar = '*';
                }
            }
        }

        private void tbNPass2_TextChanged(object sender, EventArgs e)
        {
            {
                if (tbNPass2.Text == String.Empty)
                {
                    tbNPass2.PasswordChar = '\0';
                }
                else
                {
                    tbNPass2.PasswordChar = '*';
                }
            }
        }

        private void tbNPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_n1_FPF_Click(sender, e);
        }

        private void tbNPass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_n1_FPF_Click(sender, e);
        }

        private void bt_n1_FPF_Click(object sender, EventArgs e)
        {
            np1 = tbNPass.Text;
            np2 = tbNPass2.Text;

            if (np1.Equals("") || np2.Equals(""))
            {
                MessageBox.Show("Please fill everything before click", "Fill Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(np1.Equals(np2)))
            {
                MessageBox.Show("Your confirm password is not the same", "Valid Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNPass.Text = string.Empty;
                tbNPass2.Text = string.Empty;
                return;
            }

            ul.updatePassword(Users.F_USER, np1);

            MessageBox.Show("Your password has been updated. Please login", "Update successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
