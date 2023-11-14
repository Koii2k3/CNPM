using BLL;
using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CNPM_ver3
{
    public partial class PageControlStaff : Form
    {
        //PM 
        int control_hover = -1;
        int flag = 0;
        string curr_pj_id = null;
        string curr_pk = "";
        List<string> files = new List<string>();
        UserBLL ul = new UserBLL();
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();
        RequestBLL reqBll = new RequestBLL();

        public PageControlStaff()
        {
            InitializeComponent();
        }

        private void PageControlStaff_Load(object sender, EventArgs e)
        {
            //FE
            MP_button_allTask.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 246, 255);
            MP_button_allTask.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 246, 255);
            MP_button_allTask.FlatAppearance.BorderSize = 0;

            //PC
            btn_myproject_Click(sender, e);

            try
            {
                byte[] img = (byte[])Users.USER_IMAGE;
                MemoryStream ms = new MemoryStream(img);
                PC_pictureBox_user.Image = Image.FromStream(ms);
                PC_label_role.Text = Users.LV_NAME;
                PC_label_username.Text = Users.USER_NAME;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Profile - button - change password - click()
        private void PF_button_changePass_Click(object sender, EventArgs e)
        {
            pages.SetPage(7);
        }

        // Navbar
        private void btn_myproject_Click(object sender, EventArgs e)
        {
            pages.SetPage(0);
            MP_showPj();
            MP_showAllTask();
        }

        private void btn_task_Click(object sender, EventArgs e)
        {
            pages.SetPage(1);
        }

        private void btn_worklog_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        private void btn_performance_Click(object sender, EventArgs e)
        {
            pages.SetPage(3);
        }

        private void btn_request_Click(object sender, EventArgs e)
        {
            pages.SetPage(4);
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            try
            {
                PF_textBox_username.Text = Users.USER_NAME;
                PF_textBox_username1.Text = Users.USER_NAME;
                PF_dateTimePicker_birthdate.Value = (DateTime)Users.USER_BIRTH;
                PF_textBox_pass.Text = Users.PASSWORD;
                PF_textBox_level1.Text = Users.PASSWORD;
                PF_textBox_type.Text = Users.VT_NAME;
                PF_textBox_level.Text = Users.LV_NAME;
                PF_textBox_dp.Text = Users.DP_NAME;
                PF_textBox_cccd.Text = Users.USER_CCCD;
                PF_textBox_phone.Text = Users.USER_PHONE;
                PF_comboBox_enable.Text = Users.ENABLE.ToString();
                PF_comboBox_gender.Text = Users.USER_GENDER;
                PF_textBox_email.Text = Users.USER_EMAIL;
                PF_textBox_address.Text = Users.USER_ADDRESS;
                byte[] img = (byte[])Users.USER_IMAGE;
                MemoryStream ms = new MemoryStream(img);
                PF_pictureBox_user.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pages.SetPage(5);
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            pages.SetPage(6);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        //MP functions
        private void MP_textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MP_button_search_Click(sender, e);
        }
        public void MP_showPj()
        {
            //MP_dataGridView_myJProject.ReadOnly = true;
            MP_dataGridView_myJProject.DataSource = ul.GetAllProjectOfUser(Users.PK);
        }
        public void MP_showAllTask()
        {
            //MP_dataGridView_task.ReadOnly = true;
            MP_dataGridView_task.DataSource = task.GetAllTaskOfUser(Users.PK);
        }
        public void MP_showTaskPj()
        {
            //dataGridView_task.ReadOnly = true;
            MP_dataGridView_task.DataSource = task.GetJobInProjectOfUser(Users.PK, curr_pj_id);
        }
        private void MP_button_search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MP_textBox_search.Text))
            {
                MP_dataGridView_myJProject.DataSource = pj.SearchProjectU(Users.PK, MP_textBox_search.Text);
            }
            else
            {
                MessageBox.Show("Search without any hint error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //*
        private void MP_button_allTask_Click(object sender, EventArgs e)
        {
            MP_showAllTask();
        }
        private void MP_dataGridView_myJProject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MP_dataGridView_task.ReadOnly = true;
            curr_pj_id = MP_dataGridView_myJProject.CurrentRow.Cells["PJ_ID"].Value.ToString();
            MP_showTaskPj();
        }

        //RP
        private void RP_btResetPass_Click(object sender, EventArgs e)
        {
            string curr = RP_tCurrPass.Text;
            string new_1 = RP_tNewPass1.Text;
            string new_2 = RP_tNewPass2.Text;

            if (curr.Equals("") || new_1.Equals("") || new_2.Equals(""))
            {
                RP_tCurrPass.Text = "";
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("Please fill everything", "Fill check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!new_1.Equals(new_2))
            {
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("Your new password is not the same of your comfirm", "Comfirm check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!curr.Equals(Users.PASSWORD))
            {
                RP_tCurrPass.Text = "";
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("Wrong password", "Password check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (curr.Equals(new_1))
            {
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("New password must different from current password", "Duplicate check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserBLL myUL = new UserBLL();

            int res = myUL.updatePassword(Users.PK, new_2);

            if (res == 1)
            {
                Users.PASSWORD = new_1;
                RP_tCurrPass.Text = "";
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("Your password has been updated", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void RP_btn_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(9);
            RP_tCurrPass.Text = "";
            RP_tNewPass1.Text = "";
            RP_tNewPass2.Text = "";
        }

        //AS
        bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        //SR
        private void SR_btn_clear_Click(object sender, EventArgs e)
        {
            SR_textBox_subject.Clear();
            SR_textBox_toUser.Clear();
            SR_textBox_content.Clear();
            files.Clear();
            SR_comboBox_files.Items.Clear();
        }

        private void SR_bt_Request_Click(object sender, EventArgs e)
        {
            string subject = SR_textBox_subject.Text;
            string pk_receiver = SR_textBox_toUser.Text;
            string content = SR_textBox_content.Text;
            string pk_sender = Users.PK;
            if (reqBll.AddRequest(subject, content, pk_sender, pk_receiver, files))
            {
                MessageBox.Show("Request successfully", "Add Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fail to request", "Add Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SR_button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string file_name = System.IO.Path.GetFileName(file);
                    SR_comboBox_files.Items.Add(file_name);

                    files.Add(file);
                }
                MessageBox.Show("Uploaded " + files.Count + " successfully");
            }
        }

        public void SR_showTable()
        {
            SR_dataGridView_myReq.ReadOnly = true;
            SR_dataGridView_myReq.DataSource = reqBll.GetMyRequest(Users.PK);
        }

        private void SR_button_clearFiles_Click(object sender, EventArgs e)
        {
            files.Clear();
            SR_comboBox_files.Items.Clear();
        }
    }
}
