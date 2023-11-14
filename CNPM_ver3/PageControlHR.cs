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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CNPM_ver3
{
    public partial class PageControlHR : Form
    {
        //PM 
        int percentage = 0;
        int flag = 0;
        string curr_pj_id = null;
        string curr_pk = "";
        List<string> files = new List<string>();
        UserBLL ul = new UserBLL();
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();
        RequestBLL reqBll = new RequestBLL();
        BackgroundWorker bgWorker = new BackgroundWorker();

        public PageControlHR()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        }

        private void PageControlHR_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();

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

        private void PageControlHR_Shown(object sender, EventArgs e)
        {
            //bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            load_page_HR(sender, e);
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bunifuProgressBar1.TransitionValue(e.ProgressPercentage, 500);
        }

        private void load_page_HR(object sender, EventArgs e)
        {
            pages.SetPage(0);
            Users.SPU = false;
            SM_loadTable();
        }

        private void btn_staffmanagement_Click(object sender, EventArgs e)
        {
            pages.SetPage(0);
            Users.SPU = false;
            //percentage = 0;
            //SM_loadTable();
            if (bgWorker.IsBusy == false) {
                bgWorker.RunWorkerAsync();
            }
        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                AS_comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                AS_comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                AS_comboBox_dp.Items.Add(t);
            }
            pages.SetPage(2);
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
            pages.SetPage(4);
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            pages.SetPage(5);
        }

        private void btn_projectmanagement_Click(object sender, EventArgs e)
        {
            PM_showPj();
            pages.SetPage(1);
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

                PM_txt_proname.Text = PM_dataGridView_project.CurrentRow.Cells["PJ_NAME"].Value.ToString();
                PM_txt_prodes.Text = PM_dataGridView_project.CurrentRow.Cells["PJ_DES"].Value.ToString();

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
                PM_dataGridView_project.DataSource = pj.getProjectOfUser(Users.CSU);
                Users.SPU = false;
            }
            else
            {
                PM_dataGridView_project.DataSource = pj.GetProjectInfoAllOfMan(Users.PK);
            }
        }

        public void PM_showTask()
        {
            PM_dataGridView_task.DataSource = task.GetTaskOfProject(curr_pj_id);
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

        //AM 
        public void AM_showTableOutPj()
        {
            AM_dataGridView_user.ReadOnly = true;
            AM_dataGridView_user.DataSource = ul.GetUserByLevel(0);
            AM_dataGridView_user.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)AM_dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        public void AM_showTableInPj()
        {
            AM_dataGridView_mInProject.ReadOnly = true;
            AM_dataGridView_mInProject.DataSource = pj.GetUserOfProject(curr_pj_id);
            AM_dataGridView_mInProject.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)AM_dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void AM_dataGridView_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            string u_email = AM_dataGridView_user.CurrentRow.Cells["USER_EMAIL"].Value.ToString();
            string u_id = AM_dataGridView_user.CurrentRow.Cells["USER_ID"].Value.ToString();
            if (pj.AddMember2Project(u_id, u_email, curr_pj_id))
            {
                MessageBox.Show(Properties.Resources.add_mem_2_pj_success);
                // Hide row
                int rowindex = AM_dataGridView_user.CurrentRow.Index;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[AM_dataGridView_user.DataSource];
                currencyManager1.SuspendBinding();
                AM_dataGridView_user.Rows[rowindex].Visible = false;
                currencyManager1.ResumeBinding();

                // Update member in project table
                AM_showTableInPj();
            }
            else
            {
                MessageBox.Show(Properties.Resources.add_mem_2_pj_fail);
            }
        }

        private void AM_dataGridView_mInProject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            string u_pk = AM_dataGridView_mInProject.CurrentRow.Cells["USER_ID"].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (pj.DelMemberFromProject(u_pk, curr_pj_id))
                {
                    MessageBox.Show("Delete member from project successfully");
                    // Hide row
                    AM_dataGridView_mInProject.Rows.RemoveAt(AM_dataGridView_mInProject.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Fail to delete member from project successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AM_btn_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(1);
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
            pages.SetPage(4);
            RP_tCurrPass.Text = "";
            RP_tNewPass1.Text = "";
            RP_tNewPass2.Text = "";
        }

        //SM
        public void SM_loadTable()
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                SM_comboBox_type.Invoke((Action)delegate
                {
                    SM_comboBox_type.Items.Add(t);
                });
            }

            percentage = 20;
            bgWorker.ReportProgress(percentage);

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                SM_comboBox_lv.Invoke((Action)delegate
                 {
                     SM_comboBox_lv.Items.Add(t);
                 });
            }

            percentage = 40;
            bgWorker.ReportProgress(percentage);

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                SM_comboBox_dp.Invoke((Action)delegate
                {
                    SM_comboBox_dp.Items.Add(t);
                });
            }

            percentage = 60;
            bgWorker.ReportProgress(percentage);

            SM_showTable();
        }

        public void SM_showTable()
        {
            SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.Invoke((Action)delegate
            {
                SM_dataGridView_user.DataSource = ul.getUserInfoAll();
            });
            SM_dataGridView_user.RowTemplate.Height = 80;

            percentage = 80;
            bgWorker.ReportProgress(percentage);

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)SM_dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            percentage = 100;
            bgWorker.ReportProgress(percentage);
        }

        private void SM_button_update_Click(object sender, EventArgs e)
        {
            string u_name = SM_textBox_username.Text;
            DateTime bd = SM_dateTimePicker_birthdate.Value;
            string cccd = SM_textBox_cccd.Text;
            string addr = SM_textBox_addr.Text;
            string gd = SM_comboBox_gender.Text;
            string email = SM_textBox_email.Text;
            string vt_name = SM_comboBox_type.Text;
            string u_pass = SM_textBox_pass.Text;
            string lv_name = SM_comboBox_lv.Text;
            string dp_name = SM_comboBox_dp.Text;
            string u_phone = SM_textBox_phone.Text;

            MemoryStream ms = new MemoryStream();
            SM_pictureBox_user.Image.Save(ms, SM_pictureBox_user.Image.RawFormat);
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
                SM_pictureBox_user.Image = Image.FromFile(ofd.FileName);
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
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                SM_comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                SM_comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                SM_comboBox_dp.Items.Add(t);
            }
            SM_showTableDis();
        }

        public void SM_showTableDis()
        {
            SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.DataSource = ul.getUserInfoDis();
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

        // function to switch between disable and enable list
        private void SM_btDisableList_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                SM_loadTableDis();
                flag = 1;
                SM_btDisableList.Text = "Return management form";
                SM_btDisable.Text = "Enable";
                SM_button_update.Visible = false;
                return;
            }

            if (flag == 1)
            {
                SM_loadTable();
                flag = 0;
                SM_btDisableList.Text = "Disabled user list";
                SM_btDisable.Text = "Disable";
                SM_button_update.Visible = true;

                return;

            }
        }

        private void SM_dataGridView_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curr_pk = SM_dataGridView_user.CurrentRow.Cells["USER_ID"].Value.ToString();
            SM_textBox_username.Text = SM_dataGridView_user.CurrentRow.Cells["USER_NAME"].Value.ToString();
            SM_dateTimePicker_birthdate.Value = (DateTime)SM_dataGridView_user.CurrentRow.Cells["USER_BIRTH"].Value;
            SM_textBox_email.Text = SM_dataGridView_user.CurrentRow.Cells["USER_EMAIL"].Value.ToString();
            SM_textBox_cccd.Text = SM_dataGridView_user.CurrentRow.Cells["USER_CCCD"].Value.ToString();

            try
            {
                byte[] img = (byte[])SM_dataGridView_user.CurrentRow.Cells["USER_IMAGE"].Value;
                MemoryStream ms = new MemoryStream(img);
                SM_pictureBox_user.Image = Image.FromStream(ms);
            }
            catch
            {

            }
            SM_comboBox_gender.Text = SM_dataGridView_user.CurrentRow.Cells["USER_GENDER"].Value.ToString();
            SM_comboBox_enable.Text = SM_dataGridView_user.CurrentRow.Cells["U_EN"].Value.ToString();
            SM_textBox_pass.Text = SM_dataGridView_user.CurrentRow.Cells["U_PASS"].Value.ToString();
            SM_comboBox_type.Text = SM_dataGridView_user.CurrentRow.Cells["VT_NAME"].Value.ToString();
            SM_comboBox_lv.Text = SM_dataGridView_user.CurrentRow.Cells["LV_NAME"].Value.ToString();
            SM_comboBox_dp.Text = SM_dataGridView_user.CurrentRow.Cells["PB_NAME"].Value.ToString();
            SM_textBox_addr.Text = SM_dataGridView_user.CurrentRow.Cells["USER_ADDRESS"].Value.ToString();
            SM_textBox_phone.Text = SM_dataGridView_user.CurrentRow.Cells["USER_PHONE"].Value.ToString();
        }

        private void SM_button_search_user_Click(object sender, EventArgs e)
        {
            String description = SM_tb_search_user.Text;
            if (description.Equals(""))
            {
                SM_loadTable();
                return;
            }
            SM_loadTableSearch(description);
        }

        public void SM_loadTableSearch(string description)
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                SM_comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                SM_comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                SM_comboBox_dp.Items.Add(t);
            }
            SM_showTableSearch(description);
        }

        public void SM_showTableSearch(string description)
        {
            SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.DataSource = ul.getUserFromSearch(description);
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

        private void SM_button_see_project_Click(object sender, EventArgs e)
        {
            Users.SPU = true;
            Users.CSU = curr_pk;
            pages.SetPage(11);
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
            if (string.IsNullOrEmpty(AS_textBox_username.Text) || !AS_textBox_username.Text.All(c => Char.IsLetter(c) || c == ' '))
            {
                e.Cancel = true;
                AS_textBox_username.Focus();
            }
        }

        private void AS_textBox_phone_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{10}$");
            if (!r.IsMatch(AS_textBox_phone.Text))
            {
                e.Cancel = true;
                AS_textBox_phone.Focus();
            }
        }

        private void AS_dateTimePicker_birthdate_Validating(object sender, CancelEventArgs e)
        {
            DateTime birthdate = AS_dateTimePicker_birthdate.Value;
            DateTime now = DateTime.Now;
            TimeSpan date_num = now - birthdate;
            int day_age = date_num.Days;
            if (day_age < 6570)
            {
                e.Cancel = true;
            }
        }

        private void AS_textBox_email_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(AS_textBox_email.Text))
            {
                e.Cancel = true;
                AS_textBox_email.Focus();
            }
        }

        private void AS_textBox_cccd_Validating(object sender, CancelEventArgs e)
        {
            if (!AS_textBox_cccd.Text.All(char.IsDigit) || AS_textBox_cccd.Text.Length < 9)
            {
                e.Cancel = true;
                AS_textBox_cccd.Focus();
            }
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

        private void bunifuProgressBar1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {



        }
    }
}
