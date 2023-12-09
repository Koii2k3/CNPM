using BLL;
using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class PageControlStaff : Form
    {
        //FE
        Boolean AsT_added_downloadbtn = false;

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
        NotiBLL notiBLL = new NotiBLL();
        DataTable dt = null;
        int PM_pageindex = 1;
        int role = 0;
        String taskID = "";
        String curTaskjHL;
        String taskState;
        List<string> subTasks = new List<string>();
        List<String> assignee_PKs = new List<String>();
        String curManagePjPK;
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

        public PageControlStaff()
        {
            InitializeComponent();
        }

        private void PageControlStaff_Load(object sender, EventArgs e)
        {
            loading_panel.Visible = true;
            progress_circle.ValueByTransition = 25;
            //FE
            buttonColumn.HeaderText = "Download";
            buttonColumn.Name = "downloadButtonColumn";
            buttonColumn.Text = "Download";
            buttonColumn.FlatStyle = FlatStyle.Standard;
            buttonColumn.DefaultCellStyle.BackColor = Color.Transparent;
            buttonColumn.DefaultCellStyle.ForeColor = Color.Black;
            buttonColumn.UseColumnTextForButtonValue = true;

            progress_circle.ValueByTransition = 50;
            notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);

            btn_myproject_Click(sender, e);
            progress_circle.ValueByTransition = 75;

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
            end_loading();
        }

        public void end_loading()
        {
            progress_circle.TransitionValue(100, 200);
            Timer timer = new Timer();
            timer.Interval = 300;
            timer.Tick += (source, e) => { loading_panel.Visible = false; timer.Stop(); };
            timer.Start();
        }

    //Profile - button - change password - click()
        private void PF_button_changePass_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        // Navbar
        private void btn_myproject_Click(object sender, EventArgs e)
        {
            MP_loadProject();
            pages.SetPage(1);
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
                PF_textBox_level1.Text = Users.LV_NAME;
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
            pages.SetPage(3);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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
            pages.SetPage(5);
            RP_tCurrPass.Text = "";
            RP_tNewPass1.Text = "";
            RP_tNewPass2.Text = "";
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

        private void SR_button_clearFiles_Click(object sender, EventArgs e)
        {
            files.Clear();
            SR_comboBox_files.Items.Clear();
        }

        private void MP_loadProject()
        {
            dt = pj.getProjectOfUser(Users.PK);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count < 8)
                    {
                        PM_btn_next.Enabled = false;
                        PM_pageid.Enabled = false;
                    }
                    else
                    {
                        PM_btn_next.Enabled = true;
                        PM_pageid.Enabled = true;
                    }
                    MP_parcelLoadProject();
                }
            }
            else
            {
                PM_btn_next.Enabled = false;
                PM_pageid.Enabled = false;
            }
        }

        private void MP_parcelLoadProject()
        {
            mpj_tableLP.Controls.Clear();
            ProjectTemplate[] pjs = new ProjectTemplate[1];
            Random rnd = new Random();
            String title = string.Empty;
            String des = string.Empty;
            String dl = string.Empty;
            String ver = string.Empty;
            String task = string.Empty;
            DateTime dtime = DateTime.Parse("1/1/1973");

            for (int i = 0; i < 1; i++)
            {
                for (int j = 8 * (PM_pageindex - 1); j <= 8 * PM_pageindex; j++)
                {
                    if (j == dt.Rows.Count) break;
                    pjs[i] = new ProjectTemplate();

                    //MemoryStream ms = new MemoryStream();
                    title = dt.Rows[j]["PJ_NAME"].ToString();
                    pjs[i].Title = title;
                    pjs[i].pjTask = "999";
                    pjs[i].Description = dt.Rows[j]["PJ_DES"].ToString();
                    pjs[i].Start = dt.Rows[j]["PJ_START"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_START"]);
                    pjs[i].Exp = dt.Rows[j]["PJ_EXPECT_FIN"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_EXPECT_FIN"]);
                    pjs[i].End = dt.Rows[j]["PJ_FINISH"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_FINISH"]);
                    pjs[i].Version = dt.Rows[j]["PJ_VERSION"].ToString();
                    pjs[i].Deadline = dt.Rows[j]["PJ_FINISH"] == DBNull.Value ? "Unknown" : Convert.ToDateTime(dt.Rows[j]["PJ_FINISH"]).ToString();
                    pjs[i].ID = dt.Rows[j]["PJ_ID"].ToString();
                    pjs[i].PageNum = 0;
                    pjs[i].ID = dt.Rows[j]["PJ_ID"].ToString();
                    pjs[i].dataRow = dt.Rows[j];
                    pjs[i].ManagerID = dt.Rows[j]["USER_ID"].ToString();

                    pjs[i].PD_ProgressBarValue = PD_progressBarValue;
                    pjs[i].PD_ProgressBar = PD_progressBar_pj;
                    pjs[i].PD_ID = PD_txt_id;
                    pjs[i].PD_Title = PD_txt_proname;
                    pjs[i].PD_Ver = PD_txt_prover;
                    pjs[i].PD_Scale = PD_cb_proscale;
                    pjs[i].PD_Status = PD_txt_status;
                    pjs[i].PD_Task = PD_dataGridView_task;
                    pjs[i].PD_Member = PD_dataGridView_member;
                    pjs[i].PD_Description = PD_txt_prodes;
                    pjs[i].PD_Start = PD_dp_start;
                    pjs[i].PD_Exp = PD_dp_expect;
                    pjs[i].PD_Dl = PD_dp_dl;
                    if (dt.Rows[j]["PJ_PUBLIC"].ToString().Equals('1'))
                        pjs[i].pjScale = "Public";
                    else
                        pjs[i].pjScale = "Private";

                    pjs[i].LineColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    pjs[i].Pages = pages;

                    mpj_tableLP.Controls.Add(pjs[i]);
                }
            }
        }

        private void PD_comboBox_filterTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable allTasks = null;

            if (PD_comboBox_filterTask.Text.Equals("Completed"))
            {
                allTasks = task.GetTaskWithStatus(PD_txt_id.Text, 2);
            }
            else if (PD_comboBox_filterTask.Text.Equals("In progress"))
            {
                allTasks = task.GetTaskWithStatus(PD_txt_id.Text, 1);
            }
            else if (PD_comboBox_filterTask.Text.Equals("New"))
            {
                allTasks = task.GetTaskWithStatus(PD_txt_id.Text, 0);
            }
            else
            {
                allTasks = task.GetTaskOfProject(PD_txt_id.Text);
            }

            if (allTasks != null)
            {
                allTasks.Columns["J_NAME"].ColumnName = "TASK NAME";
                allTasks.Columns["J_START"].ColumnName = "START DATE";
                allTasks.Columns["J_DEADLINE"].ColumnName = "DEADLINE";
                allTasks.Columns["J_STATUS"].ColumnName = "STATE";

                PD_dataGridView_task.DataSource = allTasks;

                PD_dataGridView_task.Columns["J_DES"].Visible = false;
                PD_dataGridView_task.Columns["J_ID"].Visible = false;
                PD_dataGridView_task.Columns["J_FINISH"].Visible = false;
                PD_dataGridView_task.Columns["J_HL"].Visible = false;
                PD_dataGridView_task.Columns["PJ_ID"].Visible = false;
                PD_dataGridView_task.Columns["J_DONE"].Visible = false;

                int i = 0;
                foreach (DataRow row in allTasks.Rows)
                {
                    if (row != null)
                    {
                        if (PD_dataGridView_task.Rows[i].Cells["STATE"].Value.ToString() == "0")
                        {
                            PD_dataGridView_task.Rows[i].Cells["STATE"].Value = "New task";
                        }
                        else if (PD_dataGridView_task.Rows[i].Cells["STATE"].Value.ToString() == "1")
                        {
                            PD_dataGridView_task.Rows[i].Cells["STATE"].Value = "In processing task";
                            PD_dataGridView_task.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                        else
                        {
                            PD_dataGridView_task.Rows[i].Cells["STATE"].Value = "Completed task";
                            PD_dataGridView_task.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    i += 1;
                }
            }
        }

        private void PD_btn_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(1);
        }

        private void PM_pageid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (PM_pageid.Text != "")
                {
                    if (int.Parse(PM_pageid.Text) <= Math.Ceiling((dt.Rows.Count) / 8.0))
                    {
                        PM_pageindex = int.Parse(PM_pageid.Text);
                        PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                        PM_pageid.Text = string.Empty;
                        MP_parcelLoadProject();
                    }
                }
            }
        }

        private void PM_btn_next_Click(object sender, EventArgs e)
        {
            if (PM_pageindex < Math.Ceiling((dt.Rows.Count) / 8.0))
            {
                PM_btn_previous.Enabled = true;
                PM_pageindex += 1;
                PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                PM_pageid.Text = string.Empty;
                MP_parcelLoadProject();
            }
            if (PM_pageindex == Math.Ceiling((dt.Rows.Count) / 8.0))
            {
                PM_btn_next.Enabled = false;
            }
        }

        private void PM_btn_previous_Click(object sender, EventArgs e)
        {
            if (PM_pageindex > 1)
            {
                PM_btn_next.Enabled = true;
                PM_pageindex -= 1;
                PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                PM_pageid.Text = string.Empty;
                MP_parcelLoadProject();
            }
            if (PM_pageindex == 1)
            {
                PM_btn_previous.Enabled = false;
            }
        }

        private void PD_dataGridView_task_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow curTask = task.GetTaskInfo(PD_dataGridView_task.CurrentRow.Cells["J_ID"].Value.ToString());
            taskID = curTask["J_ID"].ToString();
            taskState = curTask["J_STATUS"].ToString();
            curTaskjHL = curTask["J_HL"].ToString();
            PD_btn_addtask_Click(sender, e);
        }
        private void PD_btn_addtask_Click(object sender, EventArgs e)
        {
            AsT_comboBox_submitFiles.Items.Clear();
            AsT_dataGridView_assignees.Columns.Clear();
            AsT_dataGridView_submitFiles.Columns.Clear();
            AsT_dataGridView_subtasks.Columns.Clear();

            AsT_textBox_taskName.Text = "";
            AsT_textBox_taskDesc.Text = "";
            AsT_dateTimePicker_start.Value = DateTime.Now;
            AsT_dateTimePicker_end.Value = DateTime.Now;
            AsT_dataGridView_submitFiles.Visible = true;

            if (taskState == "0")
            {
                AsT_textBox_taskState.ForeColor = Color.Gray;
                AsT_textBox_taskState.Text = "New task";
            }
            else if (taskState == "1")
            {
                AsT_textBox_taskState.ForeColor = Color.Green;
                AsT_textBox_taskState.Text = "In processing task";
            }
            else
            {
                AsT_textBox_taskState.ForeColor = Color.Blue;
                AsT_textBox_taskState.Text = "Completed task";
            }

            AsT_loadTaskInfo();
            pages.SetPage(6);
        }

        private void AsT_getSubtasksList()
        {
            if (taskID != "")
            {
                foreach (DataGridViewRow row in AsT_dataGridView_subtasks.Rows)
                {
                    // Check if the current row is not the header row
                    if (!row.IsNewRow && row.Cells["SJ_ID"].Value.ToString() != "")
                    {
                        // Access the cell value of a specific column using the column index or column name
                        string cellValue = row.Cells["SUBTASK NAME"].Value.ToString();
                        subTasks.Add(cellValue);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in AsT_dataGridView_subtasks.Rows)
                {
                    // Check if the current row is not the header row
                    if (!row.IsNewRow)
                    {
                        // Access the cell value of a specific column using the column index or column name
                        string cellValue = row.Cells["SUBTASK NAME"].Value.ToString();
                        subTasks.Add(cellValue);
                    }
                }
            }
        }

        private void AsT_loadTaskInfo()
        {
            DataRow taskInfo = task.GetTaskInfo(this.taskID);
            AsT_textBox_taskName.Text = taskInfo["J_NAME"].ToString();
            AsT_textBox_taskDesc.Text = taskInfo["J_DES"].ToString();
            AsT_dateTimePicker_start.Value = (DateTime)taskInfo["J_START"];
            AsT_dateTimePicker_end.Value = (DateTime)taskInfo["J_DEADLINE"];

            AsT_textBox_pjName.Text = PD_txt_proname.Text;

            DataTable assigneesOfTask = task.GetUserOfTask(this.taskID);

            if (assigneesOfTask != null) {
                assigneesOfTask.Columns["USER_NAME"].ColumnName = "FULL NAME";
                assigneesOfTask.Columns["USER_GENDER"].ColumnName = "GENDER";
                assigneesOfTask.Columns["USER_IMAGE"].ColumnName = "AVATAR";
                assigneesOfTask.Columns["USER_PHONE"].ColumnName = "PHONE";
                assigneesOfTask.Columns["USER_EMAIL"].ColumnName = "EMAIL";

                AsT_dataGridView_assignees.DataSource = assigneesOfTask;
                AsT_dataGridView_assignees.Columns["USER_ID"].Visible = false;
                AsT_dataGridView_assignees.Columns["USER_BIRTH"].Visible = false;
                AsT_dataGridView_assignees.Columns["USER_CCCD"].Visible = false;
                AsT_dataGridView_assignees.Columns["USER_ADDRESS"].Visible = false;
                AsT_dataGridView_assignees.Columns["AVATAR"].DisplayIndex = 0;
                AsT_dataGridView_assignees.Columns["AVATAR"].Width = 100;
                AsT_dataGridView_assignees.Columns["GENDER"].Width = 75;
                AsT_dataGridView_assignees.Columns["PHONE"].Width = 125;

                DataGridViewImageColumn AsT_dataGridView_assignees1 = (DataGridViewImageColumn)AsT_dataGridView_assignees.Columns["AVATAR"];
                AsT_dataGridView_assignees1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }


            DataTable subTasks = task.GetAllSubTaskOfTask(this.taskID, -1);
            if (subTasks != null)
            {
                DataColumn newColumn = new DataColumn("STATUS", typeof(bool));
                subTasks.Columns.Add(newColumn);
                foreach (DataRow row in subTasks.Rows)
                {
                    String isDone = row["SJ_DONE"].ToString();
                    if (isDone.Equals("1"))
                    {
                        row["STATUS"] = true;
                    }
                    else
                    {
                        row["STATUS"] = false;
                    }
                }
                subTasks.Columns.Remove("SJ_DONE");
                subTasks.Columns["SJ_NAME"].ColumnName = "SUBTASK NAME";
                AsT_dataGridView_subtasks.DataSource = subTasks;
                AsT_dataGridView_subtasks.Columns["SJ_ID"].Visible = false;
                AsT_dataGridView_subtasks.Columns["J_ID"].Visible = false;
                AsT_dataGridView_subtasks.Columns["STATUS"].Width = 75;
            }

            DataTable taskResource = task.GetResourceOfTask(taskID);
            if (taskResource != null)
            {
                taskResource.Columns["RE_DATE"].ColumnName = "UPLOAD DATE";
                taskResource.Columns["F_NAME"].ColumnName = "FILE NAME";
                AsT_dataGridView_resources.DataSource = taskResource;
                AsT_dataGridView_resources.Columns["JM_ID"].Visible = false;
                AsT_dataGridView_resources.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_resources.Columns["RE_FILE"].Visible = false;

                // Thêm cột button vào DataGridView
                if (!AsT_added_downloadbtn)
                {
                    AsT_dataGridView_resources.Columns.Add(buttonColumn);
                    AsT_dataGridView_resources.Columns["UPLOAD DATE"].Width = 150;
                    AsT_dataGridView_resources.Columns["downloadButtonColumn"].Width = 100;
                    AsT_added_downloadbtn = true;
                }
            }

            DataTable taskSubmittedFile = task.GetSubmitFileOfTask(taskID);
            if (taskSubmittedFile != null)
            {
                AsT_dataGridView_submitFiles.DataSource = taskSubmittedFile;
                AsT_dataGridView_submitFiles.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_submitFiles.Columns["RE_FILE"].Visible = false;
            }
        }

        private void AsT_button_assign_Click(object sender, EventArgs e)
        {
            String taskName = AsT_textBox_taskName.Text;
            String taskDesc = AsT_textBox_taskDesc.Text;
            DateTime start = AsT_dateTimePicker_start.Value;
            DateTime end = AsT_dateTimePicker_end.Value;

            // For info of current task
            String contentAssign = "Task: '" + taskName + "'" + "\n In project: " + AsT_textBox_pjName.Text +
                        "is UPDATED\nAt: " + DateTime.Now.ToString() + "\n"
                        + "Please, come to project and get new information";

            if (task.UpdateTask(curManagePjPK, contentAssign, taskID, taskName, taskDesc,
                start, end, null, int.Parse(curTaskjHL), taskState, assignee_PKs, subTasks, files))
            {
                MessageBox.Show("Update task successfully");
                AsT_getSubtasksList();
                taskID = "";
            }
            else
            {
                MessageBox.Show("Fail to update task");
            }
        }

        private void AsT_btn_close_Click(object sender, EventArgs e)
        {
            taskID = "";
            pages.SetPage(0);
        }

        private void AsT_dataGridView_submitFiles_DoubleClick(object sender, EventArgs e)
        {
            if (AsT_dataGridView_submitFiles.CurrentRow != null)
            {
                string filename = AsT_dataGridView_submitFiles.CurrentRow.Cells["FILE NAME"].Value.ToString();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text documents (.pdf)|*.pdf|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to download this file", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {
                            filename = sfd.FileName;
                            try
                            {
                                byte[] fileData = (byte[])AsT_dataGridView_submitFiles.CurrentRow.Cells["RE_FILE"].Value;
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

        private void AsT_comboBox_submitFiles_SizeChanged(object sender, EventArgs e)
        {
            if (AsT_comboBox_submitFiles.Items.Count > 0)
            {
                AsT_comboBox_submitFiles.Text = AsT_comboBox_submitFiles.Items[AsT_comboBox_submitFiles.Items.Count - 1].ToString();
            }
        }

        private void AsT_button_clearFiles_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                files.RemoveAt(files.Count - 1);
                AsT_comboBox_submitFiles.Items.RemoveAt(AsT_comboBox_submitFiles.Items.Count - 1);
            }
        }

        private void AsT_button_submitFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string file_name = System.IO.Path.GetFileName(file);
                    AsT_comboBox_submitFiles.Items.Add(file_name);
                    files.Add(file);
                }
                MessageBox.Show("Uploaded " + files.Count + " successfully");
            }
        }

        private void AsT_dataGridView_resources_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AsT_dataGridView_resources.Columns["downloadButtonColumn"].Index && e.RowIndex >= 0)
            {
                string filename = AsT_dataGridView_resources.CurrentRow.Cells["F_NAME"].Value.ToString();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text documents (.pdf)|*.pdf|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to download this file", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {
                            filename = sfd.FileName;
                            try
                            {
                                byte[] fileData = (byte[])AsT_dataGridView_resources.CurrentRow.Cells["RE_FILE"].Value;
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

        private void AsT_dataGridView_resources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AsT_dataGridView_resources.Columns["downloadButtonColumn"].Index && e.RowIndex >= 0)
            {
                string filename = AsT_dataGridView_resources.CurrentRow.Cells["FILE NAME"].Value.ToString();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text documents (.pdf)|*.pdf|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to download this file", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog == DialogResult.Yes)
                        {
                            filename = sfd.FileName;
                            try
                            {
                                byte[] fileData = (byte[])AsT_dataGridView_resources.CurrentRow.Cells["RE_FILE"].Value;
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

        // Nt page
        private void NT_GetReceiveNoti()
        {
            DataTable dt = receive_noti_data;
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

        DataTable receive_noti_data;
        DataTable send_noti_data;
        private void NT_comboBox_notiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NT_dataGridView_notiList.Columns.Clear();
            if (NT_comboBox_notiType.Text == "Receive")
            {
                receive_noti_data = notiBLL.GetNotiOfReceiver(Users.PK);
                NT_GetReceiveNoti();
            }
            else
            {
                send_noti_data = notiBLL.GetNotiOfSender(Users.PK);
                NT_GetSendNoti();
            }
        }

        private void NT_GetSendNoti()
        {
            DataTable dt = send_noti_data;
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

        private void NT_loadReceiver()
        {
            DataTable dt = notiBLL.GetReceiverOfNoti(Users.PK);
            if (dt == null)
            {
                NT_comboBox_receiverOfNoti.Text = "Members of Project";
            }
            else
            {
                foreach (DataRow receiver in dt.Rows)
                {
                    NT_comboBox_receiverOfNoti.Items.Add(receiver["N_R_ID"]);
                }
            }
        }

        private void NT_dataGridView_notiList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NT_textBox_sender.Text = NT_dataGridView_notiList.CurrentRow.Cells["N_S_ID"].Value.ToString();
            NT_textBox_content.Text = NT_dataGridView_notiList.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
            String notiID = NT_dataGridView_notiList.CurrentRow.Cells["N_ID"].Value.ToString();

            // Update read notification
            if (NT_dataGridView_notiList.CurrentRow.Cells["N_ISREAD"].Value.ToString() == "0")
            {
                if (!notiBLL.UpdateNotiRead(notiID, Users.PK))
                {
                    MessageBox.Show("Fail to update read notification");
                }
            }

            if (NT_dataGridView_notiList.CurrentRow.Cells["N_ISREAD"].Value.ToString() == "0")
            {
                NT_dataGridView_notiList.CurrentRow.Cells["N_ISREAD"].Value = 1;
                NT_dataGridView_notiList.CurrentRow.DefaultCellStyle.Font = new Font("Segoe UI", 12.00F, FontStyle.Regular);
                notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);
            }

            // Reload
            NT_loadReceiver();
            //NT_GetReceiveNoti();
        }

        private void btn_notify_Click(object sender, EventArgs e)
        {
            NT_comboBox_notiType_SelectedIndexChanged(sender, e);
            pages.SetPage(7);
        }

        Boolean isBolded = false;
        private void page_noti_MouseEnter(object sender, EventArgs e)
        {
            if (!isBolded)
            {
                int i = 0;
                foreach (DataRow row in receive_noti_data.Rows)
                {
                    if (row != null)
                    {
                        if (NT_dataGridView_notiList.Rows[i].Cells["N_ISREAD"].Value.ToString() == "0")
                        {
                            NT_dataGridView_notiList.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 12.00F, FontStyle.Bold);
                        }
                    }
                    i += 1;
                }
            }
        }
    }
}
