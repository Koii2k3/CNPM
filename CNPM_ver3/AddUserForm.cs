using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Net;
using BLLL;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ComponentModel.DataAnnotations;

namespace CNPM_ver3
{
    public partial class AddUserForm : Form
    {
        UserBLL ul = new UserBLL();

        public AddUserForm()
        {
            InitializeComponent();
        }
        bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text;
            DateTime birthdate = dateTimePicker_birthdate.Value;
            string type = comboBox_type.Text;
            string dp = comboBox_dp.Text;
            string lv = comboBox_lv.Text;
            string cccd = textBox_cccd.Text;
            string gender = comboBox_gender.Text;

            string email = textBox_email.Text;
            string phone = textBox_phone.Text;

            string address = textBox_address.Text;

            byte[] image = null;
            MemoryStream ms = new MemoryStream();
            pictureBox_user.Image.Save(ms, pictureBox_user.Image.RawFormat);
            image = ms.ToArray();
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (ul.insertUser(type, username, birthdate, address, cccd, image, email, gender, dp, lv, phone))
                {
                    MessageBox.Show("New User Added", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fail to add new user", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                comboBox_dp.Items.Add(t);
            }
        }

        private void label_toLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lg = new LoginForm();
            lg.Show();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            // `OpenFileDialog` cho phép người dùng chọn một hoặc nhiều tập tin từ hệ thống tệp tin.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        private void textBox_username_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBox_username.Text) || !textBox_username.Text.All(c => Char.IsLetter(c) || c == ' '))
            {
                e.Cancel = true;
                textBox_username.Focus();
                errorProvider1.SetError(textBox_username, "Invalid username");
            }
        }

        private void textBox_phone_Validating(object sender, CancelEventArgs e)
        {
            errorProvider2.Clear();
            Regex r = new Regex(@"^[0-9]{10}$");
            if (!r.IsMatch(textBox_phone.Text))
            {
                e.Cancel = true;
                textBox_phone.Focus();
                errorProvider2.SetError(textBox_phone, "Phone number must contain 10 digits");
            }
        }

        private void dateTimePicker_birthdate_Validating(object sender, CancelEventArgs e)
        {
            errorProvider3.Clear();
            DateTime birthdate = dateTimePicker_birthdate.Value;
            DateTime now = DateTime.Now;
            TimeSpan date_num = now - birthdate;
            int day_age = date_num.Days;
            if (day_age < 6570)
            {
                e.Cancel = true;
                errorProvider3.SetError(dateTimePicker_birthdate, "Account is only for the age of 18 or up");
            }
        }

        private void textBox_email_Validating(object sender, CancelEventArgs e)
        {
            errorProvider4.Clear();
            if (!IsValidEmail(textBox_email.Text))
            {
                e.Cancel = true;
                textBox_email.Focus();
                errorProvider4.SetError(textBox_email, "Email address is invalid");
            }
            
        }

        private void textBox_cccd_Validating(object sender, CancelEventArgs e)
        {
            errorProvider5.Clear();
            if (!textBox_cccd.Text.All(char.IsDigit) || textBox_cccd.Text.Length < 9)
            {
                e.Cancel = true;
                textBox_cccd.Focus();
                errorProvider5.SetError(textBox_cccd, "Identification number must contain above 8 digits");
            }
        }
    }
}
