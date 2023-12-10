using BLL;
using BLLL;
using Bunifu.UI.WinForms;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class PageControlCEO : Form
    {
        // Initialize data
        int PM_pageindex = 1;
        int number_assignee = 1;
        int flag = 0;
        string curr_pj_id = null;
        string curr_pk = "";
        Boolean isDesign = false;
        string Date;
        String curManagePjPK;
        String taskID = "";
        String curTaskjHL;
        String taskState;
        List<string> files = new List<string>();
        List<String> assignee_PKs = new List<String>();
        List<string> asTaskFiles = new List<string>();
        DataTable allProject;
        DataTable dataGridView_user_data = new DataTable();
        List<string> subTasks = new List<string>();
        UserBLL ul = new UserBLL();
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();
        RequestBLL reqBll = new RequestBLL();
        NotiBLL notiBLL = new NotiBLL();
        DataTable dt = null;
        TypeBLL tl = new TypeBLL();
        LevelBLL lv = new LevelBLL();
        DepartmentBLL dp = new DepartmentBLL();
        List<MyItemsTask> timeLineTasks = new List<MyItemsTask>();
        Dictionary<int, string> taskStateMapping = new Dictionary<int, string>();
        Boolean delTask = false;
        String newTaskID = "";

        // constructor
        public PageControlCEO()
        {
            InitializeComponent();
        }

        // Initialize data and settings for UI components 
        private void PageControlCEO_Load(object sender, EventArgs e)
        {

            weekStartDatePicker.Value = DateTime.Today;


            // Task state filter in comboBox
            PD_comboBox_filterTask.Items.Add(Properties.Resources.new_task);
            PD_comboBox_filterTask.Items.Add(Properties.Resources.processing_task);
            PD_comboBox_filterTask.Items.Add(Properties.Resources.done_task);
            PD_comboBox_filterTask.Items.Add(Properties.Resources.all_task);


            // Task state mapping
            taskStateMapping.Add(0, Properties.Resources.new_task);
            taskStateMapping.Add(1, Properties.Resources.processing_task);
            taskStateMapping.Add(2, Properties.Resources.done_task);
            taskStateMapping.Add(-1, Properties.Resources.all_task);


            //FE
            PD_dataGridView_taskTimeLine.RowTemplate.Height = 60;
            NT_dataGridView_notiList.RowTemplate.Height = 60;



            // Make datagridView doesn't display empty row
            PD_dataGridView_member.AllowUserToAddRows = false;
            PD_dataGridView_task.AllowUserToAddRows = false;




            //FE
            loading_panel.Visible = true;
            PD_dataGridView_task.RowTemplate.Height = 50;
            NT_dataGridView_notiList.RowTemplate.Height = 50;

            string[] types = tl.getUserType();
            string[] levels = lv.GetUserLevel();
            string[] dps = dp.GetUserDP();
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
            progress_circle.ValueByTransition = 25;

            dataGridView_user_data = ul.getUserInfoAll();
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
            SM_dropdown_filter.Text = "Active Staffs";
            progress_circle.ValueByTransition = 50;

            //PC
            btn_projectmanagement_Click(sender, e);
            progress_circle.ValueByTransition = 75;

            notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);
            try
            {
                byte[] img = (byte[])Users.USER_IMAGE;
                MemoryStream ms = new MemoryStream(img);
                PC_pictureBox_user.Image = System.Drawing.Image.FromStream(ms);
                PC_label_role.Text = Users.LV_NAME;
                PC_label_username.Text = Users.USER_NAME;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            end_loading();
        }

        // End loading progress bar
        public void end_loading()
        {
            progress_circle.TransitionValue(100, 200);
            Timer timer = new Timer();
            timer.Interval = 300;
            timer.Tick += (source, e) => { loading_panel.Visible = false; timer.Stop(); };
            timer.Start();
        }

        // Go to project detail part
        private void btn_project_Click(object sender, EventArgs e)
        {
            pages.SetPage(0);
        }

        // Go to task detail part
        private void btn_task_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        // Go to request part
        private void btn_request_Click(object sender, EventArgs e)
        {
            pages.SetPage(5);
        }

        // Go to profile part
        private void btn_profile_Click(object sender, EventArgs e)
        {
            try
            {
                PF_textBox_username.Text = Users.USER_LOGIN;
                PF_textBox_username1.Text = Users.USER_NAME;
                PF_dateTimePicker_birthdate.Value = (DateTime) Users.USER_BIRTH;
                //PF_textBox_pass.Text = "Encrypted";
                PF_textBox_level1.Text = Users.LV_NAME;
                PF_comboBox_type.Text = Users.VT_NAME;
                PF_comboBox_lv.Text = Users.LV_NAME;
                PF_comboBox_dp.Text = Users.DP_NAME;
                PF_textBox_cccd.Text = Users.USER_CCCD;
                PF_textBox_phone.Text = Users.USER_PHONE;
                //PF_comboBox_enable.Text = Users.ENABLE.ToString();
                if (Users.ENABLE.ToString().Equals("1")) {
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
            pages.SetPage(7);
        }

        // Go to setting part
        private void btn_setting_Click(object sender, EventArgs e)
        {
            pages.SetPage(8);
        }

        // Go to project management part
        private void btn_projectmanagement_Click(object sender, EventArgs e)
        {

            PM_loadProject();
            pages.SetPage(2);
        }

        // Logout and go to Login part
        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Go to request management part
        private void btn_requestmanagement_Click(object sender, EventArgs e)
        {
            RM_showTable();
            pages.SetPage(6);
        }

        // Display empty calendar when user doesn't want to set deadline for project (in add project part)
        private void PM_chb_setdl_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (PD_chb_setdl.Checked)
            {
                PD_dp_expect.Format = DateTimePickerFormat.Long;
                PD_dp_start.Format = DateTimePickerFormat.Long;
                PD_dp_dl.Format = DateTimePickerFormat.Long;
                PM_pn_dl.Enabled = true;
            }
            else
            {
                PD_dp_expect.CustomFormat = " ";
                PD_dp_start.CustomFormat = " ";
                PD_dp_dl.CustomFormat = " ";
                PD_dp_expect.Format = DateTimePickerFormat.Custom;
                PD_dp_start.Format = DateTimePickerFormat.Custom;
                PD_dp_dl.Format = DateTimePickerFormat.Custom;
                PM_pn_dl.Enabled = false;
            }
        } 

        // Update project information
        private void PM_btn_update_Click(object sender, EventArgs e)
        {
            curr_pj_id = PD_txt_id.Text;
            if (curr_pj_id != null)
            {
                string pj_name = PD_txt_proname.Text;
                string desc = PD_txt_prodes.Text;
                MessageBox.Show(desc.Length+desc);
                string isPublic = PD_cb_proscale.Text;
                string ver = PD_txt_prover.Text;
                DateTime? exp = null;
                DateTime? start = null;
                DateTime? end = null;

                // Validate date
                if (PD_dp_start.Format == DateTimePickerFormat.Long)
                {
                    exp = PD_dp_expect.Value;
                    start = PD_dp_start.Value;
                    end = PD_dp_dl.Value;
                }

                if (exp != null && start != null && end != null && !pj.ValidateDeadline((DateTime)start, (DateTime)end, (DateTime)exp))
                {
                    MessageBox.Show("Thông tin cập nhật không hợp lệ");
                    return;
                }
                else
                {
                    if (pj.UpdateProject(curr_pj_id, pj_name, desc, exp, start, end, ver, isPublic, Users.PK))
                    {
                        MessageBox.Show("Cập nhật dự án không thành công");
                        PM_loadProject();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dự án không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dự án", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // When value of start date project changed, change format of datetimepicker for displaying calendar to user
        private void PM_dp_start_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_start.Format = DateTimePickerFormat.Long;
        }

        // When value of expected date project changed, change format of datetimepicker for displaying calendar to user
        private void PM_dp_expect_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_expect.Format = DateTimePickerFormat.Long;
        }

        // When value of deadline date project changed, change format of datetimepicker for displaying calendar to user
        private void PM_dp_dl_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_dl.Format = DateTimePickerFormat.Long;
        }

        // Go to add member to project part
        private void PM_btn_addmem_Click(object sender, EventArgs e)
        {
            AM_showTableOutPj();
            AM_showTableInPj();
            pages.SetPage(4);
        }

        // Get list of subtask from input of user
        private void AsT_getSubtasksList()
        {
            subTasks.Clear();
            AsT_dataGridView_subtasks.Rows.Clear();
            if (taskID != "")
            {
                foreach (DataGridViewRow row in AsT_dataGridView_subtasks.Rows)
                {
                    // Check if the current row is not the header row
                    if (!row.IsNewRow && row.Cells["SJ_ID"].Value.ToString() != "")
                    {
                        // Access the cell value of a specific column using the column index or column name
                        string cellValue = row.Cells["SJ_NAME"].Value.ToString();
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
                        string cellValue = row.Cells["SJ_NAME"].Value.ToString();
                        subTasks.Add(cellValue);
                    }
                }
            }
        }


        // Add task to database and turn back to project detail part
        private void PD_btn_addtask_Click(object sender, EventArgs e)
        {

            // Clear previous result
            AsT_comboBox_assignees.Items.Clear();
            AsT_comboBox_submitFiles.Items.Clear();
            AsT_dataGridView_assignees.Columns.Clear();
            AsT_dataGridView_submitFiles.Columns.Clear();
            AsT_dataGridView_resources.Columns.Clear();
            AsT_dataGridView_subtasks.Columns.Clear();

            if (taskID != "") // For task detail
            {
                bunifuButton_delTask.Visible = true;
                label59.Visible = true;
                label60.Visible = true;


                AsT_dataGridView_submitFiles.Visible = true;
                AsT_dataGridView_resources.Visible = true;
                AsT_textBox_taskState.Visible = true;

                if (taskState == "0")
                {
                    AsT_textBox_taskState.BackColor = Color.Silver;
                }
                else if (taskState == "1")
                {
                    AsT_textBox_taskState.BackColor = Color.LimeGreen;
                }
                else
                {
                    AsT_textBox_taskState.BackColor = Color.RoyalBlue;
                }

                AsT_textBox_taskState.Text = taskStateMapping[Int32.Parse(taskState)];


                if (Users.LV_NAME.Equals("Quản lý dự án"))
                {
                    DataTable staffs = ul.GetUserOutTask(taskID);

                    foreach (DataRow staff in staffs.Rows)
                    {
                        if (staff != null)
                        {
                            AsT_comboBox_assignees.Items.Add(staff["USER_ID"] + " | " + staff["USER_NAME"]);
                        }
                    }
                }

                AsT_button_assign.Text = "Update";
                AsT_loadTaskInfo();
            }
            else // For add new task
            {
                bunifuButton_delTask.Visible = false;
                AsT_textBox_taskName.Text = "";
                AsT_textBox_taskDesc.Text = "";
                AsT_dateTimePicker_start.Value = DateTime.Now;
                AsT_dateTimePicker_end.Value = DateTime.Now;

                AsT_comboBox_submitFiles.Visible = false;
                AsT_dataGridView_submitFiles.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                AsT_button_submitFile.Visible = false;
                AsT_button_clearFiles.Visible = false;
                AsT_dataGridView_resources.Visible = false;
                AsT_textBox_taskState.Visible = false;

                // Initialize datagridview column
                AsT_dataGridView_assignees.Columns.Add("No.", "STT");
                AsT_dataGridView_assignees.Columns.Add("AssigneeID", "Mã nhân sự");
                AsT_dataGridView_assignees.Columns.Add("Assignee", "Tên nhân sự");

                AsT_dataGridView_subtasks.Columns.Add("SJ_NAME", "Nhiệm vụ con");

                // Load all staffs from database
                DataTable staffs = pj.GetUserOfProject(PD_txt_id.Text);
                if (staffs != null)
                {
                    foreach (DataRow staff in staffs.Rows)
                    {
                        if (staff != null)
                        {
                            AsT_comboBox_assignees.Items.Add(staff["USER_ID"] + " | " + staff["USER_NAME"]);
                        }
                    }
                }
            }

            DataRow pjTime = pj.GetProject(PD_txt_id.Text);


            AsT_dateTimePicker_start.MinDate = (DateTime)pjTime["PJ_START"];
            AsT_dateTimePicker_start.MaxDate = (DateTime)pjTime["PJ_FINISH"];
            AsT_dateTimePicker_end.MinDate = (DateTime)pjTime["PJ_START"];
            AsT_dateTimePicker_end.MaxDate = (DateTime)pjTime["PJ_FINISH"];

            pages.SetPage(10);
        }

        // Load user after selected user for task
        private void AsT_comboBox_assignees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] delimiter = { " | " };
            string[] assignInfo = AsT_comboBox_assignees.Text.Split(delimiter, StringSplitOptions.None);
            string assigneePK = assignInfo[0];
            string assigneeName = assignInfo[1];
            assignee_PKs.Add(assigneePK);
            AsT_comboBox_assignees.Items.Remove(AsT_comboBox_assignees.Text);

            // Add staff to task
            DataTable taskDTable = AsT_dataGridView_assignees.DataSource as DataTable;
            int nextAss = AsT_dataGridView_assignees.Rows.Count + 1;
            taskDTable.Rows.Add(nextAss, assigneePK, assigneeName);
        }

        // Assign task
        private void AsT_button_assign_Click(object sender, EventArgs e)
        {
            if (AsT_textBox_taskName.Text == "") // Validate
            {
                MessageBox.Show("Tên của nhiệm vụ không được trống", "Kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String pjID = PD_txt_id.Text;
                curManagePjPK = pj.GetProject(pjID)["USER_ID"].ToString();

                if (AsT_button_assign.Text == "Giao nhiệm vụ")
                {
                    AsT_getSubtasksList();

                    String taskName = AsT_textBox_taskName.Text;
                    String taskDesc = AsT_textBox_taskDesc.Text;
                    DateTime start = AsT_dateTimePicker_start.Value;
                    DateTime end = AsT_dateTimePicker_end.Value;
                    int isHL = 0;
                    String taskState = "0";

                    // Notify to assignees
                    String contentAssign = "You've been assigned to " +
                                            "task '" + taskName + "'" + " in project " + AsT_textBox_pjName.Text +
                                            " in " + DateTime.Now.ToString() + "\n"
                                            + "Please, come to project and do your task";

                    newTaskID = task.AssignTask(taskName, taskDesc, start, end, isHL, taskState, pjID, curManagePjPK, assignee_PKs, files, subTasks, contentAssign);
                    if (newTaskID != "")
                    {
                        MessageBox.Show("Thêm nhiệm vụ thành công", Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhiệm vụ thất bại", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Users.LV_NAME.Equals("Nhân viên"))
                    {
                        // Submit task for Nhan Vien
                        task.AddSubmitFileTask(taskID, Users.PK, files);
                        MessageBox.Show("Cập nhật nhiệm vụ thành công");
                    }
                    else
                    {
                        AsT_UpdateTask();
                    }
                }
            }

            AsT_btn_close_Click(sender, e);
        }

        // Remove user from selected assignees list when double click on user row
        private void AsT_dataGridView_assignees_DoubleClick(object sender, EventArgs e)
        {
            String assigneePK = AsT_dataGridView_assignees.CurrentRow.Cells["AssigneeID"].Value.ToString();
            String assigneeName = AsT_dataGridView_assignees.CurrentRow.Cells["Assignee"].Value.ToString();
            AsT_comboBox_assignees.Items.Add(assigneePK + " | " + assigneeName);
            assignee_PKs.Remove(assigneePK);
            AsT_dataGridView_assignees.Rows.RemoveAt(AsT_dataGridView_assignees.CurrentRow.Index);
            number_assignee--;
        }

        // Update task
        private void AsT_UpdateTask()
        {
            AsT_getSubtasksList();

            String taskName = AsT_textBox_taskName.Text;
            String taskDesc = AsT_textBox_taskDesc.Text;
            DateTime start = AsT_dateTimePicker_start.Value;
            DateTime end = AsT_dateTimePicker_end.Value;

            // For info of current task
            String contentAssign = "Task '" + taskName + "'" + " in project " + AsT_textBox_pjName.Text +
                        "is UPDATED in " + DateTime.Now.ToString() + "\n"
                        + "Please, come to project and get new information";

            if (task.UpdateTask(curManagePjPK, contentAssign, taskID, taskName, taskDesc,
                start, end, null, int.Parse(curTaskjHL), taskState, assignee_PKs, subTasks, files))
            {
                MessageBox.Show("Update task successfully");
                taskID = "";
                pages.SetPage(9);
            }
            else
            {
                MessageBox.Show("Fail to update task");
            }
        }

        // Attach file
        private void AsT_button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string file_name = System.IO.Path.GetFileName(file);
                    AsT_comboBox_files.Items.Add(file_name);
                    files.Add(file);
                }
                MessageBox.Show("Uploaded " + files.Count + " successfully");
            }
        }

        // Remove file from attached file list
        private void AsT_button_clearFiles_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                if (files.Count > 0)
                {
                    files.RemoveAt(files.Count - 1);
                    AsT_comboBox_submitFiles.Items.RemoveAt(AsT_comboBox_files.Items.Count - 1);
                }
            }
        }

        // Download resource file of task
        private void AsT_dataGridView_resources_DoubleClick(object sender, EventArgs e)
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

        // Download submit file of task
        private void AsT_dataGridView_submitFiles_DoubleClick(object sender, EventArgs e)
        {
            if (AsT_dataGridView_submitFiles.CurrentRow != null)
            {
                string filename = AsT_dataGridView_submitFiles.CurrentRow.Cells["F_NAME"].Value.ToString();
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

        // Submit file for current task
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
            }
        }

        // Load task information
        private void AsT_loadTaskInfo()
        {
            DataRow taskInfo = task.GetTaskInfo(this.taskID);
            AsT_textBox_taskName.Text = taskInfo["J_NAME"].ToString();
            AsT_textBox_taskDesc.Text = taskInfo["J_DES"].ToString();
            AsT_dateTimePicker_start.Value = (DateTime)taskInfo["J_START"];
            AsT_dateTimePicker_end.Value = (DateTime)taskInfo["J_DEADLINE"];

            AsT_textBox_pjName.Text = PD_txt_proname.Text;

            DataTable assigneesOfTask = task.GetUserOfTask(this.taskID);
            AsT_dataGridView_assignees.DataSource = assigneesOfTask;


            DataTable subTasks = task.GetAllSubTaskOfTask(this.taskID, -1);
            if (subTasks != null)
            {
                DataColumn newColumn = new DataColumn("Done", typeof(bool));
                subTasks.Columns.Add(newColumn);
                foreach (DataRow row in subTasks.Rows)
                {
                    String isDone = row["SJ_DONE"].ToString();
                    if (isDone.Equals("1"))
                    {
                        row["Done"] = true;
                    }
                    else
                    {
                        row["Done"] = false;
                    }
                }
                subTasks.Columns.Remove("SJ_DONE");
                AsT_dataGridView_subtasks.DataSource = subTasks;
            }

            DataTable taskResource = task.GetResourceOfTask(taskID);
            if (taskResource != null)
            {
                AsT_dataGridView_resources.DataSource = taskResource;
                AsT_dataGridView_resources.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_resources.Columns["RE_FILE"].Visible = false;
            }

            DataTable taskSubmittedFile = task.GetSubmitFileOfTask(taskID);
            if (taskSubmittedFile != null)
            {
                AsT_dataGridView_submitFiles.DataSource = taskSubmittedFile;
                AsT_dataGridView_submitFiles.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_submitFiles.Columns["RE_FILE"].Visible = false;
            }
        }

        // Go to task detail part when double on a task in datagridView
        private void PD_dataGridView_task_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow curTask = task.GetTaskInfo(PD_dataGridView_task.CurrentRow.Cells["J_ID"].Value.ToString());

            taskID = curTask["J_ID"].ToString();
            taskState = curTask["J_STATUS"].ToString();
            curTaskjHL = curTask["J_HL"].ToString();

            PD_btn_addtask_Click(sender, e);
        }

        // Add new project
        private void AP_button_addProject_Click(object sender, EventArgs e)
        {
            string name = AP_textBox_name.Text;
            string ver = "1";
            string desc = AP_textBox_desc.Text;
            string isPublic = AP_comboBox_public.Text;
            string pk = Users.PK;

            if (AP_checkBox_dl.Checked)
            {
                DateTime start = AP_dateTimePicker_start.Value;
                DateTime end = AP_dateTimePicker_end.Value;
                DateTime exp = AP_dateTimePicker_exp.Value;
                if (pj.ValidateDeadline(start, end, exp))
                {
                    //MessageBox.Show("ok");
                }

                if (pj.ValidateDeadline(start, end, exp))
                {

                    if (pj.InsertPJ(name, desc, exp, start, end, ver, isPublic, pk))
                    {
                        MessageBox.Show(Properties.Resources.add_pj_success, Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AP_textBox_name.Text = "";
                        AP_textBox_desc.Text = "";
                        AP_comboBox_public.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.add_pj_fail, Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Validate Set Deadline ", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (pj.InsertPJ(name, desc, null, null, null, ver, isPublic, pk))
                {
                    MessageBox.Show(Properties.Resources.add_pj_success, Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AP_textBox_name.Text = "";
                    AP_textBox_desc.Text = "";
                    AP_comboBox_public.Text = "";
                }
                else
                {
                    MessageBox.Show(Properties.Resources.add_pj_fail, Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Validate project name (not allowed empty name)
        private void AP_textBox_name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AP_textBox_name.Text))
            {
                e.Cancel = true;
                AP_textBox_name.Focus();
            }
        }

        // Option for set / not set time for project when user add new project
        private void AP_checkBox_dl_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (!AP_checkBox_dl.Checked)
            {
                AP_pn_dl.Enabled = false;
                AP_dateTimePicker_start.CustomFormat = " ";
                AP_dateTimePicker_start.Format = DateTimePickerFormat.Custom;
                AP_dateTimePicker_end.CustomFormat = " ";
                AP_dateTimePicker_end.Format = DateTimePickerFormat.Custom;
                AP_dateTimePicker_exp.CustomFormat = " ";
                AP_dateTimePicker_exp.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                AP_pn_dl.Enabled = true;
                AP_dateTimePicker_start.Format = DateTimePickerFormat.Long;
                AP_dateTimePicker_end.Format = DateTimePickerFormat.Long;
                AP_dateTimePicker_exp.Format = DateTimePickerFormat.Long;
            }
        }

        //AM 
        // Show all user not in current project
        public void AM_showTableOutPj()
        {
            AM_dataGridView_user.ReadOnly = true;
            AM_dataGridView_user.DataSource = ul.GetUserOutProject(PD_txt_id.Text);
            //AM_dataGridView_user.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)AM_dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Add member";
            btn.Name = "button_add";
            btn.Text = "Add";
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.BackColor = Color.FromArgb(187, 37, 37);
            AM_dataGridView_user.Columns.Add(btn);
        }

        // Show all user in current project
        public void AM_showTableInPj()
        {
            AM_dataGridView_mInProject.ReadOnly = true;
            AM_dataGridView_mInProject.DataSource = pj.GetUserOfProject(curr_pj_id);

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)AM_dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        // Add user to project
        private void AM_dataGridView_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curr_pj_id = PD_txt_id.Text;
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

        // Remove user from project
        private void AM_dataGridView_mInProject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            string u_pk = AM_dataGridView_mInProject.CurrentRow.Cells["USER_ID"].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa nhân sự này ra khỏi dự án không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (pj.DelMemberFromProject(u_pk, curr_pj_id))
                {
                    MessageBox.Show("Xóa nhân viên ra khỏi dự án thành công");
                    // Hide row
                    AM_dataGridView_mInProject.Rows.RemoveAt(AM_dataGridView_mInProject.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên ra khỏi dự án không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Close current page and turn back to previous page
        private void AM_btn_close_Click_1(object sender, EventArgs e)
        {
            pages.SetPage(9);
        }

        //PF
        // Go to Change Password part
        private void PF_button_changePass_Click(object sender, EventArgs e)
        {
            pages.SetPage(3);
        }

        //RP
        // Go to Reset Password part (forget password)
        private void RP_btResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Users.PASSWORD);
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
                MessageBox.Show("Sai mật khẩu", "Mật khẩu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (curr.Equals(new_1))
            {
                RP_tNewPass1.Text = "";
                RP_tNewPass2.Text = "";
                MessageBox.Show("Mật khẩu cũ mới phải khác mật khẩu cũ", "Mật khẩu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Mật khẩu của bạn đã được cập nhật", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        // Close current page and turn back to the previous page
        private void RP_btn_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(7);
            RP_tCurrPass.Text = "";
            RP_tNewPass1.Text = "";
            RP_tNewPass2.Text = "";
        }

        //SR
        // Clear request form
        private void SR_btn_clear_Click(object sender, EventArgs e)
        {
            SR_textBox_subject.Clear();
            SR_textBox_toUser.Clear();
            SR_textBox_content.Clear();
            files.Clear();
            SR_comboBox_files.Items.Clear();
        }

        // Send requestment
        private void SR_bt_Request_Click(object sender, EventArgs e)
        {
            string subject = SR_textBox_subject.Text;
            string pk_receiver = SR_textBox_toUser.Text;
            string content = SR_textBox_content.Text;
            string pk_sender = Users.PK;
            if (reqBll.AddRequest(subject, content, pk_sender, pk_receiver, files))
            {
                MessageBox.Show("Gửi yêu cầu thành công", "Thêm yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gửi yêu cầu không thành công", "Add Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        // Show all request received by user
        public void SR_showTable()
        {
            SR_dataGridView_myReq.ReadOnly = true;
            SR_dataGridView_myReq.DataSource = reqBll.GetMyRequest(Users.PK);
        }

        // Clear just uploaded file
        private void SR_button_clearFiles_Click(object sender, EventArgs e)
        {
            files.Clear();
            SR_comboBox_files.Items.Clear();
        }

        // RM
        // Verify current request
        private bool VerifySelectedReq()
        {
            if (string.IsNullOrEmpty(RM_textBox_sender.Text) || string.IsNullOrEmpty(RM_textBox_subject.Text))
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        // Show all request received by user
        public void RM_showTable()
        {
            RM_dataGridView_req.DataSource = reqBll.GetRequestReceiver(Users.PK);
        }

        // Accept requestment
        private void RM_button_accept_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {

                if (RM_textBox_status.Text.Equals("Chưa xử lí"))
                {
                    reqBll.UpdateRequestStatus(RM_textBox_sender.Text, Users.PK, "Đã xử lí");
                    MessageBox.Show("Đã chấp nhận yêu cầu");
                    RM_showTable();
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống, yêu cầu chưa được chấp nhận", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Reject requestment
        private void RM_button_reject_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {
                if (RM_textBox_status.Text.Equals("Chưa xử lí"))
                {
                    reqBll.UpdateRequestStatus(RM_textBox_sender.Text, Users.PK, "Từ chối xử lí");
                    MessageBox.Show("Yêu cầu đã bị từ chối");
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống, yêu cầu chưa bị từ chối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Load seletected requestment information
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

        // Download request attached file
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
                            MessageBox.Show("Đã lưu tập tin tại " + filename);
                        }
                        catch
                        {
                            MessageBox.Show("Không tìm thấy tập tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Load project information
        private void PM_loadProject()
        {
            dt = pj.GetAllProject();
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
                    PM_parcelLoadProject();
                }
            }
            else
            {
                PM_btn_next.Enabled = false;
                PM_pageid.Enabled = false;
            }
        }

        // Load project
        private void PM_parcelLoadProject()
        {
            mpj_tableLP.Controls.Clear();

            ProjectTemplate[] pjs = new ProjectTemplate[1];
            Random rnd = new Random();
            String title = string.Empty;
            String des = string.Empty;
            String dl = string.Empty;
            String ver = string.Empty;
            String task = string.Empty;
            DateTime dtime = DateTime.Now;

            for (int i = 0; i < 1; i++)
            {
                for (int j = 8 * (PM_pageindex - 1); j <= 8 * PM_pageindex; j++)
                {
                    if (j == dt.Rows.Count) break;
                    pjs[i] = new ProjectTemplate();

                    //MemoryStream ms = new MemoryStream();
                    title = dt.Rows[j]["PJ_NAME"].ToString();
                    pjs[i].Title = title;
                    pjs[i].pjTask = pj.GetNumTaskOfProject(dt.Rows[j]["PJ_ID"].ToString()).ToString();
                    pjs[i].Description = dt.Rows[j]["PJ_DES"].ToString();
                    pjs[i].Start = dt.Rows[j]["PJ_START"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_START"]);
                    pjs[i].Exp = dt.Rows[j]["PJ_EXPECT_FIN"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_EXPECT_FIN"]);
                    pjs[i].End = dt.Rows[j]["PJ_FINISH"] == DBNull.Value ? dtime : Convert.ToDateTime(dt.Rows[j]["PJ_FINISH"]);
                    pjs[i].Version = dt.Rows[j]["PJ_VERSION"].ToString();
                    pjs[i].Deadline = dt.Rows[j]["PJ_FINISH"] == DBNull.Value ? "Unknown" : Convert.ToDateTime(dt.Rows[j]["PJ_FINISH"]).ToString();
                    pjs[i].ID = dt.Rows[j]["PJ_ID"].ToString();
                    pjs[i].PageNum = 9;
                    pjs[i].ID = dt.Rows[j]["PJ_ID"].ToString();
                    pjs[i].dataRow = dt.Rows[j];
                    pjs[i].ManagerID = dt.Rows[j]["USER_ID"].ToString();

                    pjs[i].Gradient_NoStatistic = PD_noStatistic;
                    pjs[i].AsT_managerID1 = AsT_label_managerID;
                    pjs[i].AsT_pjName1 = AsT_textBox_pjName;

                    pjs[i].PD_ProgressBarValue = PD_progressBarValue;
                    pjs[i].PD_ProgressBar = PD_progressBar_pj;
                    pjs[i].PD_Label_NoTasks = PD_label_noTasks;
                    pjs[i].PD_TaskProgress = PD_chart_taskProgress;
                    pjs[i].PD_StateTask = PD_chart_stateTask;
                    pjs[i].PD_ID = PD_txt_id;
                    pjs[i].PD_Title = PD_txt_proname;
                    pjs[i].PD_Ver = PD_txt_prover;
                    pjs[i].PD_Scale = PD_cb_proscale;
                    pjs[i].PD_Status = PD_txt_status;
                    pjs[i].PD_Task = PD_dataGridView_task;
                    pjs[i].PD_Member = PD_dataGridView_member;
                    pjs[i].PD_TimeLine = PD_dataGridView_taskTimeLine;
                    pjs[i].TimeLineTasks = timeLineTasks;
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

        // Filter task with status ("New task", "Processing task", "Done task")
        private void PD_comboBox_filterTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedFilterIdx = taskStateMapping.Values.ToList().IndexOf(PD_comboBox_filterTask.Text);
            DataTable allTasks = task.GetTaskWithStatus(PD_txt_id.Text, selectedFilterIdx);

            // Change ataGridView's headers for more friendly to user
            if (allTasks != null)
            {
                bunifuGradientPanel_noData.Visible = false;
                label_noData.Visible = false;

                allTasks.Columns["J_NAME"].ColumnName = Properties.Resources.task_name;
                allTasks.Columns["J_START"].ColumnName = Properties.Resources.start_date;
                allTasks.Columns["J_DEADLINE"].ColumnName = Properties.Resources.deadline;
                allTasks.Columns["J_STATUS"].ColumnName = Properties.Resources.task_state;

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
                        PD_dataGridView_task.Rows[i].Cells[Properties.Resources.task_state].Value = taskStateMapping[Int32.Parse(PD_dataGridView_task.Rows[i].Cells[Properties.Resources.task_state].Value.ToString())];
                    }

                    i += 1;
                }
            }
            // No any data match filter
            else
            {
                // Notify user of empty data
                bunifuGradientPanel_noData.Visible = true;
                label_noData.Visible = true;
            }
        }

        // Filter task with status ("New task", "Processing task", "Done task")
        private void PM_pageid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (PM_pageid.Text != "") {
                    if (int.Parse(PM_pageid.Text) <= Math.Ceiling((dt.Rows.Count)/8.0))
                    {
                        PM_pageindex = int.Parse(PM_pageid.Text);
                        PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                        PM_pageid.Text = string.Empty;
                        PM_parcelLoadProject();
                    }
                }
            }
        }

        // Go to next part
        private void PM_btn_next_Click(object sender, EventArgs e)
        {
            if (PM_pageindex < Math.Ceiling((dt.Rows.Count) / 8.0))
            {
                PM_btn_previous.Enabled = true;
                PM_pageindex += 1;
                PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                PM_pageid.Text = string.Empty;
                PM_parcelLoadProject();
            }
            if (PM_pageindex == Math.Ceiling((dt.Rows.Count) / 8.0))
            {
                PM_btn_next.Enabled = false;
            }
        }

        // Turn back to previous part
        private void PM_btn_previous_Click(object sender, EventArgs e)
        {
            if (PM_pageindex > 1)
            {
                PM_btn_next.Enabled = true;
                PM_pageindex -= 1;
                PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                PM_pageid.Text = string.Empty;
                PM_parcelLoadProject();
            }
            if (PM_pageindex == 1)
            {
                PM_btn_previous.Enabled = false;
            }
        }

        // Go to Project Managament part
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        // Go to Notification part
        private void btn_notify_Click(object sender, EventArgs e)
        {
            NT_comboBox_notiType_SelectedIndexChanged(sender, e);
            pages.SetPage(1);
        }

        //Nt
        // Show all received notification
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

                int dateSendIndex = NT_dataGridView_notiList.Columns["DATE SEND"].Index;
                int descriptionIndex = NT_dataGridView_notiList.Columns["DESCRIPTION"].Index;

                // Đổi vị trí của hai cột
                NT_dataGridView_notiList.Columns["DATE SEND"].DisplayIndex = descriptionIndex;
                NT_dataGridView_notiList.Columns["DESCRIPTION"].DisplayIndex = dateSendIndex;

                NT_dataGridView_notiList.Columns["DATE SEND"].Width = 125;
            }
        }

        // Filter type of notification
        private void NT_comboBox_notiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NT_comboBox_notiType.Text == "Receive")
            {
                NT_GetReceiveNoti();
            }
            else
            {
                NT_GetSendNoti();
            }
        }

        // Show notification sent by user
        private void NT_GetSendNoti()
        {
            DataTable dt = notiBLL.GetNotiOfSender(Users.PK);
            if (dt != null)
            {
                dt.Columns["N_DATE"].ColumnName = "DATE SEND";
                dt.Columns["N_DES"].ColumnName = "DESCRIPTION";

                NT_dataGridView_notiList.DataSource = dt;

                NT_dataGridView_notiList.Columns["N_ID"].Visible = false;
                NT_dataGridView_notiList.Columns["N_S_ID"].Visible = false;

                int dateSendIndex = NT_dataGridView_notiList.Columns["DATE SEND"].Index;
                int descriptionIndex = NT_dataGridView_notiList.Columns["DESCRIPTION"].Index;

                // Đổi vị trí của hai cột
                NT_dataGridView_notiList.Columns["DATE SEND"].DisplayIndex = descriptionIndex;
                NT_dataGridView_notiList.Columns["DESCRIPTION"].DisplayIndex = dateSendIndex;

                NT_dataGridView_notiList.Columns["DATE SEND"].Width = 125; 
            }
        }

        // Get all receiver of a notification
        private void NT_loadReceiver()
        {
            DataTable dt = notiBLL.GetReceiverOfNoti(Users.PK);
            if (dt == null)
            {
                NT_comboBox_receiverOfNoti.Text = "Nhân sự trong dự";
            }
            else
            {
                foreach (DataRow receiver in dt.Rows)
                {
                    NT_comboBox_receiverOfNoti.Items.Add(receiver["N_R_ID"]);
                }
            }
        }

        // Show notification detail
        private void NT_dataGridView_notiList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NT_textBox_sender.Text = NT_dataGridView_notiList.CurrentRow.Cells["N_S_ID"].Value.ToString();
            NT_dateTimePicker_sendDate.Value = (DateTime)NT_dataGridView_notiList.CurrentRow.Cells["DATE SEND"].Value;
            NT_textBox_content.Text = NT_dataGridView_notiList.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
            String notiID = NT_dataGridView_notiList.CurrentRow.Cells["N_ID"].Value.ToString();

            // Update read notification
            if (!notiBLL.UpdateNotiRead(notiID, Users.PK))
            {
                MessageBox.Show("Fail to update read notification");
            }
            notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);
            // Reload
            NT_loadReceiver();
            NT_GetReceiveNoti();
        }

        // Close current part and go to Project Detail part
        private void AsT_btn_close_Click(object sender, EventArgs e)
        {
            taskID = "";
            pages.SetPage(9);
        }

        // Update UI
        private void AsT_comboBox_files_SizeChanged(object sender, EventArgs e)
        {
            if (AsT_comboBox_files.Items.Count > 0)
            {
                AsT_comboBox_files.Text = AsT_comboBox_files.Items[AsT_comboBox_files.Items.Count - 1].ToString();
            }
        }


        //SM
        // Show all user information
        public void SM_loadTable()
        {
            dataGridView_user_data = ul.getUserInfoAll();
            SM_showTable();
        }

        // Show a user information
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
                imageColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Update user information
        private void SM_button_update_Click(object sender, EventArgs e)
        {
            string u_name = PF_textBox_username.Text;
            DateTime bd = PF_dateTimePicker_birthdate.Value;
            string cccd = PF_textBox_cccd.Text;
            string addr = PF_textBox_addr.Text;
            string gd = PF_comboBox_gender.Text;
            string email = PF_textBox_email.Text;
            string vt_name = PF_comboBox_type.Text;
            string u_pass = SM_dataGridView_user.CurrentRow.Cells["U_PASS"].Value.ToString();
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

        // Disable user account
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


        // Upload image as avatar of user
        private void SM_button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                PF_pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        // Get list of disabled users
        public void SM_loadTableDis()
        {
            SM_showTableDis();
        }

        // Get list of disabled users
        public void SM_showTableDis()
        {
            SM_dataGridView_user.ReadOnly = true;
            SM_dataGridView_user.DataSource = ul.getUserInfoDis();
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

        // Search users meeting description
        private void SM_button_search_user_Click(object sender, EventArgs e)
        {
            String description = SM_tb_search_user.Text;
            if (description.Equals(""))
                SM_tb_search_user.PlaceholderText = "Staff is not found";
            else
                SM_loadTableSearch(description);
        }

        // Load tab search
        public void SM_loadTableSearch(string description)
        {
            SM_showTableSearch(description);
        }

        // Show tab search
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

        // SM
        // Return to previous part
        private void SM_btBack_Click(object sender, EventArgs e)
        {
            pages.SetPage(11);
        }

        // Search user
        private void SM_tb_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SM_button_search_user_Click(sender, e);
        }

        // Filter users are disabled / enabled
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

        // View user information
        private void SM_dataGridView_user_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = "Thông tin của nhân sự";
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

        // Add new user
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
            if (ul.insertUser(type, username, birthdate, address, cccd, image, email, gender, dp, lv, phone))
            {
                MessageBox.Show("Thêm nhân sự thành công", "Thêm nhân sự", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhân sự không thành công", "Thêm nhân sự", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Upload image from PC
        private void AS_button_upload_Click(object sender, EventArgs e)
        {
            // `OpenFileDialog` cho phép người dùng chọn một hoặc nhiều tập tin từ hệ thống tệp tin.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                AS_pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        // Export report
        private void Print(BunifuGradientPanel pn1)
        {
            PrinterSettings ps = new PrinterSettings();
            Rp_report_panel = pn1;
            getPrintArea(pn1);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("No printer is connected", "No Printer");
            }
            printPreviewDialog1.Close();
        }

        private Bitmap memoryimg;


        // Get print area in Export part
        private void getPrintArea(Panel pn1)
        {
            memoryimg = new Bitmap(pn1.Width, pn1.Height);
            pn1.DrawToBitmap(memoryimg, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }

        // Get statistic of all projects
        private void GetAllProjectStatistic()
        {
            chart_remainPJ.Series["Days"].Points.Clear();
            chart_projectProgress.Series["Previous progress"].Points.Clear();
            chart_projectProgress.Series["Updated progress"].Points.Clear();
            chart_state.Series["Completed task"].Points.Clear();
            chart_state.Series["In processing task"].Points.Clear();
            chart_state.Series["New task"].Points.Clear();
            chart_state.Series["Warning task"].Points.Clear();
            foreach (DataRow p in allProject.Rows)
            {
                if (p != null)
                {
                    // Remaining date statistic
                    DataRow pRemain = pj.GetRemainTimePJ(p["PJ_ID"].ToString());

                    if (pRemain["REMAIN"] != null && Int32.Parse(pRemain["REMAIN"].ToString()) > 0)
                    {
                        //float d = float.Parse(pRemain["REMAIN"].ToString());
                        chart_remainPJ.Series["Days"].Points.AddXY(p["PJ_NAME"].ToString(), pRemain["REMAIN"]);
                    }

                    // Updated progress statistic
                    DataRow pUpProgress = pj.GetUpdatedProgressPJ(p["PJ_ID"].ToString());
                    DataRow pProgress = pj.GetProjectProgress(p["PJ_ID"].ToString());
                    if (pUpProgress != null && pProgress != null)
                    {
                        if (float.Parse(pUpProgress["PJ_PROCESS"].ToString()) == 0) pUpProgress["PJ_PROCESS"] = 0.1;
                        if (float.Parse(pProgress["PJ_PROCESS"].ToString()) == 0) pProgress["PJ_PROCESS"] = 0.1;

                        float preProgress = float.Parse(pProgress["PJ_PROCESS"].ToString()) - float.Parse(pUpProgress["PJ_PROCESS"].ToString());
                        if (preProgress == 0) preProgress = 0.1f;

                        chart_projectProgress.Series["Previous progress"].Points.AddXY(p["PJ_NAME"].ToString(), preProgress);
                        chart_projectProgress.Series["Updated progress"].Points.AddXY(p["PJ_NAME"].ToString(), pUpProgress["PJ_PROCESS"]);
                    }

                    // Warning task statistic
                    DataRow wTaskP = task.GetTaskHLPercent(p["PJ_ID"].ToString(), 2);


                    // Task state statistic
                    DataTable numTask0 = task.GetTaskWithStatus(p["PJ_ID"].ToString(), 0);
                    DataTable numTask1 = task.GetTaskWithStatus(p["PJ_ID"].ToString(), 1);
                    DataTable numTask2 = task.GetTaskWithStatus(p["PJ_ID"].ToString(), 2);

                    int n0;
                    int n1;
                    int n2;

                    if (numTask0 == null) n0 = 0; else n0 = numTask0.Rows.Count;

                    if (numTask1 == null) n1 = 0; else n1 = numTask1.Rows.Count;

                    if (numTask2 == null) n2 = 0; else n2 = numTask2.Rows.Count;

                    if (wTaskP == null) wTaskP["RESULT"] = 0; else wTaskP["RESULT"] = 0.1;

                    chart_state.Series["Warning task"].Points.AddXY(p["PJ_NAME"].ToString(), wTaskP["RESULT"]);
                    chart_state.Series["New task"].Points.AddXY(p["PJ_NAME"].ToString(), n0);
                    chart_state.Series["In processing task"].Points.AddXY(p["PJ_NAME"].ToString(), n1);
                    chart_state.Series["Completed task"].Points.AddXY(p["PJ_NAME"].ToString(), n2);

                }
            }
        }

        // Setup page for exporting report
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.Rp_report_panel.Width / 2), this.Rp_report_panel.Location.Y);
        }

        // Go to Report part
        private void btn_report_Click(object sender, EventArgs e)
        {
            allProject = pj.GetAllProject();
            Date = DateTime.Now.ToString("M/d/yyyy");
            label_date.Text = Date;

            // Show progress update of all project in the end of day
            chart_projectProgress.Titles.Add("Project Progress Update");
            chart_remainPJ.Titles.Add("Remaining days for finishing project");
            chart_state.Titles.Add("Task state statistic");
            GetAllProjectStatistic();

            pages.SetPage(13);
        }

        private void Rp_print_Click(object sender, EventArgs e)
        {
            Print(Rp_report_panel);
        }

        // Time line part ================================================================

        DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
        DateTime startDate;
        private void getStartDate(DateTime currDate)
        {
            startDate = currDate;

            while (startDate.DayOfWeek != firstDayOfWeek)
            {
                startDate = startDate.AddDays(-1);
            }
        }

        // Show timeline of task
        private void SetupWeekView()
        {
            PD_dataGridView_taskTimeLine.Columns.Clear();
            PD_dataGridView_taskTimeLine.Rows.Clear();

            // Task column
            PD_dataGridView_taskTimeLine.Columns.Add("Task", "Task");


            getStartDate(weekStartDatePicker.Value);
            for (int i = 0; i < 7; i++)
            {
                PD_dataGridView_taskTimeLine.Columns.Add(startDate.AddDays(i).ToShortDateString(), startDate.AddDays(i).ToString("ddd") + startDate.AddDays(i).ToShortDateString());
            }
            if (PD_dataGridView_taskTimeLine.Columns.Contains(weekStartDatePicker.Value.ToShortDateString()))
            {
                PD_dataGridView_taskTimeLine.Columns[weekStartDatePicker.Value.ToShortDateString()].HeaderCell.Style.BackColor = Color.BlueViolet;
            }

            if (PD_dataGridView_taskTimeLine.Columns.Contains(DateTime.Now.ToShortDateString()))
            {
                PD_dataGridView_taskTimeLine.Columns[DateTime.Now.ToShortDateString()].HeaderCell.Style.BackColor = Color.Yellow;
            }


            highLight(startDate);
        }

        // Get the interval dates between 2 days
        public int GetIntervalDay(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract(start);
            return span.Days;
        }

        // Verify in current week
        public int CheckInCurrentWeek(DateTime ddd)
        {
            if (GetIntervalDay(ddd, startDate) <= 0 && GetIntervalDay(ddd, startDate.AddDays(6)) >= 0)
                // ddd in current week
                return 0;

            if (GetIntervalDay(ddd, startDate) >= 0)
                // ddd in previous week
                return -1;

            // ddd in next week
            return 1;
        }

        // Get highlight of all task in a project
        private void highLight(DateTime startWeekTime)
        {

            DateTime endWeekTime = startWeekTime.AddDays(6);
            int i = 0;


            // Add task for illusrtation
            for (int j = 0; j < timeLineTasks.Count; j++)
            {

                DateTime start = timeLineTasks[j].beginTime;
                DateTime end = timeLineTasks[j].endTime;

                // begin after current week
                if (CheckInCurrentWeek(start) == 1) continue;
                // end before current week
                if (CheckInCurrentWeek(end) == -1) continue;



                PD_dataGridView_taskTimeLine.Rows.Add();
                PD_dataGridView_taskTimeLine.Rows[i].Cells["Task"].Value = timeLineTasks[j].taskName;



                if (CheckInCurrentWeek(start) == 0)
                {

                    for (int k = 0; k < timeLineTasks[j].GetDayInterval(); k++)
                    {

                        string sd = start.ToShortDateString();

                        if (PD_dataGridView_taskTimeLine.Columns.Contains(sd))
                        {
                            switch (timeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
                                    break;
                            }
                        }
                        start = start.AddDays(1);
                    }
                }



                if (CheckInCurrentWeek(start) == -1 && CheckInCurrentWeek(end) == 0)
                {
                    DateTime startPoint = startWeekTime;

                    for (int k = 0; k < timeLineTasks[j].GetLaterTimeInterval(startWeekTime); k++)
                    {
                        string sd = startPoint.ToShortDateString();
                        if (PD_dataGridView_taskTimeLine.Columns.Contains(sd))
                        {
                            switch (timeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
                                    break;
                            }
                        }
                        startPoint = startPoint.AddDays(1);
                    }
                }


                if (CheckInCurrentWeek(start) == -1 && CheckInCurrentWeek(end) == 1)
                {
                    DateTime startPoint = startWeekTime;
                    for (int k = 0; k < 7; k++)
                    {
                        string sd = startPoint.ToShortDateString();
                        if (PD_dataGridView_taskTimeLine.Columns.Contains(sd))
                        {
                            switch (timeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_dataGridView_taskTimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
                                    break;
                            }
                        }
                        startPoint = startPoint.AddDays(1);
                    }
                }

                i = i + 1;

            }
        }

        // View timeline of another week

        private void dtpk_timeline_changed(object sender, EventArgs e)
        {
            SetupWeekView();
        }

        // View timeline of next week
        private void button_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = weekStartDatePicker.Value.AddDays(7);
        }

        // View timeline of previous week
        private void button_1_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = weekStartDatePicker.Value.AddDays(-7);
        }

        // View timeline of current week
        private void button_today_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = DateTime.Today;

        }

        // Filter task which have start date meeting input
        private void bunifuDatePicker_filterTask_ValueChanged(object sender, EventArgs e)
        {
            int selectedFilterIdx = taskStateMapping.Values.ToList().IndexOf(PD_comboBox_filterTask.Text);
            DataTable allTasks = task.GetTaskWithStartDate(PD_txt_id.Text, bunifuDatePicker_filterTask.Value);

            // Change ataGridView's headers for more friendly to user
            if (allTasks != null)
            {
                bunifuGradientPanel_noData.Visible = false;
                label_noData.Visible = false;

                allTasks.Columns["J_NAME"].ColumnName = Properties.Resources.task_name;
                allTasks.Columns["J_START"].ColumnName = Properties.Resources.start_date;
                allTasks.Columns["J_DEADLINE"].ColumnName = Properties.Resources.deadline;
                allTasks.Columns["J_STATUS"].ColumnName = Properties.Resources.task_state;

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
                        PD_dataGridView_task.Rows[i].Cells[Properties.Resources.task_state].Value = taskStateMapping[Int32.Parse(PD_dataGridView_task.Rows[i].Cells[Properties.Resources.task_state].Value.ToString())];
                    }

                    i += 1;
                }
            }
            // No any data match filter
            else
            {
                // Notify user of empty data
                bunifuGradientPanel_noData.Visible = true;
                label_noData.Visible = true;
            }
        }

        // Update project information
        private void PD_btn_update_Click(object sender, EventArgs e)
        {
            curr_pj_id = PD_txt_id.Text;
            if (curr_pj_id != null)
            {
                string pj_name = PD_txt_proname.Text;
                string desc = PD_txt_prodes.Text;
                string isPublic = PD_cb_proscale.Text;
                string ver = PD_txt_prover.Text;
                DateTime? exp = null;
                DateTime? start = null;
                DateTime? end = null;

                // Validate date
                if (PD_dp_start.Format == DateTimePickerFormat.Long)
                {
                    exp = PD_dp_expect.Value;
                    start = PD_dp_start.Value;
                    end = PD_dp_dl.Value;
                }

                if (exp != null && start != null && end != null && !pj.ValidateDeadline((DateTime)start, (DateTime)end, (DateTime)exp))
                {
                    MessageBox.Show("Thông tin mới không hợp lệ");
                    return;
                }
                else
                {
                    if (pj.UpdateProject(curr_pj_id, pj_name, desc, exp, start, end, ver, isPublic, Users.PK))
                    {
                        MessageBox.Show("Cập nhật thông tin dự án thành công");
                        PM_showPj();
                        PM_loadProject();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin dự án không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một dự án", "Xem dự án", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PM_showPj()
        {
            //PM_dataGridView_project.ReadOnly = true;

            if (Users.SPU == true)
            {
                //PM_dataGridView_project.DataSource = pj.getProjectOfUser(Users.CSU);
                Users.SPU = false;
            }
        }


        // Delete task
        private void bunifuButton_delTask_Click(object sender, EventArgs e)
        {
            if (taskID != "")
            {
                if (task.DeleteTask(taskID))
                {
                    MessageBox.Show("Delete task successfully");
                    taskID = "";
                }
                else
                {
                    MessageBox.Show("Fail to delete task");
                }
            }
            delTask = true;
            AsT_btn_close_Click(sender, e);
        }

        // Delete resource file
        private void bunifuButton_delFileRes_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                files.RemoveAt(files.Count - 1);
                AsT_comboBox_files.Items.RemoveAt(AsT_comboBox_files.Items.Count - 1);
            }
        }

    }
}