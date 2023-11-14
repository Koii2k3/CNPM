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
using System.Resources;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using CNPM_ver3.Properties;
using DTOO;
using System.Windows.Forms.VisualStyles;

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
            btForget.FlatAppearance.MouseOverBackColor = Color.White;
            btForget.FlatAppearance.MouseDownBackColor = Color.White;
            button_show.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            button_show.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_userid.Text;
            string password = textBox_pass.Text;

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
                    MessageBox.Show(Properties.Resources.login_success, Properties.Resources.login_success_title);
                    this.Hide();
                    PageControl pageControl = new PageControl();
                    pageControl.Show();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.login_notexist, Properties.Resources.login_fail_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_userid.Focus();
                }
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }

        private void button_addUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUForm = new AddUserForm();
            addUForm.Show();
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

        private void btForget_MouseHover(object sender, EventArgs e)
        {
            btForget.Cursor = Cursors.Hand;
        }

        private void button_login_MouseHover(object sender, EventArgs e)
        {
            button_login.Cursor = Cursors.Hand;
        }

        private void checkBox_remember_MouseHover(object sender, EventArgs e)
        {
            checkBox_remember.Cursor = Cursors.Hand;
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

        private void textBox_pass_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox_pass.Text == String.Empty)
            {
                textBox_pass.PasswordChar = '\0';
            }
            else
            {
                textBox_pass.PasswordChar = '*';
            }
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
