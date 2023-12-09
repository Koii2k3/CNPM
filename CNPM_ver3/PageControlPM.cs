using BLL;
using BLLL;
using Bunifu.UI.WinForms.BunifuButton;
using DTOO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CNPM_ver3
{
    public partial class PageControlPM : Form
    {
        //PM 
        //int control_hover = -1;
        //int flag = 0;
        string curr_pj_id = null;
        //string curr_pk = "";
        List<string> files = new List<string>();
        UserBLL ul = new UserBLL();
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();
        RequestBLL reqBll = new RequestBLL();
        NotiBLL notiBLL = new NotiBLL();
        DataTable pjDTable = null;
        int PM_pageindex = 1;

        // AsTask
        int number_assignee = 1;
        List<String> assignee_PKs = new List<String>();
        List<string> asTaskFiles = new List<string>();
        List<string> subTasks = new List<string>();

        String curIdPj;
        String curNamePj;
        String curManagePjPK;

        String taskID = "";
        String curTaskjHL;
        String taskState;
        DataRow curPj;

        int numSubTask = 0; // For saving the number of existing subtask
        int currentRowTaskIdx = -1; // For update task information in DataGridView
        String newTaskID = "";
        Boolean delTask = false;

        List<MyItemsTask> timeLineTasks = new List<MyItemsTask>();

        Dictionary<int, string> taskStateMapping = new Dictionary<int, string>();

        public PageControlPM()
        {
            InitializeComponent();
        }


        // Initilize data for first loading
        private void PageControlPM_Load(object sender, EventArgs e)
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
            PD_dataGridView_task.RowTemplate.Height = 60;
            PD_dataGridView_taskTimeLine.RowTemplate.Height = 60;
            NT_dataGridView_notiList.RowTemplate.Height = 60;


            //PC
            btn_projectmanagement_Click(sender, e);
            notify_amount.Text = notiBLL.GetNumNewNoti(Users.PK);

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

            // Make datagridView doesn't display empty row
            PD_dataGridView_member.AllowUserToAddRows = false;
            PD_dataGridView_task.AllowUserToAddRows = false;
        }

        private void btn_project_Click(object sender, EventArgs e)
        {
            pages.SetPage(0);
            //PM_showPj();
        }

        private void btn_task_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        private void btn_request_Click(object sender, EventArgs e)
        {
            pages.SetPage(5);
        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            pages.SetPage(6);
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
            pages.SetPage(7);
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            pages.SetPage(8);
        }

        private void btn_projectmanagement_Click(object sender, EventArgs e)
        {
            PM_loadProject();
            pages.SetPage(2);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void btn_requestmanagement_Click(object sender, EventArgs e)
        {
            RM_showTable();
            pages.SetPage(6);
        }

        //PM functions
        //private void PM_txt_search_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        PM_btn_search_Click(sender, e);
        //}
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



        public void PM_showPj()
        {
            //PM_dataGridView_project.ReadOnly = true;

            if (Users.SPU == true)
            {
                //PM_dataGridView_project.DataSource = pj.getProjectOfUser(Users.CSU);
                Users.SPU = false;
            }
            else
            {
                //PM_dataGridView_project.DataSource = pj.GetProjectInfoAllOfMan(Users.PK);
            }
        }
        private void PM_btn_update_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Fail");
                    return;
                }
                else
                {
                    if (pj.UpdateProject(curr_pj_id, pj_name, desc, exp, start, end, ver, isPublic, Users.PK))
                    {
                        MessageBox.Show("Update project information successfully");
                        PM_showPj();
                        PM_loadProject();
                    }
                    else
                    {
                        MessageBox.Show("Fail to update project information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PM_dp_start_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_start.Format = DateTimePickerFormat.Long;
        }

        private void PM_dp_expect_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_expect.Format = DateTimePickerFormat.Long;
        }

        private void PM_dp_dl_ValueChanged(object sender, EventArgs e)
        {
            PD_dp_dl.Format = DateTimePickerFormat.Long;
        }

        private void PM_btn_addmem_Click(object sender, EventArgs e)
        {
            AM_showTableOutPj();
            AM_showTableInPj();

            pages.SetPage(4);
        }

        //AsT
        private void AsT_getSubtasksList()
        {
            subTasks.Clear();

            if (taskID != "")
            {
                for (int i = numSubTask; i < AsT_dataGridView_subtasks.Rows.Count; i++)
                {
                    // Check if the current row is not the header row
                    if (!AsT_dataGridView_subtasks.Rows[i].IsNewRow && AsT_dataGridView_subtasks.Rows[i].Cells["Subtask"].Value.ToString() != "")
                    {
                        // Access the cell value of a specific column using the column index or column name
                        string cellValue = AsT_dataGridView_subtasks.Rows[i].Cells["Subtask"].Value.ToString();
                        subTasks.Add(cellValue);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in AsT_dataGridView_subtasks.Rows)
                {
                    // Check if the current row is not the header row
                    if (!row.IsNewRow && row.Cells["SJ_NAME"].Value.ToString() != "")
                    {
                        // Access the cell value of a specific column using the column index or column name
                        string cellValue = row.Cells["SJ_NAME"].Value.ToString();
                        subTasks.Add(cellValue);
                    }
                }
            }
        }

        private void PD_btn_addtask_Click(object sender, EventArgs e)
        {


            // Clear previous result
            AsT_comboBox_assignees.Items.Clear();
            AsT_comboBox_submitFiles.Items.Clear();
            AsT_dataGridView_assignees.Columns.Clear();
            AsT_dataGridView_submitFiles.Columns.Clear();
            AsT_dataGridView_resources.Columns.Clear();
            AsT_dataGridView_subtasks.Columns.Clear();

            if (taskID != "") // Task detail
            {
                /*                //AsT_dataGridView_assignees.Location = new Point(297, 379);
                                AsT_dataGridView_assignees.Location = new Point(297, 379);
                                //AsT_dataGridView_assignees.Size = new Size()
                                AsT_dataGridView_subtasks.Location = new Point(827, 352);*/

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
            else
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

        private void PD_btn_addtask_taskID_Click(object sender, EventArgs e)
        {
            if (taskID != "")
            {
                //if (!Users.LV_NAME.Equals("Nhân viên"))
                //{
                //    MessageBox.Show(Users.LV_NAME);

                //    comboBox_files.Visible = false;
                //    button_file.Visible = false;

                //    comboBox_submitFiles.Visible = true;
                //    button_submitFile.Visible = true;

                //    comboBox_assignees.Visible = false;
                //    textBox_taskState.Visible = true;
                //    comboBox_submitFiles.Visible = true;

                //}

                AsT_dataGridView_submitFiles.Visible = true;

                if (taskState == "0")
                {
                    AsT_textBox_taskState.BackColor = Color.Gray;
                    AsT_textBox_taskState.Text = "Task mới được giao";
                }
                else if (taskState == "1")
                {
                    AsT_textBox_taskState.BackColor = Color.Green;
                    AsT_textBox_taskState.Text = "Task đang làm";
                }
                else
                {
                    AsT_textBox_taskState.BackColor = Color.Blue;
                    AsT_textBox_taskState.Text = "Task đã hoàn thành";
                }

                AsT_button_assign.Text = "Update";
                AsT_loadTaskInfo();
            }
            else
            {
                AsT_dataGridView_resources.Visible = false;

                // Initialize datagridview column
                AsT_dataGridView_assignees.Columns.Add("No.", "No.");
                AsT_dataGridView_assignees.Columns.Add("AssigneeID", "Assigness ID");
                AsT_dataGridView_assignees.Columns.Add("Assignee", "Assignee");
                AsT_dataGridView_subtasks.Columns.Add("SJ_NAME", "Subtask");

                DataTable staffs = null;
                //Load all staffs from database
                if (!taskID.Equals(""))
                {
                    staffs = ul.GetUserOutTask(taskID);
                }
                else
                {
                    staffs = pj.GetUserOfProject(curIdPj);
                }

                if (staffs != null)
                {
                    foreach (DataRow staff in staffs.Rows)
                    {
                        if (staff != null)
                        {
                            AsT_comboBox_assignees.Items.Add(staff["USER_ID"]);
                        }
                    }
                }
            }

            pages.SetPage(10);
        }

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

        private void AsT_button_assign_Click(object sender, EventArgs e)
        {

            // Validate
            if (AsT_textBox_taskName.Text == "")
            {
                MessageBox.Show("Task name is required");
            }
            else
            {
                String pjID = PD_txt_id.Text;
                curManagePjPK = pj.GetProject(pjID)["USER_ID"].ToString();

                if (AsT_button_assign.Text == "Giao nhiệm vụ")
                {
                    // Validate
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
                        MessageBox.Show("Add task successfully", Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fail to add task", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AsT_dataGridView_assignees_DoubleClick(object sender, EventArgs e)
        {
            String assigneePK = AsT_dataGridView_assignees.CurrentRow.Cells["AssigneeID"].Value.ToString();
            String assigneeName = AsT_dataGridView_assignees.CurrentRow.Cells["Assignee"].Value.ToString();
            AsT_comboBox_assignees.Items.Add(assigneePK + " | " + assigneeName);
            assignee_PKs.Remove(assigneePK);
            AsT_dataGridView_assignees.Rows.RemoveAt(AsT_dataGridView_assignees.CurrentRow.Index);
            number_assignee--;
        }

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
            }
            else
            {
                MessageBox.Show("Fail to update task");
            }

            // Clear task id
            // taskID = "";
        }

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

        private void AsT_button_clearFiles_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                files.RemoveAt(files.Count - 1);
                AsT_comboBox_submitFiles.Items.RemoveAt(AsT_comboBox_files.Items.Count - 1);
            }
        }

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

        private void AsT_dataGridView_subtasks_DoubleClick(object sender, EventArgs e)
        {
            if (task.SubmitSubtask(AsT_dataGridView_subtasks.CurrentRow.Cells["SJ_ID"].Value.ToString()) == false)
            {
                MessageBox.Show("Submit subtask error");
            }
        }
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
        private void AsT_loadTaskInfo()
        {
            // Get task information =====================================================================================================
            DataRow taskInfo = task.GetTaskInfo(this.taskID);
            AsT_textBox_taskName.Text = taskInfo["J_NAME"].ToString();
            AsT_textBox_taskDesc.Text = taskInfo["J_DES"].ToString();
            AsT_dateTimePicker_start.Value = (DateTime)taskInfo["J_START"];
            AsT_dateTimePicker_end.Value = (DateTime)taskInfo["J_DEADLINE"];
            AsT_textBox_pjName.Text = PD_txt_proname.Text;

            // Get user of task =====================================================================================================
            //DataTable assigneesOfTask = task.GetUserOfTask(this.taskID);
            //AsT_dataGridView_assignees.DataSource = assigneesOfTask;
            //AsT_dataGridView_assignees.Columns["USER_BIRTH"].Visible = false;
            //AsT_dataGridView_assignees.Columns["USER_CCCD"].Visible = false;

            // Initialize datagridview column
/*            AsT_dataGridView_assignees.Columns.Add("No.", "STT");
            AsT_dataGridView_assignees.Columns.Add("AssigneeID", "Mã nhân sự");
            AsT_dataGridView_assignees.Columns.Add("Assignee", "Tên nhân sự");
            AsT_dataGridView_subtasks.Columns.Add("SJ_NAME", "Nhiệm vụ con");*/

            DataTable assigneesOfTask = task.GetUserOfTask(this.taskID);

            DataTable nddd = new DataTable();
            nddd.Columns.Add("STT");
            nddd.Columns.Add("Mã nhân sự");
            nddd.Columns.Add("Tên nhân sự");
            if (assigneesOfTask != null)
            {
                int i = 1;
                foreach (DataRow nee in assigneesOfTask.Rows)
                {
                    nddd.Rows.Add(i, nee["USER_ID"], nee["USER_NAME"]);
                    i++;
                }
            }


            //DataView view = new DataView(assigneesOfTask);
            //DataTable resultTable = view.ToTable(false, "USER_ID","USER_NAME");
            AsT_dataGridView_assignees.DataSource = nddd;


            // Get subtask =====================================================================================================
            DataTable subTasks = task.GetAllSubTaskOfTask(this.taskID, -1);
            if (subTasks != null)
            {
                subTasks.Columns["SJ_NAME"].ColumnName = "Subtask";

                numSubTask = subTasks.Rows.Count; // Get the number of subtask to add another more subtasks
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

                    // Hide unnecessary column from Subtask table
                    AsT_dataGridView_subtasks.Columns["SJ_ID"].Visible = false;
                    AsT_dataGridView_subtasks.Columns["J_ID"].Visible = false;
                }

            }

            // Get resource of task =====================================================================================================
            DataTable taskResource = task.GetResourceOfTask(taskID);
            if (taskResource != null)
            {
                AsT_dataGridView_resources.DataSource = taskResource;
                AsT_dataGridView_resources.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_resources.Columns["RE_FILE"].Visible = false;
            }

            // Get submit of task =====================================================================================================
            DataTable taskSubmittedFile = task.GetSubmitFileOfTask(taskID);
            if (taskSubmittedFile != null)
            {
                AsT_dataGridView_submitFiles.DataSource = taskSubmittedFile;
                AsT_dataGridView_submitFiles.Columns["RE_ID"].Visible = false;
                AsT_dataGridView_submitFiles.Columns["RE_FILE"].Visible = false;
            }
        }

        //*
        private void PD_dataGridView_task_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow curTask = task.GetTaskInfo(PD_dataGridView_task.CurrentRow.Cells["J_ID"].Value.ToString());

            // Get task row idx in datagridview
            currentRowTaskIdx = PD_dataGridView_task.CurrentRow.Index;

            // Get information of selected task
            taskID = curTask["J_ID"].ToString();
            taskState = curTask["J_STATUS"].ToString();
            curTaskjHL = curTask["J_HL"].ToString();

            // Go to Assign Form for watching detail task information
            PD_btn_addtask_Click(sender, e);
        }

        //AP functions
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
                //if (ValidateChildren(ValidationConstraints.Enabled))
                //{
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
                //}
                //else
                //{
                //    MessageBox.Show("Validate failure 2", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void AP_textBox_name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AP_textBox_name.Text))
            {
                e.Cancel = true;
                AP_textBox_name.Focus();
            }
        }

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
        public void AM_showTableOutPj()
        {
            AM_dataGridView_user.Columns.Clear();

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
            btn.Width = 100;

            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.BackColor = Color.FromArgb(187, 37, 37);
            btn.FlatStyle = FlatStyle.Flat;

            AM_dataGridView_user.Columns.Add(btn);
        }

        public void AM_showTableInPj()
        {
            AM_dataGridView_mInProject.ReadOnly = true;
            AM_dataGridView_mInProject.DataSource = pj.GetUserOfProject(curr_pj_id);
            /*            AM_dataGridView_mInProject.RowTemplate.Height = 60;

                        // Show image
                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn = (DataGridViewImageColumn)AM_dataGridView_mInProject.Columns["USER_IMAGE"];
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;*/
        }

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

        private void AM_btn_close_Click_1(object sender, EventArgs e)
        {
            pages.SetPage(9);
        }

        //PF
        private void PF_button_changePass_Click(object sender, EventArgs e)
        {
            pages.SetPage(3);
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
            pages.SetPage(7);
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

        private void PM_loadProject()
        {
            pjDTable = pj.getProjectOfUser(Users.PK);
            if (pjDTable != null)
            {
                if (pjDTable.Rows.Count > 0)
                {
                    if (pjDTable.Rows.Count < 8)
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
                if (pjDTable == null || pjDTable.Rows.Count < 8.0)
                {
                    PM_btn_next.Enabled = false;
                    PM_pageid.Enabled = false;
                }
            }
        }

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
            DateTime dtime = DateTime.Parse("1/1/1973"); // ??????

            for (int i = 0; i < 1; i++)
            {
                for (int j = 8 * (PM_pageindex - 1); j <= 8 * PM_pageindex; j++)
                {
                    if (j == pjDTable.Rows.Count) break;
                    pjs[i] = new ProjectTemplate();

                    //MemoryStream ms = new MemoryStream();
                    title = pjDTable.Rows[j]["PJ_NAME"].ToString();
                    pjs[i].Title = title;
                    pjs[i].pjTask = pj.GetNumTaskOfProject(pjDTable.Rows[j]["PJ_ID"].ToString()).ToString();
                    pjs[i].Description = pjDTable.Rows[j]["PJ_DES"].ToString();
                    pjs[i].Start = pjDTable.Rows[j]["PJ_START"] == DBNull.Value ? dtime : Convert.ToDateTime(pjDTable.Rows[j]["PJ_START"]);
                    pjs[i].Exp = pjDTable.Rows[j]["PJ_EXPECT_FIN"] == DBNull.Value ? dtime : Convert.ToDateTime(pjDTable.Rows[j]["PJ_EXPECT_FIN"]);
                    pjs[i].End = pjDTable.Rows[j]["PJ_FINISH"] == DBNull.Value ? dtime : Convert.ToDateTime(pjDTable.Rows[j]["PJ_FINISH"]);
                    pjs[i].Version = pjDTable.Rows[j]["PJ_VERSION"].ToString();
                    pjs[i].Deadline = pjDTable.Rows[j]["PJ_FINISH"] == DBNull.Value ? "Unknown" : Convert.ToDateTime(pjDTable.Rows[j]["PJ_FINISH"]).ToString();
                    pjs[i].ID = pjDTable.Rows[j]["PJ_ID"].ToString();
                    pjs[i].PageNum = 9;
                    pjs[i].ID = pjDTable.Rows[j]["PJ_ID"].ToString();
                    pjs[i].dataRow = pjDTable.Rows[j];
                    pjs[i].ManagerID = pjDTable.Rows[j]["USER_ID"].ToString();

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

                    if (pjDTable.Rows[j]["PJ_PUBLIC"].ToString().Equals('1'))
                        pjs[i].pjScale = "Public";
                    else
                        pjs[i].pjScale = "Private";

                    pjs[i].LineColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    pjs[i].Pages = pages;

                    mpj_tableLP.Controls.Add(pjs[i]);
                }
            }
        }

        // Filter task with status
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

        private void PM_pageid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (PM_pageid.Text != "")
                {
                    if (int.Parse(PM_pageid.Text) <= Math.Ceiling((pjDTable.Rows.Count) / 8.0))
                    {
                        PM_pageindex = int.Parse(PM_pageid.Text);
                        PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                        PM_pageid.Text = string.Empty;
                        PM_parcelLoadProject();
                    }
                }
            }
        }

        private void PM_btn_next_Click(object sender, EventArgs e)
        {
            if (PM_pageindex < Math.Ceiling((pjDTable.Rows.Count) / 8.0))
            {
                PM_btn_previous.Enabled = true;
                PM_pageindex += 1;
                PM_pageid.TextPlaceholder = PM_pageindex.ToString();
                PM_pageid.Text = string.Empty;
                PM_parcelLoadProject();
            }
            if (PM_pageindex == Math.Ceiling((pjDTable.Rows.Count) / 8.0))
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
                PM_parcelLoadProject();
            }
            if (PM_pageindex == 1)
            {
                PM_btn_previous.Enabled = false;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        private void btn_notify_Click(object sender, EventArgs e)
        {
            //NotiForm f = new NotiForm();
            //f.Show();
            NT_comboBox_notiType_SelectedIndexChanged(sender, e);
            pages.SetPage(1);
        }

        //Nt
        private void NT_GetReceiveNoti()
        {
            DataTable dt = notiBLL.GetNotiOfReceiver(Users.PK);
            if (dt != null)
            {
                NT_dataGridView_notiList.DataSource = dt;
            }
        }

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

                NT_dataGridView_notiList.Columns["DATE SEND"].Width = 100;
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



        private void AsT_textBox_taskName_Validating(object sender, CancelEventArgs e)
        {

        }

        /*        private void AsT_dateTimePicker_end_Validating(object sender, CancelEventArgs e)
                {

                    DateTime start = AsT_dateTimePicker_start.Value;
                    DateTime end = AsT_dateTimePicker_end.Value;

                    TimeSpan s_e = end - start;
                    int start_end = s_e.Days;

                    if (start_end < 0)
                    {
                        //e.Cancel = true;
                        AsT_dateTimePicker_end.Focus();
                        errorProvider2.SetError(AsT_dateTimePicker_end, "Deadline must be before start day");
                        errorProvider2.Clear();

                    }

                }
        */


        private void AsT_dateTimePicker_start_ValueChanged(object sender, EventArgs e)
        {
            AsT_dateTimePicker_start.Format = DateTimePickerFormat.Long;

            AsT_dateTimePicker_end.Enabled = true;
            AsT_dateTimePicker_end.MinDate = AsT_dateTimePicker_start.Value;
        }


        private void reload()
        {
            // Assign taskID = "" for use of AssignTask
            subTasks.Clear();

            // Update task information of project
            showUpdateTaskInProject();
        }


        // Show update task of project in table
        public void showUpdateTaskInProject()
        {
            // If add more task
            if (newTaskID != "" && taskID == "")
            {
                DataTable taskDTable = PD_dataGridView_task.DataSource as DataTable;
                DataRow newRow = task.GetTaskInfo(newTaskID);
                taskDTable.Rows.Add(newRow["J_ID"], newRow["J_NAME"],
                    newRow["J_DES"], newRow["J_START"], newRow["J_DEADLINE"],
                    newRow["J_FINISH"], newRow["J_HL"], taskStateMapping[Int32.Parse(newRow["J_STATUS"].ToString())],
                    newRow["PJ_ID"], newRow["J_DONE"]);

                // Clear new task id
                newTaskID = "";
            }

            // If update existing task
            else if (newTaskID == "" && taskID != "")
            {
                if (currentRowTaskIdx > 0)
                {
                    // Updated of taskID task information
                    DataRow updatedTask = task.GetTaskInfo(taskID);

                    // Modify the data in the underlying data source
                    DataTable dataTable = (DataTable)PD_dataGridView_task.DataSource;
                    DataRow row = dataTable.Rows[currentRowTaskIdx];

                    // Update the values of the row
                    row[Properties.Resources.task_name] = updatedTask["J_NAME"].ToString();
                    row[Properties.Resources.start_date] = updatedTask["J_START"].ToString();
                    row[Properties.Resources.deadline] = updatedTask["J_DEADLINE"].ToString();
                    row[Properties.Resources.task_state] = taskStateMapping[Int32.Parse(updatedTask["J_STATUS"].ToString())];

                    // Clear updated task id
                    taskID = "";
                }
            }

            // Remove task
            else if (delTask)
            {
                int rowIndex = PD_dataGridView_task.SelectedCells[0].RowIndex;
                ((DataTable)PD_dataGridView_task.DataSource).Rows.RemoveAt(currentRowTaskIdx);
                delTask = false;
            }

            PD_dataGridView_task.Refresh();

        }

        private void AsT_btn_close_Click(object sender, EventArgs e)
        {
            reload();
            pages.SetPage(9);
        }

        private void AsT_dataGridView_resources_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AsT_dataGridView_submitFiles_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AsT_dataGridView_subtasks_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton_close_Click(object sender, EventArgs e)
        {
            pages.SetPage(2);
        }

        private void PD_btn_delete_Click(object sender, EventArgs e)
        {

        }

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

        private void AsT_label_managerID_Click(object sender, EventArgs e)
        {

        }

        private void AsT_textBox_taskState_Click(object sender, EventArgs e)
        {

        }

        private void AsT_comboBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void AsT_dataGridView_resources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void AsT_dataGridView_submitFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }


        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void AsT_dataGridView_assignees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void AsT_textBox_pjName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void AsT_dateTimePicker_end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AsT_textBox_taskDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void AsT_textBox_taskName_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator8_Click(object sender, EventArgs e)
        {

        }

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

        private void PD_btn_addmem_Click(object sender, EventArgs e)
        {
            AM_showTableOutPj();
            AM_showTableInPj();

            pages.SetPage(4);
        }

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
                    MessageBox.Show("Fail");
                    return;
                }
                else
                {
                    if (pj.UpdateProject(curr_pj_id, pj_name, desc, exp, start, end, ver, isPublic, Users.PK))
                    {
                        MessageBox.Show("Update project information successfully");
                        PM_showPj();
                        PM_loadProject();
                    }
                    else
                    {
                        MessageBox.Show("Fail to update project information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton_delFileRes_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                files.RemoveAt(files.Count - 1);
                AsT_comboBox_files.Items.RemoveAt(AsT_comboBox_files.Items.Count - 1);
            }
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

        private void getJobOfProject(string PJ_ID)
        {
            DataTable data = task.GetTaskOfProject(PJ_ID);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];

                String taskName = row["J_NAME"].ToString();
                DateTime startTime = DateTime.Parse(row["J_START"].ToString());
                DateTime endTime = DateTime.Parse(row["J_DEADLINE"].ToString());
                int hl = Int32.Parse(row["J_HL"].ToString());

                MyItemsTask myItemsTask = new MyItemsTask(taskName, startTime, endTime, hl);
                timeLineTasks.Add(myItemsTask);

            }
        }



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

        public int GetIntervalDay(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract(start);
            return span.Days;
        }


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


        // ValueChange

        private void dtpk_timeline_changed(object sender, EventArgs e)
        {
            SetupWeekView();
        }

        // Next week
        private void button_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = weekStartDatePicker.Value.AddDays(7);
        }

        // Previous week
        private void button_1_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = weekStartDatePicker.Value.AddDays(-7);
        }


        private void button_today_Click(object sender, EventArgs e)
        {
            weekStartDatePicker.Value = DateTime.Today;

        }
    }
}