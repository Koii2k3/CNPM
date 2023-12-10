using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using DTOO;

namespace CNPM_ver3
{
    public partial class LoginForm : Form
    {
        UserBLL ul = new UserBLL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox_userid.Focus();
            btForget.FlatAppearance.MouseOverBackColor = Color.White;
            btForget.FlatAppearance.MouseDownBackColor = Color.White;
            button_show.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button_show.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_userid.Text;
            string password = textBox_pass.Text;
            //string username = "FT_43819_IT";
            //string password = "43819";
            //string username = "FT_96418_IT";
            //string password = "123456";
            //string username = "IN_50821_IT";
            //string password = "50821";
            //string username = "FT_25426_HR" ;
            //string password = "25426";
            //string username = "IN_50821_IT";
            //string password = "50821";


            if (username == "" || password == "")
            {
                MessageBox.Show(Properties.Resources.empty_field, Properties.Resources.login_fail_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (password == "" && username == "")
                {
                    textBox_userid.Focus();
                }
                else if (password == "")
                {
                    textBox_pass.Focus();
                }
                else
                {
                    textBox_userid.Focus();
                }
            }
            else
            {
                if (ul.loginCheck(username, password))
                {
                    //MessageBox.Show(Properties.Resources.login_success, Properties.Resources.login_success_title);
                    this.Hide();
                    if (Users.LV_NAME == "Quản lý nhân sự")
                    {
                        //PageControl pageControl = new PageControl();
                        //pageControl.Show();
                        PageControlHR p = new PageControlHR();
                        p.Show();
                    }
                    if (Users.LV_NAME == "Quản lý dự án")
                    {
                        PageControlPM p = new PageControlPM();
                        p.Show();

                    }
                    if (Users.LV_NAME == "Nhân viên")
                    {
                        PageControlStaff p = new PageControlStaff();
                        p.Show();
                    }
                    //UserHomeForm infoForm = new UserHomeForm();
                    //infoForm.Show();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.login_notexist, Properties.Resources.login_fail_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_userid.Focus();
                }
            }
        }

        bool forgotIsopen = false;
        private void btForget_Click(object sender, EventArgs e)
        {
            if (!forgotIsopen)
            {
                btForget.FlatStyle = FlatStyle.Flat;
                btForget.FlatAppearance.BorderSize = 0;
                ForgetPassForm forgetPassForm = new ForgetPassForm();
                forgetPassForm.Show();
            }
        }

        bool control_show = true;
        private void button_show_Click(object sender, EventArgs e)
        {
            textBox_pass.Focus();
            if (control_show)
            {
                button_show.Image = Properties.Resources.hide4;
                control_show = false;
                textBox_pass.PasswordChar = '\0';
            }
            else
            {
                button_show.Image = Properties.Resources.view2;
                control_show = true;
                textBox_pass.PasswordChar = '*';
            }
        }

        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {
            if (textBox_pass.Text != String.Empty)
            {
                textBox_pass.PasswordChar = '*';
                if (!control_show) { 
                    control_show = true;
                    button_show.Image = Properties.Resources.view2;
                }
            }
            else
            {
                textBox_pass.PasswordChar = '\0';
            }
        }

        private void btForget_MouseHover(object sender, EventArgs e)
        {
            btForget.Cursor = Cursors.Hand;
        }

        private void button_login_MouseHover(object sender, EventArgs e)
        {
            button_login.Cursor = Cursors.Hand;
        }

        private void comboBox_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            string changeLanguage = comboBox_language.Text.ToString();
            if (changeLanguage == "English")
            {
                ChangeLanguageClass.UpdateLanguage("language", "en");
            }
            else if (changeLanguage == "Tiếng Việt")
            {
                ChangeLanguageClass.UpdateLanguage("language", "vi-VN");
            }
            Application.Restart();
        }

        private void button_show_BackColorChanged_1(object sender, EventArgs e)
        {
            button_show.ForeColor = Color.White;
        }

        private void button_show_ForeColorChanged_1(object sender, EventArgs e)
        {
            button_show.ForeColor = Color.White;
        }

        private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_login_Click(sender, e);
        }

        private void textBox_userid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_login_Click(sender, e);
        }
    }
}
