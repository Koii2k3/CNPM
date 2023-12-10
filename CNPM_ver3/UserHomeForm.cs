using DTOO;
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

namespace CNPM_ver3
{
    public partial class UserHomeForm : Form
    {

        OverwriteForm ovf = new OverwriteForm();

        public UserHomeForm()
        {
            InitializeComponent();
        }

        private void UserHomeForm_Load(object sender, EventArgs e)
        {
            if (Users.LV_NAME=="Nhân viên")
            {
                panel_tool.BackColor = Color.FromArgb(14, 33, 160);
                panel_header.BackColor = Color.FromArgb(14, 33, 160);

                button_profile.Visible = true;
                button_profile.BackColor = Color.FromArgb(77, 45, 183);

                button_myJProject.Visible = true;
                button_myJProject.BackColor = Color.FromArgb(77, 45, 183);

                button_request.Visible = true;
                button_request.BackColor = Color.FromArgb(77, 45, 183);

                button_4.BackColor = Color.FromArgb(77, 45, 183);
            }
            else if (Users.LV_NAME == "Quản lý nhân sự")
            {
                button_manageMember.Visible = true;
                button_manageReq.Visible = true;
            }
            else if (Users.LV_NAME == "Quản lý dự án")
            {
                button_myJProject.Visible = true;
                button_manageProject.Visible = true;
                button_manageReq.Visible = true;
            }

            try
            {
                byte[] img = (byte[])Users.USER_IMAGE;
                MemoryStream ms = new MemoryStream(img);
                pictureBox_user.Image = Image.FromStream(ms);
                label_role.Text = Users.LV_NAME;
                label_username.Text = Users.USER_NAME;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button_addmember_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Show();
        }

        private void button_manageMenber_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new ManageMemberForm(), ref panel_main);
        }

        private void button_addMember_Click_1(object sender, EventArgs e)
        {
            ovf.openChildForm(new AddUserForm(), ref panel_main);
        }

        private void button_profile_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new ProfileForm(), ref panel_main);
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            ovf.HomeForm(ref panel_main, ref panel_cover);
        }

        private void button_addProject_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new ManageProjectForm(), ref panel_main);
        }

        private void button_myJProject_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new ManageJoinedProjectForm(), ref panel_main);
        }

        private void button_manageRequest_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new RequestForm(), ref panel_main);
        }

        private void button_manageReq_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new ManageRequestForm(), ref panel_main);
        }
    }
}
