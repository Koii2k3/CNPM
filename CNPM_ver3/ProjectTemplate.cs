using BLLL;
using Bunifu.UI.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DTOO;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using Bunifu.Framework.UI;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;

namespace CNPM_ver3
{
    public partial class ProjectTemplate : UserControl
    {
        public ProjectTemplate()
        {
            InitializeComponent();
        }

        private Color color;
        private string id;
        private string title;
        private string description;
        private string status;
        private string dl;
        private string task;
        private string ver;
        private string scale;
        private int pagenum;
        private string managerID;

        private Image ava1;
        private Image ava2;
        private Image ava3;
        private Image ava4;
        private Image ava5;

        private DateTime start;
        private DateTime exp;
        private DateTime end;

        TaskBLL Database_tasks = new TaskBLL();
        ProjectBLL Database_pj = new ProjectBLL();
        static DataTable table = new DataTable();
        DataRow dtRow = table.NewRow();

        private BunifuPages pages;
        private BunifuTextBox PD_title;
        private BunifuTextBox PD_description;
        private System.Windows.Forms.Label PD_status;
        private BunifuTextBox PD_ver;
        private BunifuDatePicker PD_start;
        private BunifuDatePicker PD_exp;
        private BunifuDatePicker PD_dl;
        private BunifuDataGridView PD_task;
        private BunifuDataGridView PD_member;
        private BunifuDataGridView PD_timeLine;
        private List<MyItemsTask> timeLineTasks;

        private Bunifu.UI.WinForms.BunifuDropdown PD_scale;
        private BunifuTextBox PD_id;
        private Chart PD_taskProgress;
        private Chart PD_stateTask;
        private Label PD_label_noTasks;
        private Bunifu.UI.WinForms.BunifuProgressBar PD_progressBar;
        private Label PD_progressBarValue;
        private Bunifu.UI.WinForms.BunifuGradientPanel gradient_noStatistic;

        private Label AsT_managerID;
        private BunifuTextBox AsT_pjName;

        #region Properties
        [Category("Custom Project")]
        public Bunifu.UI.WinForms.BunifuGradientPanel Gradient_NoStatistic
        {
            get { return gradient_noStatistic; }
            set { gradient_noStatistic = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string ManagerID
        {
            get { return managerID; }
            set { managerID = value; }
        }

        public Label PD_ProgressBarValue
        {
            get { return PD_progressBarValue; }
            set { PD_progressBarValue = value; }
        }

        public Label PD_Label_NoTasks
        {
            get { return PD_label_noTasks; }
            set { PD_label_noTasks = value; }
        }

        public Bunifu.UI.WinForms.BunifuProgressBar PD_ProgressBar
        {
            get { return PD_progressBar; }
            set { PD_progressBar = value; }
        }

        public DataRow dataRow
        {
            get { return dtRow; }
            set { dtRow = value; }
        }

        public Chart PD_TaskProgress
        {
            get { return PD_taskProgress; }
            set { PD_taskProgress = value; }
        }

        public Chart PD_StateTask
        {
            get { return PD_stateTask; }
            set { PD_stateTask = value; }
        }

        public int PageNum
        {
            get { return pagenum; }
            set { pagenum = value; }
        }

        public BunifuTextBox PD_ID
        {
            get { return PD_id; }
            set { PD_id = value; }
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        public DateTime Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public BunifuDataGridView PD_Task
        {
            get { return PD_task; }
            set { PD_task = value; }
        }

        public BunifuDataGridView PD_Member
        {
            get { return PD_member; }
            set { PD_member = value; }
        }

        public List<MyItemsTask> TimeLineTasks
        {
            get { return timeLineTasks; }
            set { timeLineTasks = value; }
        }


        public BunifuDataGridView PD_TimeLine
        {
            get { return PD_timeLine; }
            set { PD_timeLine = value; }
        }
        

        public Bunifu.UI.WinForms.BunifuDropdown PD_Scale
        {
            get { return PD_scale; }
            set { PD_scale = value; }
        }

        public BunifuTextBox PD_Title
        {
            get { return PD_title; }
            set { PD_title = value; }
        }

        public BunifuTextBox PD_Description
        {
            get { return PD_description; }
            set { PD_description = value; }
        }

        public System.Windows.Forms.Label PD_Status
        {
            get { return PD_status; }
            set { PD_status = value; }
        }

        public BunifuTextBox PD_Ver
        {
            get { return PD_ver; }
            set { PD_ver = value; }
        }

        public BunifuDatePicker PD_Start
        {
            get { return PD_start; }
            set { PD_start = value; }
        }

        public BunifuDatePicker PD_Exp
        {
            get { return PD_exp; }
            set { PD_exp = value; }
        }
        public BunifuDatePicker PD_Dl
        {
            get { return PD_dl; }
            set { PD_dl = value; }
        }

        [Category("Custom Project")]
        public Color LineColor
        {
            get { return color; }
            set { color = value; bunifuProgressBar1.ProgressColorLeft = value; pj_line.GradientTopRight = Color.LightGray; pj_line.GradientBottomLeft = pj_line.GradientBottomRight = pj_line.GradientTopLeft = value; }
        }

        [Category("Custom Project")]
        public string Title
        {
            get { return title; }
            set { title = value; pj_name.Text = value; }
        }
        [Category("Custom Project")]
        public string Status
        {
            get { return status; }
            set { status = value; pj_status.Text = value; }
        }
        [Category("Custom Project")]
        public string Description
        {
            get { return description; }
            set { description = value; pj_des.Text = value; }
        }
        [Category("Custom Project")]
        public string Deadline
        {
            get { return dl; }
            set { dl = value; pj_dl.Text = value; }
        }
        [Category("Custom Project")]
        public string pjTask
        {
            get { return task; }
            set { task = value; pj_task.Text = value; }
        }
        [Category("Custom Project")]
        public string Version
        {
            get { return ver; }
            set { ver = value; pj_ver.Text = value; }
        }
        [Category("Custom Project")]
        public string pjScale
        {
            get { return scale; }
            set { scale = value; pj_scale.Text = value; }
        }
        [Category("Custom Project")]
        public Image Ava1
        {
            get { return ava1; }
            set { ava1 = value; pj_ava1.Image = value; }
        }
        [Category("Custom Project")]
        public Image Ava2
        {
            get { return ava2; }
            set { ava2 = value; pj_ava2.Image = value; }
        }
        [Category("Custom Project")]
        public Image Ava3
        {
            get { return ava3; }
            set { ava3 = value; pj_ava3.Image = value; }
        }
        [Category("Custom Project")]
        public Image Ava4
        {
            get { return ava4; }
            set { ava4 = value; pj_ava4.Image = value; }
        }
        [Category("Custom Project")]
        public Image Ava5
        {
            get { return ava5; }
            set { ava5 = value; pj_ava5.Image = value; }
        }
        [Category("Custom Project")]
        public BunifuPages Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        public Label AsT_managerID1 { get => AsT_managerID; set => AsT_managerID = value; }
        public BunifuTextBox AsT_pjName1 { get => AsT_pjName; set => AsT_pjName = value; }

        #endregion


        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {
            PD_ID.Text = id;
            PD_Title.Text = title;
            PD_Status.Text = status;
            PD_Description.Text = description;
            PD_Start.Value = start;
            PD_Exp.Value = exp;
            PD_Dl.Value = end;
            PD_Task.Text = task;
            PD_Scale.Text = scale;
            PD_Ver.Text = ver;
            //if (Users.LV_NAME == "Quản lý dự án")
            //    PD_Task.DataSource = Database_tasks.GetTaskOfProject(id);
            //if (Users.LV_NAME == "Nhân viên")
            //    PD_Task.DataSource = Database_tasks.GetJobInProjectOfUser(Users.PK, id);

            if (Users.LV_NAME == "Quản lý dự án")
            {
                AsT_pjName1.Text = title;
                AsT_managerID1.Text = ManagerID;
            }

            //if (Users.LV_NAME == "Nhân viên")
            //    PD_Task.DataSource = Database_tasks.GetJobInProjectOfUser(Users.PK, id);


            // Load tasks of project
            showTaskInProject();

            // Load staff information joining project
            showMemberInProject();


            if (Users.LV_NAME != "Nhân viên")
            {
                // Show timeLine
                getJobOfProject(id);
                PD_TimeLine.EnableHeadersVisualStyles = false;
                SetupWeekView();
            }


            if (Users.LV_NAME == "Quản lý dự án")
            {
                if (PD_Task.Rows.Count == 0)
                {
                    //PD_Label_NoTasks.Visible = true;
                    Gradient_NoStatistic.Visible = true;
                }
                else
                {
                    //PD_Label_NoTasks.Visible = false;
                    Gradient_NoStatistic.Visible = false;
                }

                PD_TaskProgress.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                PD_TaskProgress.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                PD_TaskProgress.ChartAreas[0].AxisY.Maximum = 100;

                PD_StateTask.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                PD_StateTask.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                PD_StateTask.ChartAreas[0].AxisY.Interval = 1;
                PD_StateTask.ChartAreas[0].AxisY.IntervalOffset = 0;

                showTaskProcess();
                showTaskState();
            }

            pages.SetPage(pagenum);
            showProgressBarPJ();
            
        }

        // Get all user information joining in project
        public void showMemberInProject()
        {
            PD_Member.Columns.Clear();
            DataTable allMembers = Database_pj.GetUserOfProject(PD_ID.Text);
            if (allMembers != null)
            {
                allMembers.Columns["USER_ID"].ColumnName = "Mã nhân viên";
                allMembers.Columns["USER_NAME"].ColumnName = "Tên nhân viên";
                allMembers.Columns["USER_EMAIL"].ColumnName = "Email";
                allMembers.Columns["USER_PHONE"].ColumnName = "Số điện thoại";
                allMembers.Columns["USER_GENDER"].ColumnName = "Giới tính";
                allMembers.Columns["USER_IMAGE"].ColumnName = "Ảnh nhân viên";

                PD_Member.DataSource = allMembers;

                PD_Member.Columns["USER_CCCD"].Visible = false;
                PD_Member.Columns["USER_BIRTH"].Visible = false;
                PD_Member.Columns["USER_ADDRESS"].Visible = false;

                PD_Member.RowTemplate.Height = 60;

                // Zoom user image
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)PD_Member.Columns["Ảnh nhân viên"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
        }



        public void showTaskInProject()
        {
            PD_Task.Columns.Clear();
            DataTable allTasks = Database_tasks.GetTaskOfProject(PD_ID.Text);
            if (Users.LV_NAME == "Nhân viên")
            {
                allTasks = Database_tasks.GetJobInProjectOfUser(Users.PK, id);
            }

            if (allTasks != null)
            {
                allTasks.Columns["J_NAME"].ColumnName = Properties.Resources.task_name;
                allTasks.Columns["J_START"].ColumnName = Properties.Resources.start_date;
                allTasks.Columns["J_DEADLINE"].ColumnName = Properties.Resources.deadline;
                allTasks.Columns["J_STATUS"].ColumnName = Properties.Resources.task_state;

                PD_Task.DataSource = allTasks;

                PD_Task.Columns["J_DES"].Visible = false;
                PD_Task.Columns["J_ID"].Visible = false;
                PD_Task.Columns["J_FINISH"].Visible = false;
                PD_Task.Columns["J_HL"].Visible = false;
                PD_Task.Columns["PJ_ID"].Visible = false;
                PD_Task.Columns["J_DONE"].Visible = false;

                int i = 0;
                foreach (DataRow row in allTasks.Rows)
                {
                    if (row != null)
                    {
                        if (PD_Task.Rows[i].Cells[Properties.Resources.task_state].Value.ToString() == "0")
                        {
                            PD_Task.Rows[i].Cells[Properties.Resources.task_state].Value = Properties.Resources.new_task;
                        }
                        else if (PD_Task.Rows[i].Cells[Properties.Resources.task_state].Value.ToString() == "1")
                        {
                            PD_Task.Rows[i].Cells[Properties.Resources.task_state].Value = Properties.Resources.processing_task;
                            PD_Task.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                        else
                        {
                            PD_Task.Rows[i].Cells[Properties.Resources.task_state].Value = Properties.Resources.done_task;
                            PD_Task.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    i += 1;
                }
            }
        }

        private void showTaskProcess()
        {
            // Định chỉ show những task chưa hoàn thành thôi, vì nếu hoàn thành rồi thống kê
            // vào luôn sẽ chiếm nhiều space
            //PD_TaskProgress.Series["Task"].Points.Clear();
            PD_TaskProgress.Series["Tasks"].Points.Clear();
            DataTable allTasks = Database_tasks.GetTaskOfProject(PD_ID.Text);
            if (allTasks != null)
            {
                foreach (DataRow row in allTasks.Rows)
                {
                    if (row != null)
                    {
                        DataTable process = Database_tasks.GetTaskProcess(row["J_ID"].ToString());

                        foreach (DataRow pr in process.Rows)
                        {
                            if (pr != null)
                            {
                                if (Int32.Parse(pr["PERCENT"].ToString()) < 1)
                                {
                                    pr["PERCENT"] = 1;
                                }

                                String taskName = Database_tasks.GetTaskInfo(pr["J_ID"].ToString())["J_NAME"].ToString();
                                PD_TaskProgress.Series["Tasks"].Points.AddXY(taskName, pr["PERCENT"]);
                            }
                        }
                    }
                }
            }
        }


        private void showTaskState()
        {
            PD_StateTask.Series["TaskState"].Points.Clear();
            DataTable allTasks = Database_pj.GetStateJobsInProject(PD_ID.Text);

            foreach (DataRow row in allTasks.Rows)
            {
                if (row != null)
                {
                    PD_StateTask.Series["TaskState"].Points.AddXY(Properties.Resources.new_task, row["NEW_TASK"]);
                    PD_StateTask.Series["TaskState"].Points.AddXY(Properties.Resources.processing_task, row["PROCESSING_TASK"]);
                    PD_StateTask.Series["TaskState"].Points.AddXY(Properties.Resources.done_task, row["DONE_TASK"]);
                }
            }
        }

        private void showProgressBarPJ()
        {
            PD_progressBar.Value = 0;
            float floatProgress = 0;
            try
            {
                floatProgress = float.Parse(Database_pj.GetProjectProgress(PD_ID.Text)["PJ_PROCESS"].ToString());

            }
            catch
            {

            }

            //floatProgress = float.Parse(Database_pj.GetProjectProgress(PD_ID.Text)["PJ_PROCESS"].ToString());

            PD_progressBarValue.Text = String.Format("{0:0.00}", floatProgress) + " %";

            int pjProgress = (int)Math.Round(floatProgress);
            PD_progressBar.ValueByTransition = pjProgress;
            PD_progressBar.AnimationSpeed = 1000;
        }

        private void pj_name_MouseHover(object sender, EventArgs e)
        {
            bunifuProgressBar1.ValueByTransition = 100;
            pj_name.Font = new Font("Segoe UI", 16.00F, FontStyle.Bold);
            pj_line.GradientTopRight = color;
            bunifuGradientPanel1.GradientBottomLeft = Color.WhiteSmoke;
            bunifuGradientPanel1.GradientBottomRight = Color.WhiteSmoke;
        }

        private void bunifuGradientPanel1_MouseLeave(object sender, EventArgs e)
        {
            bunifuProgressBar1.ValueByTransition = 75;
            pj_name.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            pj_line.GradientTopRight = Color.LightGray;
            bunifuGradientPanel1.GradientBottomLeft = Color.White;
            bunifuGradientPanel1.GradientBottomRight = Color.White;
        }

        private void ProjectTemplate_Load(object sender, EventArgs e)
        {
            bunifuProgressBar1.ValueByTransition = 100;
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
            DataTable data = Database_tasks.GetTaskOfProject(PJ_ID);
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow row = data.Rows[i];

                    String taskName = row["J_NAME"].ToString();
                    DateTime startTime = DateTime.Parse(row["J_START"].ToString());
                    DateTime endTime = DateTime.Parse(row["J_DEADLINE"].ToString());
                    int hl = Int32.Parse(row["J_HL"].ToString());

                    MyItemsTask myItemsTask = new MyItemsTask(taskName, startTime, endTime, hl);
                    TimeLineTasks.Add(myItemsTask);
                }
            }
        }



        private void SetupWeekView()
        {
            PD_TimeLine.Columns.Clear();
            PD_TimeLine.Rows.Clear();

            // Task column
            PD_TimeLine.Columns.Add("Task", "Task");


            getStartDate(DateTime.Today);
            for (int i = 0; i < 7; i++)
            {
                PD_TimeLine.Columns.Add(startDate.AddDays(i).ToShortDateString(), startDate.AddDays(i).ToString("ddd") + startDate.AddDays(i).ToShortDateString());
            }
            if (PD_TimeLine.Columns.Contains(DateTime.Today.ToShortDateString()))
            {
                PD_TimeLine.Columns[DateTime.Today.ToShortDateString()].HeaderCell.Style.BackColor = Color.BlueViolet;
            }

            if (PD_TimeLine.Columns.Contains(DateTime.Now.ToShortDateString()))
            {
                PD_TimeLine.Columns[DateTime.Now.ToShortDateString()].HeaderCell.Style.BackColor = Color.Yellow;
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
            for (int j = 0; j < TimeLineTasks.Count; j++)
            {

                DateTime start = TimeLineTasks[j].beginTime;
                DateTime end = TimeLineTasks[j].endTime;

                // begin after current week
                if (CheckInCurrentWeek(start) == 1) continue;
                // end before current week
                if (CheckInCurrentWeek(end) == -1) continue;



                PD_TimeLine.Rows.Add();
                PD_TimeLine.Rows[i].Cells["Task"].Value = TimeLineTasks[j].taskName;



                if (CheckInCurrentWeek(start) == 0)
                {

                    for (int k = 0; k < TimeLineTasks[j].GetDayInterval(); k++)
                    {

                        string sd = start.ToShortDateString();

                        if (PD_TimeLine.Columns.Contains(sd))
                        {
                            switch (TimeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
                                    break;
                            }
                        }
                        start = start.AddDays(1);
                    }
                }



                if (CheckInCurrentWeek(start) == -1 && CheckInCurrentWeek(end) == 0)
                {
                    DateTime startPoint = startWeekTime;

                    for (int k = 0; k < TimeLineTasks[j].GetLaterTimeInterval(startWeekTime); k++)
                    {
                        string sd = startPoint.ToShortDateString();
                        if (PD_TimeLine.Columns.Contains(sd))
                        {
                            switch (TimeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
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
                        if (PD_TimeLine.Columns.Contains(sd))
                        {
                            switch (TimeLineTasks[j].higlight)
                            {
                                case 0:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Green;
                                    break;
                                case 1:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.DarkOrange;
                                    break;
                                case 2:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Red;
                                    break;
                                case 3:
                                    PD_TimeLine.Rows[i].Cells[sd].Style.BackColor = Color.Gray;
                                    break;
                            }
                        }
                        startPoint = startPoint.AddDays(1);
                    }
                }

                i = i + 1;

            }
        }
    }
}