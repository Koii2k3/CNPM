using BLL;
using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class PageControlHR : Form
    {

        //PM 
        int flag = 0;
        string curr_pj_id = null;
        string curr_pk = "";
        Boolean isDesign = false;
        UserBLL ul = new UserBLL();
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();
        RequestBLL reqBll = new RequestBLL();
        DataTable dataGridView_user_data = new DataTable();
        NotiBLL notiBLL = new NotiBLL();
        TypeBLL tl = new TypeBLL();
        LevelBLL lv = new LevelBLL();
        DepartmentBLL dp = new DepartmentBLL();
        DataTable dataGridView_user_disabled_data = new DataTable();

        public PageControlHR()
        {
            InitializeComponent();   
        }

        private void PageControlHR_Load(object sender, EventArgs e)
        {
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

            string[] types = tl.getUserType();
            string[] levels = lv.GetUserLevel();
            string[] dps = dp.GetUserDP();
            dataGridView_user_data = ul.getUserInfoAll();
            dataGridView_user_disabled_data = ul.getUserInfoDis();
            notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);

            if (dataGridView_user_data != null)
            {
                dataGridView_user_data.Columns["USER_IMAGE"].ColumnName = "AVATAR";
                dataGridView_user_data.Columns["USER_ID"].ColumnName = "ID";
                dataGridView_user_data.Columns["USER_NAME"].ColumnName = "FULL NAME";
                dataGridView_user_data.Columns["USER_BIRTH"].ColumnName = "BIRTH DATE";
                dataGridView_user_data.Columns["USER_EMAIL"].ColumnName = "EMAIL";
                dataGridView_user_data.Columns["USER_GENDER"].ColumnName = "GENDER";
                dataGridView_user_data.Columns["USER_PHONE"].ColumnName = "PHONE";
                dataGridView_user_data.Columns["LV_NAME"].ColumnName = "POSITION";
                dataGridView_user_data.Columns["VT_NAME"].ColumnName = "TYPE";
                dataGridView_user_data.Columns["PB_NAME"].ColumnName = "DEPARTMENT";
            }

            if (dataGridView_user_disabled_data != null)
            {
                dataGridView_user_disabled_data.Columns["USER_IMAGE"].ColumnName = "AVATAR";
                dataGridView_user_disabled_data.Columns["USER_ID"].ColumnName = "ID";
                dataGridView_user_disabled_data.Columns["USER_NAME"].ColumnName = "FULL NAME";
                dataGridView_user_disabled_data.Columns["USER_BIRTH"].ColumnName = "BIRTH DATE";
                dataGridView_user_disabled_data.Columns["USER_EMAIL"].ColumnName = "EMAIL";
                dataGridView_user_disabled_data.Columns["USER_GENDER"].ColumnName = "GENDER";
                dataGridView_user_disabled_data.Columns["USER_PHONE"].ColumnName = "PHONE";
                dataGridView_user_disabled_data.Columns["LV_NAME"].ColumnName = "POSITION";
                dataGridView_user_disabled_data.Columns["VT_NAME"].ColumnName = "TYPE";
                dataGridView_user_disabled_data.Columns["PB_NAME"].ColumnName = "DEPARTMENT";
            }

            SM_dropdown_filter.Text = "Active Staffs";

            foreach (string t in types)
            {
                PF_comboBox_type.Items.Add(t);
            }

            foreach (string t in levels)
            {
                PF_comboBox_lv.Items.Add(t);
            }

            foreach (string t in dps)
            {
                PF_comboBox_dp.Items.Add(t);
            }

            foreach (string t in types)
            {
                AS_comboBox_type.Items.Add(t);
            }

            foreach (string t in levels)
            {
                AS_comboBox_lv.Items.Add(t);
            }

            foreach (string t in dps)
            {
                AS_comboBox_dp.Items.Add(t);
            }
         
            btn_staffmanagement_Click(sender, e);
        }

        private void btn_staffmanagement_Click(object sender, EventArgs e)
        {
            Users.SPU = false;
            SM_showTable();
            pages.SetPage(0);
        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            PF_button_changePass.Visible = true;
            SM_btDisable.Visible = false;
            SM_button_update.Visible = false;
            SM_button_see_project.Visible = false;

            PF_textBox_username.Enabled = false;
            PF_dateTimePicker_birthdate.Enabled = false;
            PF_textBox_email.Enabled = false;
            PF_textBox_cccd.Enabled = false;
            PF_comboBox_gender.Enabled = false;
            PF_comboBox_enable.Enabled = false;
            PF_textBox_pass.Enabled = false;
            PF_comboBox_type.Enabled = false;
            PF_comboBox_lv.Enabled = false;
            PF_comboBox_dp.Enabled = false;
            PF_textBox_addr.Enabled = false;
            PF_textBox_phone.Enabled = false;

            try
            {
                PF_textBox_username.Text = Users.USER_LOGIN;
                PF_textBox_username1.Text = Users.USER_NAME;
                PF_dateTimePicker_birthdate.Value = (DateTime)Users.USER_BIRTH;
                PF_textBox_pass.Text = "Encrypted";
                PF_textBox_level1.Text = Users.LV_NAME;
                PF_comboBox_type.Text = Users.VT_NAME;
                PF_comboBox_lv.Text = Users.LV_NAME;
                PF_comboBox_dp.Text = Users.DP_NAME;
                PF_textBox_cccd.Text = Users.USER_CCCD;
                PF_textBox_phone.Text = Users.USER_PHONE;
                PF_comboBox_enable.Text = Users.ENABLE.ToString();
                if (PF_comboBox_enable.Text.Equals("1"))
                {
                    PF_comboBox_enable.Text = "ACTIVE";
                    PF_comboBox_enable.ForeColor = Color.Green;
                }
                else
                {
                    PF_comboBox_enable.Text = "DISABLE";
                    PF_comboBox_enable.ForeColor = Color.Red;
                }
                PF_comboBox_gender.Text = Users.USER_GENDER;
                PF_textBox_email.Text = Users.USER_EMAIL;
                PF_textBox_addr.Text = Users.USER_ADDRESS;
                byte[] img = (byte[])Users.USER_IMAGE;
                MemoryStream ms = new MemoryStream(img);
                PF_pictureBox_user.Image = System.Drawing.Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pages.SetPage(4);
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            pages.SetPage(5);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void btn_requestmanagement_Click(object sender, EventArgs e)
        {
            RM_showTable();
            pages.SetPage(3);
        }

        //PM functions
        private void PM_txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PM_btn_search_Click(sender, e);
        }
        private void PM_chb_setdl_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (PM_chb_setdl.Checked)
            {
                PM_dp_expect.Format = DateTimePickerFormat.Long;
                PM_dp_start.Format = DateTimePickerFormat.Long;
                PM_dp_dl.Format = DateTimePickerFormat.Long;
                PM_pn_dl.Enabled = true;
            }
            else
            {
                PM_dp_expect.CustomFormat = " ";
                PM_dp_start.CustomFormat = " ";
                PM_dp_dl.CustomFormat = " ";
                PM_dp_expect.Format = DateTimePickerFormat.Custom;
                PM_dp_start.Format = DateTimePickerFormat.Custom;
                PM_dp_dl.Format = DateTimePickerFormat.Custom;
                PM_pn_dl.Enabled = false;
            }
        }

        private void PM_dataGridView_project_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PM_dataGridView_project.CurrentRow != null)
            {
                curr_pj_id = PM_dataGridView_project.CurrentRow.Cells["PJ_ID"].Value.ToString();

                PM_txt_proname.Text = PM_dataGridView_project.CurrentRow.Cells["PROJECT NAME"].Value.ToString();
                PM_txt_prodes.Text = PM_dataGridView_project.CurrentRow.Cells["DESCRIPTION"].Value.ToString();

                if (PM_dataGridView_project.CurrentRow.Cells["PJ_PUBLIC"].Value.ToString() == "1")
                {
                    PM_cb_proscale.Text = "Public";
                }
                else
                {
                    PM_cb_proscale.Text = "Private";
                }

                try
                {
                    PM_chb_setdl.Checked = true;

                    PM_dp_start.Value = (DateTime)PM_dataGridView_project.CurrentRow.Cells["PJ_EXPECT_FIN"].Value;
                    PM_dp_expect.Value = (DateTime)PM_dataGridView_project.CurrentRow.Cells["PJ_START"].Value;
                    PM_dp_dl.Value = (DateTime)PM_dataGridView_project.CurrentRow.Cells["PJ_FINISH"].Value;
                }
                catch
                {
                    PM_chb_setdl.Checked = false;
                }

                PM_txt_prover.Text = PM_dataGridView_project.CurrentRow.Cells["PJ_VERSION"].Value.ToString();
                task.GetTaskOfProject(curr_pj_id);
                PM_showTask();
            }
        }

        public void PM_showPj()
        {
            if (Users.SPU == true)
            {
                //PM_dataGridView_project.DataSource = pj.getProjectOfUser(Users.CSU);

                DataTable PM_dataGridView_project_data = pj.getProjectOfUser(Users.CSU);
                //Users.SPU = false;
                if (PM_dataGridView_project_data != null)
                {
                    PM_dataGridView_project_data.Columns["PJ_NAME"].ColumnName = "PROJECT NAME";
                    PM_dataGridView_project_data.Columns["PJ_DES"].ColumnName = "DESCRIPTION";
                    PM_dataGridView_project_data.Columns["PJ_START"].ColumnName = "START DATE";
                    PM_dataGridView_project_data.Columns["PJ_FINISH"].ColumnName = "DEADLINE";
                    PM_dataGridView_project_data.Columns["USER_ID"].ColumnName = "MANAGER ID";

                    PM_dataGridView_project.DataSource = PM_dataGridView_project_data;
                    //if (!isDesign)
                    //{
                    //PM_dataGridView_project.RowTemplate.Height = 100;
                    //PM_dataGridView_project.Columns["ID"].Width = 40;
                    //PM_dataGridView_project.Columns["AVATAR"].Width = 50;
                    //PM_dataGridView_project.Columns["GENDER"].Width = 40;
                    //PM_dataGridView_project.Columns["PHONE"].Width = 50;
                    //PM_dataGridView_project.Columns["BIRTH DATE"].Width = 50;
                    //PM_dataGridView_project.Columns["TYPE"].Width = 50;
                    //PM_dataGridView_project.Columns["POSITION"].Width = 75;
                    //PM_dataGridView_project.Columns["DEPARTMENT"].Width = 75;
                    //isDesign = true;
                    //}

                    PM_dataGridView_project.Columns["PJ_ID"].Visible = false;
                    PM_dataGridView_project.Columns["PJ_EXPECT_FIN"].Visible = false;
                    PM_dataGridView_project.Columns["PJ_VERSION"].Visible = false;
                    PM_dataGridView_project.Columns["PJ_PUBLIC"].Visible = false;
                    PM_dataGridView_project.Columns["MANAGER ID"].DisplayIndex = 1;
                }
            }
            else
            {
                PM_dataGridView_project.DataSource = pj.GetProjectInfoAllOfMan(Users.PK);
            }
        }

        public void PM_showTask()
        {
            //PM_dataGridView_task.DataSource = task.GetTaskOfProject(curr_pj_id);
            PM_dataGridView_task.Columns.Clear();
            DataTable PM_dataGridView_task_data = task.GetTaskOfProject(curr_pj_id);
            if (PM_dataGridView_task_data != null)
            {
                PM_dataGridView_task_data.Columns["J_NAME"].ColumnName = "TASK NAME";
                PM_dataGridView_task_data.Columns["J_DES"].ColumnName = "DESCRIPTION";
                PM_dataGridView_task_data.Columns["J_START"].ColumnName = "START DATE";
                PM_dataGridView_task_data.Columns["J_DEADLINE"].ColumnName = "DEADLINE";

                PM_dataGridView_task.DataSource = PM_dataGridView_task_data;
                //if (!isDesign)
                //{
                //PM_dataGridView_task.RowTemplate.Height = 100;
                //PM_dataGridView_task.Columns["ID"].Width = 40;
                //PM_dataGridView_task.Columns["AVATAR"].Width = 50;
                //PM_dataGridView_task.Columns["GENDER"].Width = 40;
                //PM_dataGridView_task.Columns["PHONE"].Width = 50;
                //PM_dataGridView_task.Columns["BIRTH DATE"].Width = 50;
                //PM_dataGridView_task.Columns["TYPE"].Width = 50;
                //PM_dataGridView_task.Columns["POSITION"].Width = 75;
                //PM_dataGridView_task.Columns["DEPARTMENT"].Width = 75;
                //isDesign = true;
                //}

                PM_dataGridView_task.Columns["J_STATUS"].Visible = false;
                PM_dataGridView_task.Columns["J_ID"].Visible = false;
                PM_dataGridView_task.Columns["J_FINISH"].Visible = false;
                PM_dataGridView_task.Columns["J_HL"].Visible = false;
                PM_dataGridView_task.Columns["PJ_ID"].Visible = false;
                PM_dataGridView_task.Columns["J_DONE"].Visible = false;
            }
        }

        private void PM_btn_search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PM_txt_search.Text))
            {
                PM_dataGridView_project.DataSource = pj.SearchProject(PM_txt_search.Text);
            }
            else
            {
                MessageBox.Show("Search without any hint error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PM_dp_start_ValueChanged(object sender, EventArgs e)
        {
            PM_dp_start.Format = DateTimePickerFormat.Long;
        }

        private void PM_dp_expect_ValueChanged(object sender, EventArgs e)
        {
            PM_dp_expect.Format = DateTimePickerFormat.Long;
        }

        private void PM_dp_dl_ValueChanged(object sender, EventArgs e)
        {
            PM_dp_dl.Format = DateTimePickerFormat.Long;
        }
        //*
        private void dataGridView_task_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string task_id = PM_dataGridView_task.CurrentRow.Cells["J_ID"].Value.ToString();
            AddUser2Task au2t = new AddUser2Task(curr_pj_id, task_id);
            au2t.Show();
        }

        //PF
        private void PF_button_changePass_Click(object sender, EventArgs e)
        {
            pages.SetPage(7);
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
            RP_tCurrPass.Text = "";
            RP_tNewPass1.Text = "";
            RP_tNewPass2.Text = "";
            pages.SetPage(4);
        }

        //SM
        public void SM_loadTable()
        {
            dataGridView_user_data = ul.getUserInfoAll();
            SM_showTable();
        }

        public void SM_showTable()
        {
            DataTable SM_dataGridView_user_data = dataGridView_user_data;
            if (SM_dataGridView_user_data != null)
            {
                SM_dataGridView_user.DataSource = SM_dataGridView_user_data;
                if (!isDesign)
                {
                    SM_dataGridView_user.RowTemplate.Height = 100;
                    SM_dataGridView_user.Columns["ID"].Width = 40;
                    SM_dataGridView_user.Columns["AVATAR"].Width = 50;
                    SM_dataGridView_user.Columns["GENDER"].Width = 40;
                    SM_dataGridView_user.Columns["PHONE"].Width = 50;
                    SM_dataGridView_user.Columns["BIRTH DATE"].Width = 50;
                    SM_dataGridView_user.Columns["TYPE"].Width = 50;
                    SM_dataGridView_user.Columns["POSITION"].Width = 75;
                    SM_dataGridView_user.Columns["DEPARTMENT"].Width = 75;
                    isDesign = true;
                }


                SM_dataGridView_user.Columns["U_PASS"].Visible = false;
                SM_dataGridView_user.Columns["USER_ADDRESS"].Visible = false;
                SM_dataGridView_user.Columns["USER_CCCD"].Visible = false;
                SM_dataGridView_user.Columns["U_EN"].Visible = false;
                SM_dataGridView_user.Columns["VT_ID"].Visible = false;
                SM_dataGridView_user.Columns["LV_ID"].Visible = false;
                SM_dataGridView_user.Columns["U_LOGIN"].Visible = false;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)SM_dataGridView_user.Columns["AVATAR"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageColumn.DisplayIndex = 0;
            }
        }

        private void SM_button_update_Click(object sender, EventArgs e)
        {
            string u_name = PF_textBox_username.Text;
            DateTime bd = PF_dateTimePicker_birthdate.Value;
            string cccd = PF_textBox_cccd.Text;
            string addr = PF_textBox_addr.Text;
            string gd = PF_comboBox_gender.Text;
            string email = PF_textBox_email.Text;
            string vt_name = PF_comboBox_type.Text;
            string u_pass = PF_textBox_pass.Text;
            string lv_name = PF_comboBox_lv.Text;
            string dp_name = PF_comboBox_dp.Text;
            string u_phone = PF_textBox_phone.Text;

            MemoryStream ms = new MemoryStream();
            PF_pictureBox_user.Image.Save(ms, PF_pictureBox_user.Image.RawFormat);
            byte[] img = ms.ToArray();
            if (ul.UpdateUserInfo(curr_pk, u_name, bd, cccd, addr, gd, email, vt_name, u_pass, lv_name, dp_name, u_phone, img))
            {
                MessageBox.Show("Update user information successfully");
                SM_loadTable();
            }
            else
            {
                MessageBox.Show("Fail to update user information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SM_button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                PF_pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        private void SM_btDisable_Click(object sender, EventArgs e)
        {
            if (curr_pk.Equals("")) return;
            if (curr_pk.Equals(Users.PK))
            {
                MessageBox.Show("Cannot disable yourself", "Error Disable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (flag == 0)
            {
                if (MessageBox.Show("Do you want to disable this user?", "Disable User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int res = ul.disableUser(curr_pk, flag);
                    if (res == 1)
                    {
                        MessageBox.Show("This user has been disabled", "Sucessfully Disable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SM_loadTable();
                    }
                }
                return;
            }

            if (flag == 1)
            {
                if (MessageBox.Show("Do you want to enable this user?", "Enable User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int res = ul.disableUser(curr_pk, flag);
                    if (res == 1)
                    {
                        MessageBox.Show("This user has been enabled", "Sucessfully Enable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SM_loadTableDis();
                    }
                }
                return;
            }
        }

       
        public void SM_loadTableDis()
        {
            dataGridView_user_disabled_data = ul.getUserInfoDis();
            SM_showTableDis();
        }

        public void SM_showTableDis()
        {
            SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.DataSource = dataGridView_user_disabled_data;
            SM_dataGridView_user.RowTemplate.Height = 80;

            try
            {
                // Show image
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)SM_dataGridView_user.Columns[7];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch { }
        }

        private void SM_button_search_user_Click(object sender, EventArgs e)
        {
            String description = SM_tb_search_user.Text;
            if (description.Equals(""))
                SM_tb_search_user.PlaceholderText = "Staff is not found";
            else 
                SM_loadTableSearch(description);
        }

        public void SM_loadTableSearch(string description)
        {
            SM_showTableSearch(description);
        }

        public void SM_showTableSearch(string description)
        {
            //SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.DataSource = ul.getUserFromSearch(description);
            SM_dataGridView_user.RowTemplate.Height = 100;

            try
            {
                // Show image
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)SM_dataGridView_user.Columns[7];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch { }
        }

        private void SM_button_see_project_Click(object sender, EventArgs e)
        {
            Users.SPU = true;
            Users.CSU = curr_pk;
            pages.SetPage(1);
            PM_showPj();
            //ManageProjectForm manageProjectForm = new ManageProjectForm();
            //manageProjectForm.Show();
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

        private void AS_button_add_Click(object sender, EventArgs e)
        {
            string username = AS_textBox_username.Text;
            DateTime birthdate = AS_dateTimePicker_birthdate.Value;
            string type = AS_comboBox_type.Text;
            string dp = AS_comboBox_dp.Text;
            string lv = AS_comboBox_lv.Text;
            string cccd = AS_textBox_cccd.Text;
            string gender = AS_comboBox_gender.Text;

            string email = AS_textBox_email.Text;
            string phone = AS_textBox_phone.Text;

            string address = textBox_address.Text;

            byte[] image = null;
            MemoryStream ms = new MemoryStream();
            AS_pictureBox_user.Image.Save(ms, AS_pictureBox_user.Image.RawFormat);
            image = ms.ToArray();
            //if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            if (ul.insertUser(type, username, birthdate, address, cccd, image, email, gender, dp, lv, phone))
            {
                MessageBox.Show("New User Added", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fail to add new user", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Fail to fill information new user", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void AS_button_upload_Click(object sender, EventArgs e)
        {
            // `OpenFileDialog` cho phép người dùng chọn một hoặc nhiều tập tin từ hệ thống tệp tin.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                AS_pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        private void AS_textBox_username_Validating(object sender, CancelEventArgs e)
        {

        }

        private void AS_textBox_phone_Validating(object sender, CancelEventArgs e)
        {

        }

        private void AS_dateTimePicker_birthdate_Validating(object sender, CancelEventArgs e)
        {

        }

        private void AS_textBox_email_Validating(object sender, CancelEventArgs e)
        {

        }

        private void AS_textBox_cccd_Validating(object sender, CancelEventArgs e)
        {

        }

        // RM
        private bool VerifySelectedReq()
        {
            if (string.IsNullOrEmpty(RM_textBox_sender.Text) || string.IsNullOrEmpty(RM_textBox_subject.Text))
            {
                MessageBox.Show("Please, select a specific request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RM_showTable()
        {
            //RM_dataGridView_req.ReadOnly = true;
            RM_dataGridView_req.DataSource = reqBll.GetRequestReceiver(Users.PK);
        }

        private void RM_button_accept_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {

                if (RM_textBox_status.Text.Equals("Chưa xử lí"))
                {
                    reqBll.UpdateRequestStatus(RM_textBox_sender.Text, Users.PK, "Đã xử lí");
                    MessageBox.Show("Accept request successfully");
                    RM_showTable();
                }
                else
                {
                    MessageBox.Show("Request has already processed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RM_button_reject_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {
                if (RM_textBox_status.Text.Equals("Chưa xử lí"))
                {
                    reqBll.UpdateRequestStatus(RM_textBox_sender.Text, Users.PK, "Từ chối xử lí");
                    MessageBox.Show("Reject request successfully");
                }
                else
                {
                    MessageBox.Show("Request has already processed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RM_dataGridView_req_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string req_id = RM_dataGridView_req.CurrentRow.Cells["R_ID"].Value.ToString();
            RM_textBox_sender.Text = RM_dataGridView_req.CurrentRow.Cells["SENDER_ID"].Value.ToString();
            RM_textBox_subject.Text = RM_dataGridView_req.CurrentRow.Cells["R_DES"].Value.ToString();
            RM_textBox_content.Text = RM_dataGridView_req.CurrentRow.Cells["R_CONTENT"].Value.ToString();
            RM_textBox_status.Text = RM_dataGridView_req.CurrentRow.Cells["R_STATUS"].Value.ToString();
            RM_dateTimePicker_sentDay.Value = (DateTime)RM_dataGridView_req.CurrentRow.Cells["R_DATE"].Value;

            RM_dataGridView_files.ReadOnly = true;
            RM_dataGridView_files.DataSource = reqBll.GetFileFromRequest(req_id);
            RM_dataGridView_files.Columns["F_FILE"].Visible = false;
            RM_dataGridView_files.Columns["F_ID"].Visible = false;
            RM_dataGridView_files.Columns["R_ID"].Visible = false;
        }

        private void RM_dataGridView_files_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (VerifySelectedReq())
            {
                string filename = RM_dataGridView_files.CurrentRow.Cells["F_NAME"].Value.ToString();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text documents (.pdf)|*.pdf|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to download this file", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Default filename
                        //sfd.FileName = filename;


                        if (dialog == DialogResult.Yes)
                        {
                            filename = sfd.FileName;
                            try
                            {
                                byte[] fileData = (byte[])RM_dataGridView_files.CurrentRow.Cells["F_FILE"].Value;
                                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    using (BinaryWriter bw = new BinaryWriter(fs))
                                    {
                                        bw.Write(fileData);
                                        bw.Close();
                                    }
                                }
                                MessageBox.Show("Saved file in " + filename);
                            }
                            catch
                            {
                                MessageBox.Show("File is not found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void SM_btBack_Click(object sender, EventArgs e)
        {
            pages.SetPage(0);
        }

        private void notify_Click(object sender, EventArgs e)
        {
                NotiForm f = new NotiForm();
                f.Show();
        }

        private void SM_tb_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               SM_button_search_user_Click(sender, e);

        }

        private void SM_dropdown_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SM_dropdown_filter.Text == "Disabled")
            {
                SM_loadTableDis();
                SM_dropdown_filter.Text = "Disabled Staffs";
                SM_btDisable.Text = "Enable";
                SM_button_update.Visible = false;
            }
            else if (SM_dropdown_filter.Text == "Active")
            {
                SM_showTable();
                SM_dropdown_filter.Text = "Active Staffs";
                SM_btDisable.Text = "Disable";
                SM_button_update.Visible = true;
            }
        }

        private void SM_dataGridView_user_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = "Staff Information";
            bunifuSeparator16.Width = 300;
            PF_button_changePass.Visible = false;
            SM_btDisable.Visible = true;
            SM_button_update.Visible = true;
            SM_button_see_project.Visible = true;
            PF_textBox_username.Enabled = true;
            PF_dateTimePicker_birthdate.Enabled = true;
            PF_textBox_email.Enabled = true;
            PF_textBox_cccd.Enabled = true;
            PF_comboBox_gender.Enabled = true;
            PF_comboBox_enable.Enabled = true;
            PF_textBox_pass.Enabled = true;
            PF_comboBox_type.Enabled = true;
            PF_comboBox_lv.Enabled = true;
            PF_comboBox_dp.Enabled = true;
            PF_textBox_addr.Enabled = true;
            PF_textBox_phone.Enabled = true;

            curr_pk = SM_dataGridView_user.CurrentRow.Cells["ID"].Value.ToString();
            PF_textBox_username.Text = SM_dataGridView_user.CurrentRow.Cells["FULL NAME"].Value.ToString();
            PF_dateTimePicker_birthdate.Value = (DateTime)SM_dataGridView_user.CurrentRow.Cells["BIRTH DATE"].Value;
            PF_textBox_email.Text = SM_dataGridView_user.CurrentRow.Cells["EMAIL"].Value.ToString();
            PF_textBox_cccd.Text = SM_dataGridView_user.CurrentRow.Cells["USER_CCCD"].Value.ToString();
            try
            {
                byte[] img = (byte[])SM_dataGridView_user.CurrentRow.Cells["USER_IMAGE"].Value;
                MemoryStream ms = new MemoryStream(img);
                PF_pictureBox_user.Image = Image.FromStream(ms);
            }
            catch
            {

            }

            PF_textBox_username1.Text = SM_dataGridView_user.CurrentRow.Cells["FULL NAME"].Value.ToString();
            PF_textBox_level1.Text = SM_dataGridView_user.CurrentRow.Cells["POSITION"].Value.ToString();
            PF_comboBox_gender.Text = SM_dataGridView_user.CurrentRow.Cells["GENDER"].Value.ToString();
            PF_comboBox_enable.Text = SM_dataGridView_user.CurrentRow.Cells["U_EN"].Value.ToString();
            PF_textBox_pass.Text = SM_dataGridView_user.CurrentRow.Cells["U_PASS"].Value.ToString();
            PF_comboBox_type.Text = SM_dataGridView_user.CurrentRow.Cells["TYPE"].Value.ToString();
            PF_comboBox_lv.Text = SM_dataGridView_user.CurrentRow.Cells["POSITION"].Value.ToString();
            PF_comboBox_dp.Text = SM_dataGridView_user.CurrentRow.Cells["DEPARTMENT"].Value.ToString();
            PF_textBox_addr.Text = SM_dataGridView_user.CurrentRow.Cells["USER_ADDRESS"].Value.ToString();
            PF_textBox_phone.Text = SM_dataGridView_user.CurrentRow.Cells["PHONE"].Value.ToString();

            if (PF_comboBox_enable.Text.Equals("1"))
            {
                PF_comboBox_enable.Text = "ACTIVE";
                PF_comboBox_enable.ForeColor = Color.Green;
            }
            else
            {
                PF_comboBox_enable.Text = "DISABLE";
                PF_comboBox_enable.ForeColor = Color.Red;
            }

            pages.SetPage(4);
        }

        private void NT_GetReceiveNoti()
        {
            DataTable dt = notiBLL.GetNotiOfReceiver(Users.PK);
            if (dt != null)
            {
                dt.Columns["N_DATE"].ColumnName = "DATE SEND";
                dt.Columns["N_DES"].ColumnName = "DESCRIPTION";

                NT_dataGridView_notiList.DataSource = dt;

                NT_dataGridView_notiList.Columns["N_ID"].Visible = false;
                NT_dataGridView_notiList.Columns["N_S_ID"].Visible = false;
                NT_dataGridView_notiList.Columns["N_ISREAD"].Visible = false;

                int dateSendIndex = NT_dataGridView_notiList.Columns["DATE SEND"].Index;
                int descriptionIndex = NT_dataGridView_notiList.Columns["DESCRIPTION"].Index;

                // Đổi vị trí của hai cột
                NT_dataGridView_notiList.Columns["DATE SEND"].DisplayIndex = descriptionIndex;
                NT_dataGridView_notiList.Columns["DESCRIPTION"].DisplayIndex = dateSendIndex;
                NT_dataGridView_notiList.Columns["DATE SEND"].Width = 125;

                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row != null)
                    {
                        if (NT_dataGridView_notiList.Rows[i].Cells["N_ISREAD"].Value.ToString() == "0")
                        {
                            NT_dataGridView_notiList.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 11.00F, FontStyle.Bold);
                        }
                    }
                    i += 1;
                }
            }
        }

        private void NT_comboBox_notiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NT_dataGridView_notiList.Columns.Clear();
            if (NT_comboBox_notiType.Text == "Receive")
            {
                NT_GetReceiveNoti();
            }
            else
            {
                NT_GetSendNoti();
            }
        }

        private void NT_GetSendNoti()
        {
            DataTable dt = notiBLL.GetNotiOfSender(Users.PK);
            if (dt != null)
            {
                dt.Columns["N_DATE"].ColumnName = "SEND DATE";
                dt.Columns["N_DES"].ColumnName = "DESCRIPTION";

                NT_dataGridView_notiList.DataSource = dt;

                NT_dataGridView_notiList.Columns["N_ID"].Visible = false;
                NT_dataGridView_notiList.Columns["N_S_ID"].Visible = false;

                int dateSendIndex = NT_dataGridView_notiList.Columns["SEND DATE"].Index;
                int descriptionIndex = NT_dataGridView_notiList.Columns["DESCRIPTION"].Index;

                // Đổi vị trí của hai cột
                NT_dataGridView_notiList.Columns["SEND DATE"].DisplayIndex = descriptionIndex;
                NT_dataGridView_notiList.Columns["DESCRIPTION"].DisplayIndex = dateSendIndex;
                NT_dataGridView_notiList.Columns["SEND DATE"].Width = 125;
            }
        }

        private void NT_dataGridView_notiList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NT_textBox_sender.Text = NT_dataGridView_notiList.CurrentRow.Cells["N_S_ID"].Value.ToString();
            NT_textBox_content.Text = NT_dataGridView_notiList.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
            String notiID = NT_dataGridView_notiList.CurrentRow.Cells["N_ID"].Value.ToString();

            // Update read notification
            if (!notiBLL.UpdateNotiRead(notiID, Users.PK))
                MessageBox.Show("Fail to update read notification");
            else
                notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);

            // Reload
            //NT_loadReceiver();
            //NT_GetReceiveNoti();
        }

        private void btn_notify_Click(object sender, EventArgs e)
        {
            NT_comboBox_notiType_SelectedIndexChanged(sender, e);
            pages.SetPage(6);
        }

        private void PF_comboBox_enable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PF_comboBox_enable.Text.Equals("ACTIVE"))
            {
                PF_comboBox_enable.ForeColor = Color.Green;
            }
            else
            {
                PF_comboBox_enable.ForeColor = Color.Red;
            }
        }

        private void PM_btn_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(4);
        }
    }
}
